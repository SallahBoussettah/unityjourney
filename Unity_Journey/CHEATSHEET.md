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

*Add new entries as you learn them. Keep it short.*
