# C# / Unity Quick Reference

Things that are easy to forget. Not everything you learn, just the tricky stuff.

---

## Unity Script Basics

**MonoBehaviour**: Add `: MonoBehaviour` after your class name to make it a Unity script. Without it, Unity can't attach the script to a game object or run it.
```csharp
public class MyScript : MonoBehaviour
```

**Start()**: Runs once when the game starts (or when the object first appears). Use it to set things up.
```csharp
void Start()
{
    // runs once
}
```

**using UnityEngine;**: Must be at the top of every Unity script. Gives you access to all Unity tools (Debug, Transform, etc).

---

## Type Conversion

- `float` can hold an `int` value (big box fits small box)
- `int` cannot hold a `float` without forcing it: `int x = (int)myFloat;` (loses the decimal part)
- The `f` after a decimal number (`5.5f`) is only for writing code. It doesn't show in output.

---

## Update Loop

**Update()**: Runs every frame (60+ times per second). Put continuous gameplay logic here (movement, input, rotation).

**Time.deltaTime**: Multiply any movement/rotation by this in Update(). Makes speed frame-independent (same on all computers).
```csharp
transform.Rotate(0, speed * Time.deltaTime, 0);
```
Without it: speed depends on FPS (bad). With it: speed is per second (good).

---

## Inspector

**public variables**: Show up in the Inspector. You can tweak them in real time during Play Mode.

**Play Mode warning**: Any changes made in the Inspector during Play Mode reset when you stop. Set a Play Mode tint color so you always know.

---

## Rigidbody & Physics

**Rigidbody**: Add this component to a game object to give it physics (gravity, collisions, mass). Add via Inspector > Add Component > Rigidbody.

**GetComponent**: Grabs a reference to another component on the same game object. Declare at class level, assign in Start:
```csharp
Rigidbody rb;
void Start()
{
    rb = GetComponent<Rigidbody>();
}
```

**FixedUpdate()**: Like Update but runs at fixed intervals. All physics code goes here, not in Update.
- Use `Time.fixedDeltaTime` instead of `Time.deltaTime` inside FixedUpdate.

**rb.MovePosition**: Moves a Rigidbody through the physics system (respects collisions). Better than transform.Translate for physics objects.
```csharp
rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
```

---

## Vector3

**Vector3**: Three numbers bundled together (x, y, z). Used for positions, directions, and movement.
- `Vector3.zero` = (0, 0, 0)
- `direction.normalized` = same direction but length of exactly 1 (fixes diagonal speed being faster)

---

## Colliders & Triggers

**Collider**: Invisible shape that defines an object's physical boundary. Box Collider, Sphere Collider, etc. Solid by default.

**Trigger**: A collider with "Is Trigger" checked. Not solid. Objects pass through it, but Unity tells your script something entered.

**OnTriggerEnter**: Unity calls this automatically when something enters a trigger:
```csharp
void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Destroy(gameObject);
    }
}
```

**OnTriggerStay**: Same as OnTriggerEnter, but fires **every frame** while the object stays inside the trigger. Used for gradual effects like hazard damage:
```csharp
void OnTriggerStay(Collider other)
{
    if (other.CompareTag("Player"))
    {
        TakeDamage(damagePerSecond * Time.deltaTime);
    }
}
```

**CompareTag("TagName")**: Check what entered. Set tags on objects via Inspector > Tag dropdown.

**Destroy(gameObject)**: Removes the object this script is attached to.

---

## Cross-Script Communication

To call a function on another object's script:
```csharp
ArenaPlayer player = other.GetComponent<ArenaPlayer>();
player.AddScore(1);
```
The function must be `public` to be visible from other scripts.

---

## Camera Follow

Use a `public Transform target` variable. Drag the object into the Inspector. Access its position with `target.position`.
```csharp
transform.position = target.position + offset;
```

---

## UI Text (TextMeshPro)

**Canvas**: Container for all UI elements. Created automatically when you add a UI element (right-click Hierarchy > UI > Text - TextMeshPro).

**TextMeshProUGUI**: The type for referencing a TMP text element in code. Needs `using TMPro;` at the top of the script.
```csharp
using TMPro;

public TextMeshProUGUI ui;

ui.text = "Score: " + score;
```
Drag the Text object into the public field in the Inspector (same as CameraFollow target).

