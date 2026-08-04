#!/usr/bin/env python3
"""
Extracts the in-game Apex HUD text from the Workshop source and emits Markdown.

Each Apex hero's HUD is built by a block like:

    If(Hero Of(Event Player) == Hero(Ana));
        Create HUD Text(..., Hero Icon String(Hero(Ana)),
            Custom String("The Nightmare of Necropolis"),
            Custom String("Difficulty 3/5"), Left, 0, ...);
        Create HUD Text(Event Player, Null,
            Custom String("Condemn [Ability 1]"),
            Custom String("Ana fires a Recoiling heavy Sleep Bolt..."), Left, 1, ...);
    End;

The first Create HUD Text is the header (title + difficulty); the rest are
ability rows, ordered by the sort index that follows the alignment argument.
"""
import re
import sys

SRC = "Full Game.txt"
OUT = "docs/APEX_HEROES.md"

RE_BLOCK = re.compile(
    r"If\(Hero Of\(Event Player\) == Hero\(([^)]+)\)\);(.*?)\bEnd;", re.S)
RE_STR = re.compile(r'Custom String\(\s*"((?:[^"\\]|\\.)*)"', re.S)
# the sort order is the integer right after the alignment keyword
RE_SORT = re.compile(r"\b(?:Left|Right|Top)\s*,\s*(-?\d+)")


def flatten(s):
    return re.sub(r"\s*\n\s*", " ", s)


def hud_calls(body):
    """Split on the start of each Create HUD Text call rather than on ');'.

    Descriptions legitimately contain ');' (Genji's ability text does), which
    truncates any regex that terminates on it — that silently ate half his
    ability list before this was caught against a screenshot."""
    parts = body.split("Create HUD Text(")
    return parts[1:]


def clean(s):
    """Workshop strings carry literal escape sequences and || decorations."""
    s = s.replace("\\r\\n", " ").replace("\\n", " ").replace("\\r", " ")
    s = s.replace("\\\"", '"')
    s = re.sub(r"\s+", " ", s).strip()
    return s


def parse(path):
    raw = open(path, encoding="utf-8", errors="replace").read()
    i = raw.find("Apex: Hud Text")
    if i < 0:
        return []
    flat = flatten(raw[i:])
    heroes = []
    for hero, body in RE_BLOCK.findall(flat):
        rows = []
        for call in hud_calls(body):
            strings = [clean(s) for s in RE_STR.findall(call)]
            strings = [s for s in strings if s]
            if not strings:
                continue
            m = RE_SORT.search(call)
            order = int(m.group(1)) if m else 99
            rows.append((order, strings))
        if not rows:
            continue
        rows.sort(key=lambda r: r[0])
        header = rows[0][1]
        title = header[0] if header else ""
        difficulty = ""
        for s in header[1:]:
            if "difficulty" in s.lower():
                difficulty = s
        abilities = []
        for _, strings in rows[1:]:
            name = strings[0]
            desc = strings[1] if len(strings) > 1 else ""
            abilities.append((name, desc))
        heroes.append({"hero": hero, "title": title,
                       "difficulty": difficulty, "abilities": abilities})
    return heroes


def stars(difficulty):
    m = re.search(r"(\d+)\s*/\s*(\d+)", difficulty or "")
    if not m:
        return ""
    got, total = int(m.group(1)), int(m.group(2))
    return "●" * got + "○" * (total - got)


def to_markdown(heroes):
    L = ["## Apex heroes", "",
         "Every Apex is a full rework. Difficulty is how hard that Apex is to "
         "pilot against six Hunters — not how strong it is.", ""]
    for h in sorted(heroes, key=lambda x: x["hero"]):
        d = stars(h["difficulty"])
        head = f"### [hero {h['hero']}] {h['hero']} — *{h['title']}*"
        L.append(head)
        if d:
            L.append(f"**{d}**  {h['difficulty']}")
        L.append("")
        if h["abilities"]:
            L.append("| Ability | What changed |")
            L.append("|---|---|")
            for name, desc in h["abilities"]:
                # `|| Form ||` markers are section dividers inside a hero's
                # list (Genji and Roadhog switch forms), not abilities.
                bare = name.strip("| ").strip()
                if not desc and bare != name:
                    L.append(f"| — *{bare}* | |")
                    continue
                name = name.replace("|", "／")
                desc = desc.replace("|", "／")
                L.append(f"| **{name}** | {desc} |")
        L.append("")
    return "\n".join(L)


def esc(s):
    """HTML-escape. Pipes matter too: Workshop.codes treats a raw | as a table
    delimiter even inside HTML, so it has to become an entity."""
    return (s.replace("&", "&amp;").replace("<", "&lt;").replace(">", "&gt;")
             .replace("|", "&#124;"))


def to_workshop(heroes):
    """Collapsible blocks for the Workshop.codes description.

    Uses <details> with a pure-HTML table inside. The wiki warns that
    "Markdown in HTML sometimes not" renders, so nothing inside the block
    relies on Markdown.
    """
    L = ["## Apex heroes", "",
         "Every Apex is a full rework. Difficulty is how hard that Apex is to "
         "pilot against six Hunters — not how strong it is. Click a hero to "
         "see their changes.", ""]
    for h in sorted(heroes, key=lambda x: x["hero"]):
        d = stars(h["difficulty"])
        diff = h["difficulty"] or "Difficulty —"
        L.append("<details>")
        L.append(f"<summary><b>{esc(h['hero'])}</b> — <i>{esc(h['title'])}</i>"
                 f" &nbsp; {d} <small>{esc(diff)}</small></summary>")
        L.append("<table>")
        L.append("<tr><th align=\"left\">Ability</th>"
                 "<th align=\"left\">What changed</th></tr>")
        for name, desc in h["abilities"]:
            bare = name.strip("| ").strip()
            if not desc and bare != name:
                L.append(f'<tr><td colspan="2"><i>{esc(bare)}</i></td></tr>')
                continue
            L.append(f"<tr><td><b>{esc(name)}</b></td><td>{esc(desc)}</td></tr>")
        L.append("</table>")
        L.append("</details>")
        L.append("")
    return "\n".join(L)


if __name__ == "__main__":
    heroes = parse(SRC)
    if not heroes:
        sys.exit("No HUD blocks found in " + SRC)
    md = to_markdown(heroes)
    with open(OUT, "w", encoding="utf-8") as f:
        f.write(md)
    ws = to_workshop(heroes)
    with open("docs/APEX_HEROES_workshop.md", "w", encoding="utf-8") as f:
        f.write(ws)
    print(f"{len(heroes)} Apex heroes extracted -> {OUT}")
    print(f"  workshop.codes version -> docs/APEX_HEROES_workshop.md "
          f"({len(ws):,} chars)")
    for h in heroes:
        print(f"  {h['hero']:<16} {h['difficulty']:<16} "
              f"{len(h['abilities'])} abilities  | {h['title']}")
