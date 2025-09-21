[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE) [![Latest Version](https://img.shields.io/github/v/tag/ngqbac/OrganicBeing)](https://github.com/ngqbac/OrganicBeing) [![Unity Version](https://img.shields.io/badge/Unity-2022.3%20LTS-blue)](https://unity.com/releases/2022-3)

---

# OrganicBeing

**OrganicBeing** is a Unity package designed for lifecycle-driven, memory-efficient game objects that can grow, recycle, and integrate into object pools—perfect for gameplay logic and reusable systems.

---

## ✨ Features

- `Grow()` and `WhenReady()` lifecycle for lazy initialization
- `OnRecycle()` for cleanup and reuse
- Generic `OrganicHost<T>` and `MonoOrganicHost<T>` for data-bound logic
- Seamless **MonoBehaviour** integration with composition or inheritance
- Configurable `OrganicPool<T>` with pooling limits
- Logging via flag-based log levels
- Clean folder-based architecture (Core, Integration, Utilities, Editor)

---

## 📦 Installation

### Option A — Add to `manifest.json`

<details>
<summary>Click to expand</summary>

```json
{
  "dependencies": {
    "com.bacnq.organicbeing": "https://github.com/ngqbac/OrganicBeing.git"
  }
}
```

</details>

### Option B — Unity Package Manager (UPM)

<details>
<summary>Click to expand</summary>

1. In Unity: **Window → Package Manager**  
2. Click **+** → **Add package from Git URL**  
3. Paste:

   ```
   https://github.com/ngqbac/OrganicBeing.git
   ```

</details>

---

## ⚙️ Setup & Configuration

1. After installation, create the config asset:  
   **Tools → OrganicBeing → Create Config Asset**

2. This generates `Assets/Resources/OrganicConfig.asset`, where you can adjust:
   - `DefaultMaxPoolSize`
   - `LogLevelFlags`

---

## 🚀 Usage

### Create a Reusable OrganicObject

```csharp
public class EnemyLogic : OrganicObject
{
    protected override void OnGrow() { /* Init logic */ }

    public override void OnRecycle() { /* Cleanup */ }
}
```

### Use with Pool

```csharp
var pool = new OrganicPool<EnemyLogic>();
var logic = pool.Get();
logic.WhenReady(() => Debug.Log("Ready!"));
pool.Return(logic);
```

---

## 🧠 MonoBehaviour Integration

### Option A — Composition (Recommended)

```csharp
public class Enemy : MonoBehaviour, IOrganicHost<EnemyLogic>
{
    public EnemyLogic Organic => _logic ??= new EnemyLogic();
    private EnemyLogic _logic;

    void Start()
    {
        Organic.Grow();
        Organic.WhenReady(() => Debug.Log("Initialized!"));
    }

    void OnDestroy() => Organic.OnRecycle();
}
```

### Option B — Inheritance

```csharp
public class Enemy : MonoOrganicHost<EnemyData>
{
    protected override void OnGrow() { /* Init */ }

    protected override void OnAbsorb() => Debug.Log(Data.id);

    public override void OnRecycle() { /* Clean */ }
}
```

---

## 🧪 Advanced: OrganicObject with Data

```csharp
public class GemData
{
    public string id;
    public int level;
}

public class OrganicGem : OrganicHost<GemData>
{
    protected override void OnGrow() { /* Init */ }

    protected override void OnAbsorb() => Debug.Log(Data.id);

    public override void OnRecycle() { /* Cleanup */ }
}
```

---

## 📚 API Reference

| Component                 | Description                                           |
|--------------------------|-------------------------------------------------------|
| `OrganicObject`          | Core lifecycle class (`Grow`, `OnRecycle`)            |
| `OrganicHost<T>`         | Generic with data handling (`Absorb`, `Data`)         |
| `MonoOrganic`            | MonoBehaviour wrapper for OrganicObject               |
| `MonoOrganicHost<T>`     | MonoBehaviour + Data + Organic lifecycle              |
| `OrganicPool<T>`         | Pooled management, supports prefab spawning           |
| `OrganicSettings`        | Access config values from anywhere                    |
| `OrganicLog`             | Flag-driven log helper (`Info`, `Warn`, `Error`)      |
| `OrganicConfig`          | ScriptableObject to set pool size and log levels      |
| `IOrganic`, `IOrganicHost<T>` | Interfaces for lifecycle and data integration      |

---

## 🗂 Folder Structure & Namespaces

| Folder         | Namespace              | Purpose                              |
|----------------|------------------------|--------------------------------------|
| `Core`         | `OrganicBeing.Core`    | Core lifecycle, interfaces, pooling  |
| `Integration`  | `OrganicBeing.Integration` | MonoBehaviour integration         |
| `Utilities`    | `OrganicBeing.Utilities` | Logging, config, settings           |
| `Editor`       | `OrganicBeing.Editor`  | Editor-only menu and config tools    |

---

## 🧩 Assembly Definitions

| Assembly                 | Description                          |
|--------------------------|--------------------------------------|
| `OrganicBeing`           | Core runtime logic                   |
| `OrganicBeing.Editor`    | Unity editor integration             |

---

## 🤝 Contributing

Pull requests are welcome! Please:

- Follow the project's C# coding style
- Add appropriate tests and examples
- Update the documentation if needed

---

## 📝 License

This project is licensed under the [MIT License](LICENSE).