Update the text only where the value changes, not every frame in Update.

---

## Jumping (AddForce)

**rb.AddForce**: Pushes a Rigidbody in a direction. Unlike MovePosition (which carries), AddForce kicks and lets physics take over.
```csharp
rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
```
- `Vector3.up` = (0, 1, 0), straight up
- `ForceMode.Impulse` = all force applied instantly (one frame). Default mode applies gradually.
- Jump input goes in **Update** (not FixedUpdate), because GetKeyDown can miss presses in FixedUpdate.

---

## Raycasting (Ground Check)

**Physics.Raycast**: Shoots an invisible ray and returns true if it hits something.
```csharp
if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
{
    isGrounded = true;
}
```
- Parameters: origin, direction, distance
- For a ground check: shoot down from player center. Distance = slightly more than half the object height (0.6f for a 1-unit cube).

---

## Collision Events (Solid Objects)

For solid colliders (not triggers), use `Collision` instead of `Collider`:
```csharp
void OnCollisionEnter(Collision other)  // first frame of contact
void OnCollisionExit(Collision other)   // frame contact ends
void OnCollisionStay(Collision other)   // every frame while touching
```
- Access tag: `other.gameObject.CompareTag("TagName")`
- Access transform: `other.transform`

---

## Mathf.PingPong (Oscillating Movement)

Bounces a value back and forth between 0 and a max:
```csharp
float value = Mathf.PingPong(Time.time * speed, maxDistance);
```
- `Time.time` keeps counting up forever. Multiply by speed to go faster.
- Output: 0 > max > 0 > max, repeating smoothly.

---

## Resetting Velocity

When teleporting a Rigidbody (respawn), reset velocity so it doesn't keep falling:
```csharp
rb.linearVelocity = Vector3.zero;
transform.position = startLocation;
```

---

## Scene Loading

**SceneManager.LoadScene**: Loads a new scene, replacing everything. Needs `using UnityEngine.SceneManagement;`.
```csharp
SceneManager.LoadScene("Level2");
```
- Scenes must be added to **Build Settings > Scene List** first.
- Scene at index 0 loads on game start.
- Use a `public string nextLevel` to make it reusable per level.

---

## Audio

**AudioSource**: Component that plays sounds. Add to GameObject, uncheck "Play On Awake".
```csharp
AudioSource audioSource;
public AudioClip jumpSound;

void Start()
{
    audioSource = GetComponent<AudioSource>();
}

audioSource.PlayOneShot(jumpSound);
```
- `PlayOneShot(clip)`: plays a clip once without interrupting others.
- `audioSource.isPlaying`: check if something is already playing (prevents sound spam in OnTriggerStay).
- Don't name your variable `audio` (conflicts with a deprecated Unity name). Use `audioSource`.

---

## UI Buttons

Create: right-click Hierarchy > UI > Button - TextMeshPro.

Hook up in Inspector: Button component > OnClick > drag the object with your script > select the public function.

The function must be `public void` with no parameters (or one basic parameter like string/int).

---

## Input (GetKey vs GetKeyDown)

**Input.GetKey(KeyCode.W)**: Returns true **every frame** the key is held down. Use for continuous actions like movement.

**Input.GetKeyDown(KeyCode.Space)**: Returns true **only the first frame** the key is pressed. Use for one-time actions like jumping or shooting.
```csharp
// Held down = continuous
if (Input.GetKey(KeyCode.W)) { direction.z += 1; }

// Pressed once = one-time
if (Input.GetKeyDown(KeyCode.Space)) { Jump(); }
```

---

## LateUpdate

**LateUpdate()**: Runs every frame, but **after** all Update() calls have finished. Use for camera follow, so the camera moves after the player has moved.
```csharp
void LateUpdate()
{
    transform.position = target.position + offset;
}
```
Order each frame: FixedUpdate (physics) > Update (gameplay) > LateUpdate (camera).

---

## String Interpolation

Instead of concatenating strings with `+`, use `$` before the string and `{}` around variables:
```csharp
// Old way
healthText.text = "Health: " + currentHealth + "/" + maxHealth;

// Better way
healthText.text = $"Health: {currentHealth}/{maxHealth}";
```

