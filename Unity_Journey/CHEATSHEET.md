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

*Add new entries as you learn them. Keep it short.*
