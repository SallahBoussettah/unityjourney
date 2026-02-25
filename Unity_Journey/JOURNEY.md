# Salah's Unity Game Dev Journey

## Current Status
- **Phase:** 2 — Platformer (in progress)
- **Current Project:** SimplePlatformer (Unity 6.3, Universal 3D URP)
- **Last Session:** 2026-02-25
- **Total Sessions:** 7
- **Skills Unlocked:** Variables, types, Debug.Log, if/else, functions, return values, Update, Transform, Input, Time.deltaTime, bool logic, public/Inspector, stamina systems, Rigidbody, GetComponent, FixedUpdate, Vector3, normalized, physics movement, OnTriggerEnter, CompareTag, Destroy, cross-script communication, Tags, camera follow, UI Canvas, TextMeshProUGUI, using TMPro, AddForce, ForceMode.Impulse, Physics.Raycast, ground check, Mathf.PingPong, OnCollisionEnter/Exit, moving platforms, respawn system, rb.linearVelocity

---

## How We Learn (The Rules)

### Teaching Method
- **No videos, no external tutorials.** It's Claude + Salah, building together.
- Claude explains concepts in plain English first, then shows syntax.
- Salah writes every line of code himself. Never copy-paste.
- One new concept per session. Don't rush.
- When stuck: try for 3 minutes yourself first, then ask Claude.

### Session Template (~60 min)
1. **Warm-up Recall (5 min):** Type something from last session from memory. No peeking.
2. **Concept + Guided Build (25 min):** Learn ONE concept. Claude explains, Salah types.
3. **Solo Rebuild (20 min):** Close/hide reference. Rebuild from memory. Struggle is the point.
4. **Extend or Reflect (10 min):** Early phases = write what you learned. Later = add your own feature.

### AI Rules
- Claude uses Socratic teaching: hints and questions, not handing out answers.
- Direct answers OK for pure syntax questions (what does this symbol mean?).
- Claude NEVER generates a complete script.

### End-of-Lesson Challenges
- After each lesson, Claude gives a challenge described in plain English only. No code.
- Salah builds it himself from scratch.
- If something breaks: 3 real attempts to fix it before asking Claude.
- After 3 tries, Claude helps (hints first, then direct help if needed).
- No AI code completion tools during learning.
- Struggle timer increases as skills grow: 3 min (early) > 5-10 min (mid) > 15 min (late).

### Debugging Rules (from Day One)
- Console window always visible in Unity.
- Read error messages yourself first. They tell you the file and line number.
- Use Debug.Log() as your detective tool.
- Errors are friends, not enemies.

---

## The Roadmap

### Phase 0: Setup + C# Orientation (1-2 weeks)
Goal: Get comfortable with Unity editor and C# syntax before making anything visual.

- [x] Install Unity Hub + Unity 6.3
- [x] Install VS Code + C# Dev Kit
- [x] Create first Unity project (TheMovingCube, URP template)
- [x] Change Play Mode tint color (so you never lose work in Play Mode)
- [x] Session 3: First script, variables, types, Debug.Log(), type conversion
- [x] Session 3: if/else, functions, return values, Debug.Log output
- [x] Session 3: Attach script to cube, rotation, movement, input, sprint/stamina system
- [ ] Understand Unity Editor panels (Scene, Game, Hierarchy, Inspector, Console, Project)

**C# concepts this phase:** variables (int, float, string, bool), Debug.Log(), if/else, functions, public/private, MonoBehaviour, Start(), Update()

### Phase 1: "The Moving Cube" (2-3 weeks)
Goal: A playable cube that moves, collects items, and has a score.

- [x] Player input (WASD / arrow keys)
- [x] Moving a 3D object with code YOU write
- [x] Time.deltaTime (frame-independent movement)
- [x] Camera following the player
- [x] Basic physics (Rigidbody, collisions)
- [x] Collecting items (OnTriggerEnter)
- [x] Simple UI: score counter
- [x] Solo rebuild: rebuild the full game from memory

**C# concepts this phase:** Input handling, Transform.Translate, Time.deltaTime, Rigidbody, OnCollisionEnter, OnTriggerEnter, GetComponent<>(), basic UI text

**Feels like:** A tiny game where a cube rolls around collecting spheres.

