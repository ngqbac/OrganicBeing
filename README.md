[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE) [![Latest Version](https://img.shields.io/github/v/tag/ngqbac/OrganicBeing)](https://github.com/ngqbac/OrganicBeing) [![Unity Version](https://img.shields.io/badge/Unity-2022.3%20LTS-blue)](https://unity.com/releases/2022-3)  

---
# Overview

OrganicBeing is a Unity package that enables:

- self‑aware objects via lifecycle (`Grow`, `IsReady`, `OnRecycle`)  
- safe execution of code only when ready (`WhenReady()`)  
- object pooling with configurable limits to manage memory  
- flexible logging via flag‑based log levels  

Ideal for gameplay systems, reusable logic, and efficient runtime objects.

---

# Installation

## 1. Install via Git URL (Recommended)

<details>
### Option A — Add to manifest.json

Open `Packages/manifest.json` and add:

```json
"com.bacnq.organicbeing": "https://github.com/yourusername/OrganicBeing.git"
```

</details>

<details>
### Option B — Use Unity Package Manager UI

1. In Unity Editor, go to **Window → Package Manager**  
2. Click the **+** (plus) button → **Add package from Git URL...**  
3. Paste:

   ```
   https://github.com/yourusername/OrganicBeing.git
   ```

4. Click **Add**

</details>

---

# Setup & Configuration

1. After installing, create the configuration asset:  
**Tools → OrganicBeing → Create Config Asset**  
   This will generate `Assets/Resources/OrganicConfig.asset`.

2. Open `OrganicConfig` in Inspector to adjust:  
   - `DefaultMaxPoolSize` — max objects held per pool  
   - `LogLevelFlags` — which log types are enabled (Info, Warning, Error)

---

# Usage Example

## Creating a Reusable OrganicObject

```csharp
using OrganicBeing;

public class MyReusable : OrganicObject
{
    protected override void OnGrow()
    {
        // Initialization logic
    }

    public override void OnRecycle()
    {
        // Reset state here
    }
}
```

## Using the Pool in MonoBehaviour

```csharp
var pool = new OrganicPool<MyReusable>();

var obj = pool.Get();
obj.WhenReady(() => {
    // Safe to use
});
pool.Return(obj);
```

---

# API Reference

| Class / Interface       | Key Methods / Properties                             |
|-------------------------|------------------------------------------------------|
| `OrganicObject`         | `Grow()`, `IsReady`, `WhenReady(...)`, `OnRecycle()` |
| `OrganicPool<T>`        | `Get()`, `Return()`, uses `OrganicSettings.MaxPoolSize` |
| `OrganicSettings`       | `MaxPoolSize`, `LogLevel` from `OrganicConfig`      |
| `OrganicLog`            | `Info()`, `Warn()`, `Error()`, controlled by flags   |

---

# Contributing

Contributions are welcome! Feel free to open issues or pull requests.  
Please follow code style, add tests where needed, and update README for any new feature.

---