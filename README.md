# OrganicBeing

[![Latest Version](https://img.shields.io/github/v/tag/ngqbac/OrganicBeing)](https://github.com/ngqbac/OrganicBeing)

**OrganicBeing** is a lightweight, self-initializing object lifecycle and pooling system for Unity. Designed for clean architecture, composability, and async-friendly flows using both Unity Task and [UniTask](https://github.com/Cysharp/UniTask) when available.

---

## Features

-  **Self-Aware Object Lifecycle**: `IOrganic` interface with `Grow`, `Wither`, and `IsReady` for lifecycle management.

- **Automatic Pooling**: Organic objects are pooled by default to reduce GC overhead.

- **Composable Behaviors**: Use `IOrganicAddon` to add modular behaviors or traits.

- **Async Readiness API**: Use `OrganicAsync.WhenReadyAsync()` to await readiness (supports `UniTask` if installed).

- **Minimal Dependencies**: UniTask integration is optional using `versionDefines`.

---

## Installation

Add this to your `manifest.json`:

```json
"com.bacnq.organicbeing": "https://github.com/ngqbac/OrganicBeing.git"
```

If you want to use async readiness methods (`OrganicAsync`) with UniTask, also add:

```json
"com.cysharp.unitask": "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask"
```
---

## 🧩 Dependencies

- Unity 2022.3+
- [Optional] [UniTask](https://github.com/Cysharp/UniTask)

---

## 🤝 Contributing

Pull requests are welcome! Please:
- Follow the project's C# coding style
- Add appropriate tests and examples
- Update the documentation if needed

---

## 📜 License

MIT © [ngqbac](https://github.com/ngqbac)