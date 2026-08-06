"""Shared fixtures.

extract_hud.py sits at the repo root rather than in a package, so the root has
to be importable before `import extract_hud` resolves.
"""
import os
import sys

import pytest

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
if ROOT not in sys.path:
    sys.path.insert(0, ROOT)


# A miniature of the real Workshop source: the marker the parser scans for,
# then one well-formed hero block. Written out rather than sampled from
# "Full Game.txt" so the tests keep working if the game file changes.
HERO_BLOCK = '''
Apex: Hud Text

If(Hero Of(Event Player) == Hero(Ana));
    Create HUD Text(All Players(All Teams), Hero Icon String(Hero(Ana)),
        Custom String("The Nightmare of Necropolis"),
        Custom String("Difficulty 3/5"), Left, 0, White, White, White);
    Create HUD Text(Event Player, Null,
        Custom String("Condemn [Ability 1]"),
        Custom String("Fires a recoiling heavy Sleep Bolt."), Left, 1,
        White, White, White);
    Create HUD Text(Event Player, Null,
        Custom String("Requiem [Ultimate]"),
        Custom String("Heals all allies."), Left, 2, White, White, White);
End;
'''


@pytest.fixture
def workshop_source(tmp_path):
    """Write a Workshop source file and return its path."""
    def _write(text=HERO_BLOCK, name="source.txt"):
        path = tmp_path / name
        path.write_text(text, encoding="utf-8")
        return str(path)
    return _write
