# CLAUDE: READ THIS BEFORE DOING ANYTHING

Master context file for Salah's game dev learning journey.

---

## WHO IS SALAH

Salah understands **how logic works** — if/else, switches, functions, variables, loops, how programs flow. He can think through any logic on paper. But he has **never turned that logic into working code** in any language. The gap isn't understanding — it's the actual typing, syntax, and making things run.

He wants to **learn to code properly** by building games in Unity. Not have AI write code for him.

---

## TEACHING RULES (CRITICAL)

1. **Explain the concept in plain English first** — what it does, why it exists
2. **Show the syntax** — how that concept looks in C# (small pieces, not walls of code)
3. **Ask him to write it** — "Now you try. Write a variable that stores the player's health."
4. **Review and correct** — explain what's wrong and WHY, not just the fix
5. **One concept at a time** — never overwhelm with multiple new things at once
6. **Treat him as a complete beginner to coding** — he knows logic, not syntax
7. **Keep code snippets SHORT** — 5-15 lines max when teaching. Build up gradually.
8. **Never dump a full script** — build it together, line by line

When he's stuck: hint first → show a small piece → walk through together → full solution (last resort, explained line by line).

---

## THE GOAL

**Short-term:** Learn C# and Unity from zero by building small games.
**Long-term:** Build a story-driven game demo (30-60 min).

Five story concepts are fully designed in the `Story_Concepts/` folder. No concept chosen yet — Salah will pick one when he has the skills to know what's buildable.

## THE 5 CONCEPTS (Summaries)

1. **Ashen Litany** — Dark fantasy soulslike. Bell-ringer in a corrupted cathedral. Combat as prayer. Souls-like.
2. **Patient Zero** — Horror mystery. Doctor explores abandoned hospital. VHS tapes tell the story. No combat.
3. **The Last Librarian** — Puzzle adventure. Library where books are portals to different worlds. Flashlight reveals hidden notes.
4. **The Hollow Crown** — Medieval RPG. Political intrigue, faction choices, one night in a capital city.
5. **Hollowreach** — Death-loop soulslike. Underground city rearranges on death. Enemies remember you.

---

## ENGINE: UNITY

Chosen because: beginner-friendly, free, biggest learning ecosystem, best solo-dev engine, mature AI/MCP tools (CoplayDev/unity-mcp, CoderGamester/mcp-unity).

---

## LEARNING CURRICULUM (6 Phases)

| Phase | Project | What He Learns |
|-------|---------|---------------|
| 0 | Setup | Install Unity, understand editor, first script (spin a cube) |
| 1 | "The Moving Cube" | Input, movement, physics, collisions, basic UI |
| 2 | "Platformer" | Character controller, levels, audio, menus |
| 3 | "Survive the Night" | Enemy AI, health, inventory, spawning |
| 4 | "The Talking Door" | Dialogue, branching choices, save/load |
| 5 | "Mini Dungeon" | Combine all systems into a real mini-game |
| 6 | **Story Game Demo** | The actual game, using everything learned |

Detailed progress tracking in `Unity_Journey/JOURNEY.md`.

---

## FILES

```
D:\UnrealEngine Projects\Scrambling_Ideas\
├── CLAUDE_START_HERE.md         ← This file (read first)
├── Unity_Journey/
│   └── JOURNEY.md               ← Detailed progress, session log, skills checklist
├── Story_Concepts/
│   ├── 01_Ashen_Litany.md
│   ├── 02_Patient_Zero.md
│   ├── 03_The_Last_Librarian.md
│   ├── 04_The_Hollow_Crown.md
│   └── 05_Hollowreach.md
└── fab_library_assets.md         ← 140 Fab.com assets catalog
```

---

## CURRENT STATE

- **Phase:** 3 — Survive the Night (IN PROGRESS)
- **Unity Installed:** Yes (Unity 6.3)
- **Last Session:** 2026-02-26
- **Sessions so far:** 10
- **Next step:** Session 11, enemy states with enums and switch statements

---

## SESSION LOG (Keep brief — just date + what happened + next step)

**2026-02-24:** Brainstormed 5 story concepts. Researched Unity vs Unreal. Chose Unity. Established learning-first philosophy. Created tracking system.
**2026-02-24:** Installed Unity 6.3, VS Code. Created TheMovingCube project. Research council established teaching method.
**2026-02-24:** Sessions 3-4. Learned C# from scratch (variables, if/else, functions, Update, Transform, Input, Rigidbody, Vector3, physics movement). 5 hour marathon.
**2026-02-25:** Sessions 5-6. Triggers, collectibles, cross-script comms, UI. Solo rebuild passed. Phase 1 COMPLETE.
**2026-02-25-26:** Sessions 7-8. Phase 2: jumping, raycasting, moving platforms, kill zones, hazards, scene loading, audio, main menu. Phase 2 COMPLETE.
**2026-02-26:** Session 9. Gauntlet challenge: rebuilt entire game from scratch with no reference. Discovered new patterns independently (string interpolation, LateUpdate, MoveTowards, ternary, helper functions). Phase 2 FULLY COMPLETE.
**2026-02-26:** Session 10. Phase 3 started. Created SurviveTheNight project. Learned arrays, lists, for loops, prefabs, Instantiate, Random.Range, spawn timer. Built enemy chase + spawner + health/damage system.
**Next:** Session 11, enemy states (enums, switch statements).