### Phase 2: "Platformer" (4-6 weeks)
Goal: A small 3D platformer with 2-3 levels.

- [x] Character controller (jump, gravity, ground check)
- [x] Level design with basic shapes (4 platforms)
- [x] Moving platforms (PingPong, platform carries player)
- [x] Kill zone (trigger collider, respawn to start)
- [x] Collectibles + UI score (rebuilt from memory)
- [x] Obstacles and hazards (health system, gradual damage with OnTriggerStay)
- [ ] Multiple levels / scene loading
- [ ] Sound effects (AudioSource)
- [ ] Simple main menu

**C# concepts this phase:** arrays/lists, loops (for, foreach), Rigidbody.AddForce, raycasts, SceneManager, AudioSource, coroutines

### Phase 3: "Survive the Night" (4-6 weeks)
Goal: A survival game with enemies, health, and a flashlight.

- [ ] Enemy AI (chase player, patrol, attack)
- [ ] Health system (take damage, die, heal)
- [ ] Simple inventory (pick up items, use them)
- [ ] Flashlight mechanic
- [ ] Spawn system (enemies appear over time)
- [ ] Win/lose conditions

**C# concepts this phase:** enums, switch statements, NavMesh, ScriptableObjects, more complex classes
**Pattern introduced:** Name the Component pattern (you'll already be using it)

### Phase 4: "The Talking Door" (3-5 weeks)
Goal: Walk into a room, talk to NPCs, make choices that change the world.

- [ ] Dialogue system from scratch (typewriter text effect)
- [ ] Branching choices (player picks a response)
- [ ] NPC interaction (walk up, press E, talk)
- [ ] Triggering events from dialogue (door opens, item given)
- [ ] Save/load a simple game state

**C# concepts this phase:** data structures (lists, dictionaries), events/delegates, UI Canvas deeper dive, JSON serialization
**Pattern introduced:** Events and state enums

### Phase 5: "Mini Dungeon" (6-8 weeks)
Goal: A 5-10 minute dungeon crawler combining all previous skills.

- [ ] Combine EVERYTHING: movement, combat, inventory, dialogue, levels
- [ ] Melee combat (attack animation, hitbox, damage)
- [ ] Locked doors + keys
- [ ] Simple quest system
- [ ] Environmental storytelling (readable notes, interactable objects)
- [ ] 2-3 connected rooms

**C# concepts this phase:** inheritance, interfaces, serialization for save data, design patterns
**Pattern introduced:** State machines for enemy AI

### Phase 6: Story Game Demo (10-16 weeks)
Goal: A 30-60 minute story-driven game. The real thing.

- [ ] Pick one of the 5 story concepts
- [ ] Apply everything learned
- [ ] Integrate marketplace assets
- [ ] Polish, playtest, iterate
- **You'll be ready.** Not because AI wrote it for you. Because you BUILT your way here.

---

## C# Concepts Learned (Checklist)

### Fundamentals
- [x] Variables (int, float, string, bool)
- [x] Debug.Log()
- [x] Functions/Methods (parameters, return values)
- [x] if/else conditions
- [x] Comparison operators (==, !=, <, >, <=, >=)
- [x] Logical operators (&&, ||, !)
- [ ] Loops (for, foreach, while)
- [ ] Arrays and Lists
- [ ] Classes and Objects
- [ ] Enums
- [ ] Switch statements

### Unity-Specific
- [x] MonoBehaviour (Start, Update)
- [x] Transform (Rotate, Translate)
- [x] public variables + Inspector
- [x] Input system (GetKey, GetKeyDown)
- [x] Time.deltaTime
- [x] Rigidbody + Physics (MovePosition, FixedUpdate)
- [x] Colliders + Triggers (OnTriggerEnter, CompareTag, Destroy)
- [x] GetComponent<>()
- [ ] Coroutines
- [ ] ScriptableObjects
- [ ] Events and Delegates
- [ ] SceneManager
- [x] UI (Canvas, TextMeshPro)
- [ ] AudioSource
- [ ] NavMesh (AI navigation)
- [x] Raycasting (Physics.Raycast for ground check)
- [ ] Animation (Animator, states, triggers)
- [ ] JSON / Data persistence
- [ ] Prefabs (instantiate, destroy)

### Patterns
- [ ] Component pattern (naming what you already do)
- [ ] State tracking with enums
- [ ] Events for decoupling systems
- [ ] State machines

---

## Session Log

### Session 1 — 2026-02-24
- Discussed 5 story game concepts (see Story_Concepts/ folder)
- Researched Unity vs Unreal for Claude Code workflow
- Decision: UNITY (learning-friendly, C# close to JS/TS, solo dev engine)
- Decision: LEARNING FIRST approach, AI as teacher, not replacement
- Created journey tracking system
- Next: Install Unity, first project setup

### Session 2 — 2026-02-24
- Installed Unity 6.3, VS Code + C# Dev Kit
- Created TheMovingCube project (Universal 3D URP template)
- Spawned research team (Alpha, Bravo, Charlie) to debate best learning approach
- Established teaching method: Socratic, one concept at a time, type everything, rebuild from memory
- Established session template: warm-up > guided build > solo rebuild > reflect
- Decision: No video tutorials, just Claude + Salah
- Next: Session 3, first C# script, Debug.Log()

### Session 3 — 2026-02-24 (5 hour marathon)
- Wrote first C# script (HelloWorld.cs): variables, Debug.Log, string concatenation
- Learned type conversion (float to int), discovered comments on his own
- First error message read and fixed independently
- Learned if/else, else if, comparison operators
- Learned functions with parameters and return values (CheckHealth, TakeDamage)
- Challenge: DamageCalculator (completed with guidance)
- Challenge: CombatSimulator (return values, updating health across multiple hits)
- Learned Update(), Transform.Rotate, Transform.Translate
- Learned public variables and Inspector tweaking
- Learned Time.deltaTime for frame-independent movement
- Learned Input.GetKey, Input.GetKeyDown, KeyCode
- Learned logical operators: && (AND), || (OR), ! (NOT)
- Fixed Unity Input System issue (switched to "Both" in Player Settings)
- Challenge: Speed Boost (shift sprint with Q/E rotation, improvised)
- Challenge: Prison Escape (WASD + sprint + stamina drain/recovery + isExhausted + isMoving)
- Debugged execution order issue (movement before sprint check vs after)
- Refactored movement into its own function unprompted
- Set Play Mode tint color
- Key patterns: reads errors well, improvises features, asks "why" not just "how"
- Next: Phase 0 wrap-up (editor panels orientation), then Phase 1 proper

### Session 4 — 2026-02-24
- Warm-up: correctly recalled Start vs Update and Time.deltaTime purpose
- Learned Rigidbody component (gravity, physics, mass)
- Added a Plane as a floor, cube falls and lands with physics
- Learned GetComponent<Rigidbody>() to reference components from code
- Learned FixedUpdate() for physics code (fixed timing vs frame-dependent)
- Learned Vector3 (bundling x, y, z into one direction)
- Replaced transform.Translate with rb.MovePosition (physics-based movement)
- Learned direction.normalized to fix diagonal speed being 1.4x faster
- Built movement as one Vector3 direction then applied once (cleaner than four Translate calls)
- Next: Colliders, triggers, collecting items, camera follow

### Session 5 — 2026-02-25
- Challenge: ArenaPlayer (full system from scratch, no reference)
- Built from memory: WASD physics movement, sprint/stamina, TakeDamage, Heal, death check
- Clean separation of sprint vs recovery logic
- Properly used GetKeyDown for one-time actions (Space, H)
- All systems stop when dead (isAlive checks in Update and FixedUpdate)
- Learned OnTriggerEnter: detects when objects overlap (trigger colliders)
- Learned CompareTag("Player") to filter what triggers the event
- Learned Destroy(gameObject) to remove objects at runtime
- Learned cross-script communication: GetComponent<ArenaPlayer>() from another script
- Learned public functions: needed for other scripts to call AddScore
- Created Collectible.cs: sphere items the player walks through to collect, score goes up
- Created CameraFollow.cs: camera follows player using Transform reference and Vector3 offset
- Learned public Transform target: drag objects into Inspector to link them
- Duplicated 7 spheres, all collected properly with score counting
- Next: Simple UI (score counter on screen), then solo rebuild of full game

### Session 6 — 2026-02-25
- Warm-up: correctly recalled Update vs FixedUpdate and cross-script communication with public functions
- Learned UI Canvas: Unity auto-creates Canvas + EventSystem when adding UI elements
- Learned TextMeshProUGUI: the type for referencing TMP text in code
- Learned `using TMPro;` import needed for TextMeshPro access
- Learned `.text` property to set displayed string on UI text
- Understood that UI updates belong where the value changes (AddScore), not in Update
- Added score counter to screen: public TextMeshProUGUI variable, drag in Inspector, update in AddScore
- **Solo Rebuild: rebuilt ALL three scripts from memory (ArenaPlayer, Collectible, CameraFollow)**
- Rebuilt cleanly: movement, sprint/stamina, health/damage/heal, collectibles, cross-script calls, camera follow, UI score
- Only needed two small corrections during rebuild (stamina recovery swap, walkSpeed placement)
- **Phase 1 COMPLETE**
- Next: Phase 2, "Platformer"

### Session 7 — 2026-02-25
- Created SimplePlatformer project (URP), set up clean scene
- Fixed VS Code IntelliSense issue with new project (Regenerate project files)
- Wrote PlayerController.cs from memory: Rigidbody, WASD movement, MovePosition, normalized
- Learned Rigidbody.AddForce with ForceMode.Impulse for jumping
- Learned Physics.Raycast for ground checking (prevent infinite jumps)
- Built 4 platforms at different heights for jumping between
- Created kill zone with invisible trigger collider below platforms
- Learned rb.linearVelocity = Vector3.zero to reset velocity on respawn
- Saved start position in Start() for respawn point
- Rebuilt Collectible + UI score system entirely from memory (no help needed)
- Rebuilt CameraFollow from memory
- Learned Mathf.PingPong for oscillating movement (moving platforms)
- Learned OnCollisionEnter/OnCollisionExit (solid collider events, Collision type)
- Solved moving platform carrying player: platform exposes public movement vector, player reads it in FixedUpdate and adds to MovePosition
- Fixed Update vs FixedUpdate timing mismatch (both scripts need same timing)
- Learned OnTriggerStay: fires every frame while inside a trigger (vs OnTriggerEnter which fires once)
- Built hazard system: gradual damage using damagePerSecond * Time.deltaTime
- Health resets to max on death, player respawns to start
- Next: Multiple levels / scene loading, sound effects, main menu

---

## Notes to Future Claude
- READ THIS FILE at the start of every session. Check "Current Status" and the last Session Log entry.
- Salah understands logic but is learning to type C#. ALWAYS explain in plain English first.
- He does NOT follow video tutorials. Claude is the primary teacher. Supplementary watching (Sebastian Lague, GMTK) is fine for understanding, not follow-along.
- He prefers to check code himself, don't ask him to show it. Just read the file.
- He doesn't like being asked if he wants to stop or take a break. He'll stop when he says so.
- Never use em dashes. Use commas, periods, colons, or restructure sentences.
- Never mention Claude in commit messages. No Co-Authored-By, no AI references.
- Let him TRY first, then correct. Never dump full scripts.
- When he asks to check his code, just read the file yourself.
- VS Code auto-adds unused imports sometimes, don't nag about it every time.
- Update this file at the END of every session.
- Spawn research teams when investigating new topics, not for routine teaching.

## Current Scripts in Project (SimplePlatformer)
- **PlayerController.cs** (on Cube): WASD physics movement, jumping with AddForce, ground check with Raycast, kill zone respawn, health system with gradual hazard damage (OnTriggerStay), score with UI text. Has public AddScore(int).
- **Collectible.cs** (on Spheres): OnTriggerEnter, CompareTag("Player"), calls AddScore on PlayerController, destroys self.
- **CameraFollow.cs** (on Main Camera): Follows player Transform with Vector3 offset.
- **MovingPlatform.cs** (on moving platforms): PingPong movement with public offset/speed, exposes movement vector for player to read.
- Scene has: Cube (player, tagged "Player"), 4 platforms, moving platform (tagged "MovingPlatform"), collectible spheres, kill zone (tagged "KillZone", invisible trigger below), hazard (tagged "Hazard", trigger collider), Canvas with TMP score text.

## Previous Project Scripts (TheMovingCube)
- ArenaPlayer.cs, Collectible.cs, CameraFollow.cs (Phase 1, complete)