---

## Shorthand Operators

```csharp
currentHealth -= damage;    // same as: currentHealth = currentHealth - damage
score += 1;                 // same as: score = score + 1
speed *= 2;                 // same as: speed = speed * 2
```

---

## Vector3.MoveTowards

Moves a position toward a target at a given speed. Stops exactly at the target (won't overshoot).
```csharp
transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
```
- Parameters: current position, target position, max distance to move this frame.
- Alternative to Mathf.PingPong for moving platforms. More flexible since you pick exact start/end points.

---

## Ternary Operator

A one-line if/else. Returns one of two values based on a condition:
```csharp
target = (target == pointA) ? pointB : pointA;

// Same as:
if (target == pointA) { target = pointB; }
else { target = pointA; }
```

---

## Null Checks

Before using a component reference, check if it's not null to avoid NullReferenceException:
```csharp
if (audioSource != null && clip != null)
{
    audioSource.PlayOneShot(clip);
}
```
Especially useful for optional Inspector fields (like UI text that might not be assigned in every scene).

---

## Arrays

Fixed-size collection of values. Declare with a type and size:
```csharp
int[] scores = new int[3];
scores[0] = 10;
scores[1] = 20;
Debug.Log(scores[0]);    // 10
Debug.Log(scores.Length); // 3
```
- Index starts at 0. An array of size 3 has indices 0, 1, 2.
- Size is fixed. Can't add or remove after creation.

---

## Lists

Like arrays but they **grow and shrink**. Need `using System.Collections.Generic;`.
```csharp
List<string> items = new List<string>();
items.Add("Sword");       // adds to end
items.Remove("Sword");    // finds and removes it
items.Count               // how many items
items[0]                  // access by index
```
- When you remove an item, everything after it slides down (indices change).
- Use Lists over arrays when the size changes at runtime (enemies, inventory, etc.).

---

## For Loops

Repeats code a set number of times:
```csharp
for (int i = 0; i < 5; i++)
{
    Debug.Log(i);  // prints 0, 1, 2, 3, 4
}
```
- `int i = 0` — counter starts at 0
- `i < 5` — keep going while true
- `i++` — add 1 after each loop (same as `i += 1`)

---

## Prefabs and Instantiate

**Prefab**: A saved template of a GameObject. Drag an object from the Hierarchy into the Project folder to create one. Delete the original from the scene.

**Instantiate**: Creates a copy of a prefab at runtime:
```csharp
public GameObject enemyPrefab;
GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
```
- Returns the new GameObject so you can store it and modify it.
- `Quaternion.identity` = no rotation.
- After spawning, set references from code (prefabs can't reference scene objects):
```csharp
enemy.GetComponent<EnemyFollow>().target = playerTransform;
```

---

## Spawn Timer Pattern

Spawn things over time instead of all at once:
```csharp
float timer = 0f;
public float spawnInterval = 3f;

void Update()
{
    timer += Time.deltaTime;
    if (timer >= spawnInterval)
    {
        // spawn something
        timer = 0f;
    }
}
```

---

## Random.Range

Picks a random number between min and max:
```csharp
float x = Random.Range(-8f, 8f);   // float version: includes both ends
int num = Random.Range(0, 10);      // int version: includes min, EXCLUDES max (0-9)
```

---

## Enums

A custom type with a fixed set of named options. Prevents typos and makes code readable:
```csharp
enum EnemyState
{
    Idle,
    Patrol,
    Chase,
    Attack
}

EnemyState currentState = EnemyState.Idle;
```
- Can only be set to one of the defined values. Anything else won't compile.
- Define inside or outside your class.

---

## Switch Statements

Run different code based on a value. Cleaner than multiple if/else for enums:
```csharp
switch (currentState)
{
    case EnemyState.Idle:
        // stand still
        break;
    case EnemyState.Chase:
        // move toward player
        break;
}
```
- Each `case` handles one value.
- `break` stops it from falling into the next case.

---

## Vector3.Distance

Returns the distance between two points as a float:
```csharp
float dist = Vector3.Distance(transform.position, target.position);
if (dist <= detectionRange)
{
    // player is close enough
}
```

---

*Add new entries as you learn them. Keep it short.*
