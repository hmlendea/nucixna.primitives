[![Donate](https://img.shields.io/badge/-%E2%99%A5%20Donate-%23ff69b4)](https://hmlendea.go.ro/fund.html) [![Latest Release](https://img.shields.io/github/v/release/hmlendea/nucixna.primitives)](https://github.com/hmlendea/nucixna.primitives/releases/latest) [![Build Status](https://github.com/hmlendea/nucixna.primitives/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hmlendea/nucixna.primitives/actions/workflows/dotnet.yml)

# NuciXNA.Primitives

NuciXNA.Primitives is a small .NET library that provides reusable geometry, size, scale, vector, rectangle, and colour types for projects built on top of MonoGame/XNA.

It sits between application code, `System.Drawing`, and MonoGame primitives so you can keep your own domain-friendly types while still converting to framework types when needed.

## What It Includes

- Colour handling through `Colour`, including predefined colours and ARGB / hexadecimal conversion helpers.
- Integer and floating-point point types for 2D and 3D coordinates.
- Integer and floating-point size types.
- A `Rectangle2D` type with convenience properties such as corners, centre, containment checks, location, and size.
- `Scale2D` for UI or layout scaling.
- `Vector2D` and `Vector3D` wrappers around MonoGame-style vector concepts.
- Mapping extensions for converting between NuciXNA primitives, `System.Drawing`, and `Microsoft.Xna.Framework` types.

## Installation

### .NET CLI

```bash
dotnet add package NuciXNA.Primitives
```

### Package Manager

```powershell
Install-Package NuciXNA.Primitives
```

## Target Framework

The project currently targets `net10.0`.

## Core Types

### Coordinates and points

- `Point2D`
- `PointF2D`
- `Point3D`
- `PointF3D`

These types support equality and arithmetic operators, and several of them provide implicit conversions to and from `System.Drawing` types.

### Sizes and scaling

- `Size2D`
- `SizeF2D`
- `Scale2D`

These types support arithmetic operations and common helpers such as `Area`, `Perimeter`, `Empty`, `Zero`, and `One` where applicable.

### Rectangles and vectors

- `Rectangle2D`
- `Vector2D`
- `Vector3D`

`Rectangle2D` includes convenience members such as `TopLeft`, `BottomRight`, `Centre`, `Contains`, `Location`, and `Size`.

### Colours

- `Colour`
- `ColourTranslator`
- `ColourMappingExtensions`

The colour API supports:

- predefined named colours
- conversion from and to ARGB integers
- conversion from and to hexadecimal strings
- conversion from and to `System.Drawing.Color`
- conversion from and to `Microsoft.Xna.Framework.Color`

## Usage Examples

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

## Mapping Extensions

The `NuciXNA.Primitives.Mapping` namespace contains extension methods for common conversions:

- points between `Point2D`, `System.Drawing.Point`, `Microsoft.Xna.Framework.Point`, and `Microsoft.Xna.Framework.Vector2`
- rectangles between `Rectangle2D`, `System.Drawing.Rectangle`, and `Microsoft.Xna.Framework.Rectangle`
- colours between `Colour`, `System.Drawing.Color`, and `Microsoft.Xna.Framework.Color`
- vectors between `Vector2D` / `Vector3D` and MonoGame vectors
- sizes and scales through their corresponding mapping helpers

This is useful when game logic and UI logic use custom primitives internally, but rendering and platform code still depend on framework-native types.

## Development

### Build

```bash
dotnet build NuciXNA.sln
```

### Test

```bash
dotnet test NuciXNA.sln
```

## Related Projects

- [NuciXNA.DataAccess](https://github.com/hmlendea/nucixna.dataaccess)
- [NuciXNA.Graphics](https://github.com/hmlendea/nucixna.graphics)
- [NuciXNA.GUI](https://github.com/hmlendea/nucixna.gui)
- [NuciXNA.Input](https://github.com/hmlendea/nucixna.input)
- [NuciXNA.Primitives](https://github.com/hmlendea/nucixna.Primitives)

## License

This project is licensed under the `GNU General Public License v3.0` or later. See [LICENSE](./LICENSE) for details.
