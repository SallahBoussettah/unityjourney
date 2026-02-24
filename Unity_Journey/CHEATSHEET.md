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

*Add new entries as you learn them. Keep it short.*
