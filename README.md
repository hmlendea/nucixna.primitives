[![Donate](https://img.shields.io/badge/-%E2%99%A5%20Donate-%23ff69b4)](https://hmlendea.go.ro/funding)
[![Latest Release](https://img.shields.io/github/v/release/hmlendea/nucixna.primitives)](https://github.com/hmlendea/nucixna.primitives/releases/latest)
[![Build Status](https://github.com/hmlendea/nucixna.primitives/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hmlendea/nucixna.primitives/actions/workflows/dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/NuciXNA.Primitives)](https://nuget.org/packages/NuciXNA.Primitives)
[![License](https://img.shields.io/github/license/hmlendea/nucixna.primitives)](https://github.com/hmlendea/nucixna.primitives/blob/master/LICENSE)

# NuciXNA.Primitives

NuciXNA.Primitives is a .NET library that provides reusable geometry, size, scale, vector, rectangle, and colour types for projects built on top of MonoGame/XNA.

It sits between application code, `System.Drawing`, and MonoGame primitives so you can keep your own domain-friendly types while still converting to framework types when needed.

## 📑 Table of Contents

- [Capabilities](#capabilities)
- [Usage](#usage)
- [Installation](#installation)
- [Compatibility](#compatibility)
- [Privacy and Data](#privacy-and-data)
- [Development](#development)
- [GitHub Actions](#github-actions)
- [Project Structure](#project-structure)
- [Architecture](#architecture)
- [Related Projects](#related-projects)
- [Acknowledgements](#acknowledgements)
- [Contributing](#contributing)
- [Security](#security)
- [Project Engagement](#project-engagement)
- [License](#license)

## ✨ Capabilities

- **Geometry primitives** — Integer and floating-point point types for 2D and 3D coordinates (`Point2D`, `PointF2D`, `Point3D`, `PointF3D`) with equality, arithmetic operators, and implicit conversions to `System.Drawing` types.
- **Sizes and scaling** — Integer and floating-point size types (`Size2D`, `SizeF2D`) and `Scale2D` with arithmetic operations and helpers such as `Area`, `Perimeter`, `Empty`, `Zero`, and `One`.
- **Rectangles and vectors** — `Rectangle2D` with convenience members (`TopLeft`, `BottomRight`, `Centre`, `Contains`, `Location`, `Size`); `Vector2D` and `Vector3D` wrappers around MonoGame-style vector concepts.
- **Colour handling** — `Colour` with predefined named colours, ARGB integer and hexadecimal string conversion, and bidirectional mapping to `System.Drawing.Color` and `Microsoft.Xna.Framework.Color`.
- **Mapping extensions** — Extension methods in `NuciXNA.Primitives.Mapping` for converting between NuciXNA primitives, `System.Drawing`, and `Microsoft.Xna.Framework` types (points, rectangles, colours, vectors, sizes, scales).

## 🚀 Usage

### Work with geometry primitives

```csharp
using NuciXNA.Primitives;

Point2D position = new(32, 48);
Size2D size = new(128, 64);
Rectangle2D bounds = new(position, size);

bool containsOrigin = bounds.Contains(Point2D.Empty);
Point2D centre = bounds.Centre;
Size2D doubled = size * 2;
```

### Scale a size

```csharp
using NuciXNA.Primitives;

Size2D baseSize = new(1920, 1080);
Scale2D scale = new(0.5f, 0.5f);

Size2D scaled = baseSize * scale;
```

### Convert colours

```csharp
using NuciXNA.Primitives;

Colour accent = Colour.FromHexadecimal("#1E90FF");
int argb = accent.ToArgb();
string hex = accent.ToHexadecimal();

Colour fromArgb = Colour.FromArgb(argb);
Colour transparentBlack = Colour.Transparent;
```

### Map between custom, System.Drawing, and MonoGame types

```csharp
using System.Drawing;
using Microsoft.Xna.Framework;
using NuciXNA.Primitives;
using NuciXNA.Primitives.Mapping;

Point drawingPoint = new(10, 20);
Point2D point = drawingPoint.ToPoint2D();

Vector2 xnaVector = point.ToXnaVector2();
Color drawingColor = Colour.CornflowerBlue.ToSystemColor();
Microsoft.Xna.Framework.Color xnaColor = drawingColor.ToXnaColor();
```

## 📦 Installation

[![Obtain it from NuGet](https://raw.githubusercontent.com/hmlendea/readme-assets/master/badges/stores/nuget.png)](https://nuget.org/packages/NuciXNA.Primitives)

```bash
dotnet add package NuciXNA.Primitives
```

Or, via the `Package Manager Console`:

```powershell
Install-Package NuciXNA.Primitives
```

## 🧩 Compatibility

| Component | Supported Versions | Notes |
|-----------|--------------------|-------|
| .NET | `net10.0` | Target framework |
| MonoGame.Framework.DesktopGL | `3.8.4` | Required for `Microsoft.Xna.Framework` types used in mapping extensions |
| System.Drawing.Common | Built-in | Used for `System.Drawing` type mappings |

## 🛡️ Privacy and Data

NuciXNA.Primitives does not collect, process, transmit, or persist any personal data, analytics, diagnostics, or telemetry. The library performs only in-memory computations on geometry, size, scale, vector, rectangle, and colour values.

For the detailed description of how the library handles privacy and personal data, see [PRIVACY.md](./PRIVACY.md).

## 🛠️ Development

### Requirements

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Setup

```bash
# Clone the repository
git clone https://github.com/hmlendea/nucixna.primitives.git
cd nucixna.primitives

# Restore dependencies
dotnet restore NuciXNA.sln
```

### Build

```bash
dotnet build NuciXNA.sln --configuration Release --no-restore
```

### Test

```bash
dotnet test NuciXNA.sln --configuration Release --no-build
```

## ⚙️ GitHub Actions

| Workflow | Purpose | What it does |
|----------|---------|--------------|
| [ dotnet.yml ](https://github.com/hmlendea/nucixna.primitives/blob/master/.github/workflows/dotnet.yml) | Continuous integration | Restores, builds, and tests on every push and pull request to `master` |
| [ nuget-release.yml ](https://github.com/hmlendea/nucixna.primitives/blob/master/.github/workflows/nuget-release.yml) | NuGet.org release | Packs and publishes the NuGet package on GitHub release publication using OIDC |
| [ github-release.yml ](https://github.com/hmlendea/nucixna.primitives/blob/master/.github/workflows/github-release.yml) | GitHub Release | Packs the NuGet package, calculates SHA256, and uploads to the GitHub Release |

## 🗂️ Project Structure

### Projects and Packages

| Project | Type | Purpose |
|---------|------|---------|
| `NuciXNA.Primitives` | Class library | Core geometry, size, scale, vector, rectangle, and colour primitives |
| `NuciXNA.Primitives.UnitTests` | Test project | Unit tests for all primitive types and mapping extensions |

### Directories

| Directory | Purpose |
|-----------|---------|
| `NuciXNA.Primitives/Mapping` | Mapping extension methods for `System.Drawing` and `Microsoft.Xna.Framework` interop |
| `NuciXNA.Primitives.UnitTests/Mapping` | Unit tests for mapping extensions |

## 🏗️ Architecture

NuciXNA.Primitives is a .NET class library providing domain-friendly geometry and colour primitives for MonoGame/XNA applications. It sits between application code, `System.Drawing`, and MonoGame primitives, enabling developers to keep their own types while converting to framework types when needed. The library targets `net10.0` and is distributed as a NuGet package.

See the [architecture documentation](./ARCHITECTURE.md) for the system context, principal components, runtime flows, ownership boundaries, dependencies, constraints, and extension points.

## 🔗 Related Projects

- [NuciXNA.DataAccess](https://github.com/hmlendea/nucixna.dataaccess): Data access layer for NuciXNA projects
- [NuciXNA.Graphics](https://github.com/hmlendea/nucixna.graphics): Graphics utilities and rendering helpers
- [NuciXNA.GUI](https://github.com/hmlendea/nucixna.gui): GUI framework for MonoGame
- [NuciXNA.Input](https://github.com/hmlendea/nucixna.input): Input handling for MonoGame

## 🙏 Acknowledgements

- [MonoGame](https://www.monogame.net/) — The XNA-inspired framework this library integrates with
- [System.Drawing.Common](https://learn.microsoft.com/en-us/dotnet/api/system.drawing) — For cross-platform drawing primitives

## 🤝 Contributing

You are welcome to submit any suggestion, feedback, or modification to this project.

When doing so, please:
- Maintain cross-platform compatibility
- Preserve the existing public contract unless a breaking change is intentional
- Submit focused pull requests that conform to the existing code style
- Maintain your branch synchronised with `master`
- Revise the documentation when functionality changes
- Properly test all modifications, including edge cases and error conditions
- Add tests for additional or modified functionality
- Raise a new [issue](https://github.com/hmlendea/nucixna.primitives/issues) for problems or suggestions

See the [contributing guidelines](./CONTRIBUTING.md) for details on how to report issues, suggest enhancements, and submit changes.

## 🔒 Security

NuciXNA.Primitives follows coordinated disclosure for security vulnerabilities.

For information on reporting security vulnerabilities, see [SECURITY.md](./SECURITY.md).

## 💝 Project Engagement

Discovered a problem or have a suggestion? [Open an issue](https://github.com/hmlendea/nucixna.primitives/issues)!

If you find this project useful, consider [funding it](https://hmlendea.go.ro/funding) or starring ⭐️ it on GitHub!

[![Donate](https://raw.githubusercontent.com/hmlendea/readme-assets/master/donate_generic.png)](https://hmlendea.go.ro/funding)

## 📄 License

This project is being distributed under the `GNU General Public License v3.0` or later.
See [LICENSE](./LICENSE) for further information.
