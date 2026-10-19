"""Tests for the HUD extractor.

Several of these are regression tests for bugs the parser's own comments
record: a `);` inside a description truncating the ability list, D.Va's bare
"3/5" difficulty being dropped, and heroes with real ability names but
"Filler" descriptions being published as if they were finished. Each of those
was found by comparing output against the game rather than by reading code,
which is exactly the kind of bug that comes back.
"""
import pytest
from conftest import HERO_BLOCK

import extract_hud as eh


# ----------------------------------------------------------------- flatten
class TestFlatten:
    def test_newlines_and_surrounding_space_collapse(self):
        assert eh.flatten("a\n   b") == "a b"

    def test_text_without_newlines_is_unchanged(self):
        assert eh.flatten("already flat") == "already flat"

    def test_multiple_breaks_each_collapse(self):
        assert eh.flatten("a\nb\nc") == "a b c"


# --------------------------------------------------------------- hud_calls
class TestHudCalls:
    def test_each_call_becomes_one_entry(self):
        body = ('Create HUD Text(first); Create HUD Text(second); '
                'Create HUD Text(third);')
        assert len(eh.hud_calls(body)) == 3

    def test_text_before_the_first_call_is_discarded(self):
        assert eh.hud_calls("preamble Create HUD Text(only);") == ["only);"]

    def test_a_body_with_no_calls_yields_nothing(self):
        assert eh.hud_calls("nothing here") == []

    def test_a_description_containing_a_paren_does_not_truncate_the_list(self):
        # The bug this guards: splitting on ');' instead of on the start of
        # each call. Genji's ability text legitimately contains ');', which
        # silently ate half the ability list.
        body = ('Create HUD Text(Custom String("Deflect (and reflect);"));'
                'Create HUD Text(Custom String("Second ability"));')
        assert len(eh.hud_calls(body)) == 2


# ------------------------------------------------------------------- clean
class TestClean:
    def test_literal_escape_sequences_become_spaces(self):
        assert eh.clean("line one\\r\\nline two") == "line one line two"

    def test_escaped_quotes_are_unescaped(self):
        assert eh.clean('say \\"hello\\"') == 'say "hello"'

    def test_whitespace_runs_collapse(self):
        assert eh.clean("too     many   spaces") == "too many spaces"

    def test_surrounding_whitespace_is_trimmed(self):
        assert eh.clean("   padded   ") == "padded"

    def test_empty_string(self):
        assert eh.clean("") == ""


# ------------------------------------------------------------------- stars
class TestStars:
    def test_the_filled_count_is_the_rating(self):
        assert eh.stars("Difficulty 3/5") == "●●●"

    def test_no_empty_slots_are_emitted(self):
        # Empty slots were the original problem: on a dark background the
        # hollow glyph read brighter than the filled one, so 1/5 looked
        # like 4/5. The output must contain nothing but filled marks.
        assert set(eh.stars("Difficulty 1/5")) == {"●"}
        assert len(eh.stars("Difficulty 1/5")) == 1

    def test_spaces_around_the_slash_are_tolerated(self):
        assert eh.stars("Difficulty 2 / 5") == "●●"

    def test_a_bare_ratio_still_parses(self):
        assert eh.stars("3/5") == "●●●"

    def test_text_without_a_ratio_yields_nothing(self):
        assert eh.stars("Difficulty unknown") == ""

    def test_empty_and_none(self):
        assert eh.stars("") == ""
        assert eh.stars(None) == ""


# --------------------------------------------------------------------- esc
class TestEsc:
    def test_ampersand_is_escaped_first(self):
        # Escaping & after < would double-escape the entities produced by it.
        assert eh.esc("&<>") == "&amp;&lt;&gt;"

    def test_pipes_become_entities(self):
        # Workshop.codes treats a raw | as a table delimiter even inside
        # HTML, so a pipe in ability text breaks the surrounding table.
        assert eh.esc("a|b") == "a&#124;b"

    def test_ordinary_text_is_untouched(self):
        assert eh.esc("plain text") == "plain text"


# ------------------------------------------------------------------- parse
class TestParse:
    def test_a_hero_block_is_extracted(self, workshop_source):
        heroes = eh.parse(workshop_source())
        assert len(heroes) == 1
        assert heroes[0]["hero"] == "Ana"

    def test_the_header_supplies_title_and_difficulty(self, workshop_source):
        h = eh.parse(workshop_source())[0]
        assert h["title"] == "The Nightmare of Necropolis"
        assert h["difficulty"] == "Difficulty 3/5"

    def test_abilities_are_name_description_pairs(self, workshop_source):
        h = eh.parse(workshop_source())[0]
        assert h["abilities"] == [
            ("Condemn [Ability 1]", "Fires a recoiling heavy Sleep Bolt."),
            ("Requiem [Ultimate]", "Heals all allies."),
        ]

    def test_abilities_follow_the_sort_index_not_file_order(self, workshop_source):
        swapped = HERO_BLOCK.replace("Left, 1", "Left, 9")
        h = eh.parse(workshop_source(text=swapped))[0]
        assert h["abilities"][0][0] == "Requiem [Ultimate]"

    def test_a_bare_ratio_difficulty_is_labelled(self, workshop_source):
        # D.Va's header reads "3/5" with no "Difficulty" keyword. A
        # keyword-only match dropped it silently.
        text = HERO_BLOCK.replace('Custom String("Difficulty 3/5")',
                                  'Custom String("3/5")')
        assert eh.parse(workshop_source(text=text))[0]["difficulty"] == "Difficulty 3/5"

    def test_content_before_the_marker_is_ignored(self, workshop_source):
        text = "If(Hero Of(Event Player) == Hero(Ghost));End;\n" + HERO_BLOCK
        assert [h["hero"] for h in eh.parse(workshop_source(text=text))] == ["Ana"]

    def test_a_file_without_the_marker_yields_nothing(self, workshop_source):
        assert eh.parse(workshop_source(text="no marker in this file")) == []

    def test_a_hero_with_no_hud_rows_is_skipped(self, workshop_source):
        text = "Apex: Hud Text\nIf(Hero Of(Event Player) == Hero(Ana));End;"
        assert eh.parse(workshop_source(text=text)) == []


