# Apex Protocol

An unofficial **Juggernaut** game mode for Overwatch, built entirely in the
Workshop scripting environment. One overpowered player — the *Apex* — fights an
entire team of six Hunters. Every hero was reworked from scratch for the role.

**11,500+ views · 5,000+ downloads** on Workshop.codes (lifetime, 2019-2024)
Developed April 2019 – January 2024.

Live listing: <https://workshop.codes/apexprotocol>

---

## What it is

Standard Elimination pits two even teams against each other. Apex Protocol
breaks the symmetry: a single player receives a heavily modified version of
their hero — new abilities, rebalanced numbers, altered movement — and must
survive against six opponents who have their own separate rework.

Making that fair required rebuilding each hero twice: once as an Apex, once as
a Hunter.

## By the numbers

| | |
|---|---|
| Rules (event handlers) | **307** |
| Heroes with custom logic | **29** |
| Variables tracked | 17 global, 88 player-scoped |
| Subroutines | 6 |
| Lines (current build) | 10,469 |
| Lines (pre-Overwatch 2 build) | 8,620 |

## How it's built

The Workshop is an event-driven rules engine — no functions in the ordinary
sense, no real data structures beyond arrays, and a hard cap on rule count. The
architecture works around those limits:

- **Namespaced rules.** Every rule is prefixed `Apex:` and grouped by system
  (`Apex: Health Bar - HUD - Damage`, `Apex: Skydome - Effect Loop`), so 307
  rules stay navigable in an editor with no search.
- **Subroutines as shared functions.** `Apex_HUD`, `Disable_All_Buttons`,
  `Enable_All_Buttons`, `Genji_Ult_Choice`, `Reaper_Form_Blind_Effect`,
  `Sigma_Rock_Loop` — logic reused across heroes instead of duplicated per hero,
  which is what keeps the rule count under the ceiling.
- **A dynamic HUD system.** Each hero gets generated on-screen text describing
  its reworked abilities, a difficulty rating, and a live health bar. HUD
  elements are tracked in a per-player array and destroyed on hero swap, because
  the Workshop leaks HUD text otherwise.
- **Per-hero ability overrides.** 29 heroes, each with bespoke rules for
  abilities, ultimate behavior, scaling, and voice-line modification.

## Surviving the Overwatch 2 migration

`archive/Full Game_Pre OW2.txt` is the last Overwatch 1 build. `Full Game.txt`
is what it became.

Overwatch 2 changed the ground the mod stood on: teams went from 6v6 to 5v5,
several heroes were reworked or rebuilt outright, and parts of the Workshop API
changed behavior. A mode balanced around one player versus six no longer had six
players to balance against.

Porting it meant re-tuning every hero's numbers against a smaller Hunter team,
rewriting the rules that depended on changed hero kits, and fixing the HUD
system where the API had shifted underneath it. The mod kept shipping.

## Repository layout

```
Full Game.txt                  current build — import this one
Overwatch ApexProtocol.txt     earlier standalone build
archive/
  Full Game_Pre OW2.txt        final Overwatch 1 build, kept for reference
modules/
  Genji Smoke Effect.txt       standalone visual effect
  Apex Team 2 - Ult Damage Bonus.txt
  Apex Team 2 - Teammate Health and Ult Hud.txt
docs/
  Apex Team 1 - List of Changes.txt   per-hero rework notes (Apex side)
  Things to Change.txt                open issues
```

## Using it

1. Open Overwatch → **Game Browser** → **Create** → **Settings** → **Import
   Code**
2. Paste the contents of `Full Game.txt`
3. Team 1 holds one player (the Apex); Team 2 holds up to six Hunters

The standalone files under `modules/` can be imported into other Workshop
projects independently.

## Known issues

See `docs/Things to Change.txt`.

- Doomfist has incorrect health values on Team 2
- Bastion's rework is unfinished

---

Built by Nikolas George.
