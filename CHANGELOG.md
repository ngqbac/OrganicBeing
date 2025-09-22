# Changelog

## [1.2.0] - 2025-09-22

### ✨ Features

- Added **UniTask async support**:
  - `WhenReadyAsync()` extension methods using UniTask
  - Overloads for `Func<T>` and `Action`
- UniTask integration is **optional** using `versionDefines` and separate asmdef
- Improved developer ergonomics and IDE support with simplified structure

### 🔧 Improvements

- Split async support into `Integration/UniTask/OrganicAsync.cs`
- Refined `.asmdef` setup to reduce coupling
- Improved pool and lifecycle stability in edge cases
- Updated documentation and examples

### 🐛 Fixes

- Fixed incorrect or missing references causing IDE errors
- Prevented UniTask references from compiling if not installed
- Corrected inconsistent namespace usage across folders

---

## [1.1.1] - 2025-09-21
- Implemented Auto Tag on Version Change

## [1.1.0] - 2025-09-21

### ⚙️ Structure & Organization

- Restructured package folder layout into clear namespaces:
  - `OrganicBeing.Core` for core lifecycle components.
  - `OrganicBeing.Data` for generic data containers.
  - `OrganicBeing.Pooling` for pooling utilities.
  - `OrganicBeing.Integration` for MonoBehaviour support.
  - `OrganicBeing.Editor` for editor extensions.

### ✨ Features

- Added `IOrganicHost<T>`: interface for organic objects with data.
- Introduced `OrganicHost<T>` and `MonoOrganicHost<T>`:
  - `OrganicHost<T>` is a data-aware `OrganicObject<T>`.
  - `MonoOrganicHost<T>` combines `MonoBehaviour` with `OrganicHost<T>` behavior.
- Added `Absorb(T data)` method to set data organically (instead of `SetData`).
- Introduced `OrganicObject<T>` and `MonoOrganic<T>` for combining organic lifecycle with data.
- Added `OrganicPool.GetWithData(data)` API for spawning pooled objects with initial data.

### 🧪 Utilities

- Added `OrganicConfig` asset (ScriptableObject) with:
  - `DefaultMaxPoolSize`
  - `EOrganicLogLevel` enum with `[Flags]` support (Info, Warning, Error)

### 🧩 Integration

- Provided examples for both composition (`IOrganicHost<T>`) and inheritance (`MonoOrganic<T>`) patterns.
- Updated `README.md` with new usage sections, API reference, installation instructions, and setup.

### 🧼 Cleanup

- Split interfaces (`IOrganic`, `IOrganicHost<T>`) into separate files for clarity.
- Improved naming consistency: e.g., `MonoOrganicHost`, `OrganicPool`, `Absorb` method, etc.
- Removed dependency on GUID-based assembly definition references.

---

## [1.0.0] - Initial Release

- Introduced the core `OrganicObject` lifecycle system: `Grow`, `IsReady`, `WhenReady`, `OnRecycle`
- Added `OrganicPool<T>` for reusable object pooling.
- Provided `OrganicConfig` with editable pooling and log level settings.
- Initial MonoBehaviour-compatible base class `MonoOrganic`.
- Created minimal usage examples and a basic README.