# ----------------------------------------------------- placeholder detection
class TestPlaceholderDetection:
    def test_a_complete_hero_is_not_a_placeholder(self, workshop_source):
        assert eh.parse(workshop_source())[0]["placeholder"] is False

    def test_filler_in_any_row_marks_the_hero_unfinished(self, workshop_source):
        # The bug: several heroes pair a real ability name with a "Filler"
        # description. Requiring every row to be filler let those through.
        text = HERO_BLOCK.replace("Heals all allies.", "Filler")
        assert eh.parse(workshop_source(text=text))[0]["placeholder"] is True

    def test_filler_matching_ignores_case(self, workshop_source):
        text = HERO_BLOCK.replace("Heals all allies.", "FILLER")
        assert eh.parse(workshop_source(text=text))[0]["placeholder"] is True


# -------------------------------------------------------------- to_markdown
class TestToMarkdown:
    def test_a_finished_hero_is_rendered(self, workshop_source):
        md = eh.to_markdown(eh.parse(workshop_source()))
        assert "Ana" in md
        assert "The Nightmare of Necropolis" in md
        assert "Condemn [Ability 1]" in md

    def test_placeholder_heroes_are_not_published(self, workshop_source):
        text = HERO_BLOCK.replace("Heals all allies.", "Filler")
        assert "Ana" not in eh.to_markdown(eh.parse(workshop_source(text=text)))

    def test_the_difficulty_renders_as_filled_marks(self, workshop_source):
        assert "●●●" in eh.to_markdown(eh.parse(workshop_source()))

    def test_pipes_in_ability_text_do_not_break_the_table(self, workshop_source):
        text = HERO_BLOCK.replace("Heals all allies.", "Heals | everyone")
        md = eh.to_markdown(eh.parse(workshop_source(text=text)))
        row = [ln for ln in md.split("\n") if "Requiem" in ln][0]
        # Three delimiters: leading, separating, trailing. A fourth means the
        # description's pipe has been read as a column break.
        assert row.count("|") == 3

    def test_output_is_deterministic(self, workshop_source):
        heroes = eh.parse(workshop_source())
        assert eh.to_markdown(heroes) == eh.to_markdown(heroes)


# -------------------------------------------------------------- to_workshop
class TestToWorkshop:
    def test_each_hero_gets_a_collapsible_block(self, workshop_source):
        ws = eh.to_workshop(eh.parse(workshop_source()))
        assert ws.count("<details>") == 1
        assert ws.count("</details>") == 1

    def test_tables_are_pure_html(self, workshop_source):
        # The wiki warns that Markdown inside HTML sometimes does not render,
        # so nothing in the block may depend on it.
        ws = eh.to_workshop(eh.parse(workshop_source()))
        assert "<table>" in ws
        assert "|---|" not in ws

    def test_placeholder_heroes_are_not_published(self, workshop_source):
        text = HERO_BLOCK.replace("Heals all allies.", "Filler")
        assert "<details>" not in eh.to_workshop(eh.parse(workshop_source(text=text)))

    def test_ability_text_is_html_escaped(self, workshop_source):
        text = HERO_BLOCK.replace("Heals all allies.", "Deals <50> damage")
        ws = eh.to_workshop(eh.parse(workshop_source(text=text)))
        assert "&lt;50&gt;" in ws
        assert "<50>" not in ws

    def test_the_hero_markdown_tag_survives_inside_summary(self, workshop_source):
        # [hero X] is Workshop.codes markdown that resolves before the HTML
        # is rendered, so it has to stay unescaped in the summary line.
        ws = eh.to_workshop(eh.parse(workshop_source()))
        assert "[hero Ana]" in ws


# ------------------------------------------------------------------- main/CLI
class TestMain:
    def test_writes_both_outputs_to_the_given_paths(self, workshop_source, tmp_path):
        md, ws = tmp_path / "heroes.md", tmp_path / "heroes_ws.md"
        rc = eh.main(["--src", workshop_source(), "--out", str(md),
                      "--workshop-out", str(ws), "--quiet"])
        assert rc == 0
        assert "Nightmare of Necropolis" in md.read_text(encoding="utf-8")
        assert "<details>" in ws.read_text(encoding="utf-8")

    def test_exits_when_the_source_has_no_hud_blocks(self, workshop_source, tmp_path):
        with pytest.raises(SystemExit) as e:
            eh.main(["--src", workshop_source(text="nothing here"),
                     "--out", str(tmp_path / "o.md"),
                     "--workshop-out", str(tmp_path / "w.md"), "--quiet"])
        assert "No HUD blocks found" in str(e.value)

    def test_quiet_suppresses_the_summary(self, workshop_source, tmp_path, capsys):
        eh.main(["--src", workshop_source(), "--out", str(tmp_path / "o.md"),
                 "--workshop-out", str(tmp_path / "w.md"), "--quiet"])
        assert capsys.readouterr().out == ""

    def test_summary_lists_each_hero_by_default(self, workshop_source, tmp_path, capsys):
        eh.main(["--src", workshop_source(), "--out", str(tmp_path / "o.md"),
                 "--workshop-out", str(tmp_path / "w.md")])
        out = capsys.readouterr().out
        assert "1 Apex heroes extracted" in out
        assert "Ana" in out
