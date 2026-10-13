# Contributing to NuciXNA.Primitives

This document covers the guidelines and processes for contributing to this project, including how to report issues, suggest enhancements, submit code changes, and follow project standards.

## 📑 Table of Contents

- [How to Contribute](#-how-to-contribute)
  - [Reporting Issues](#reporting-issues)
  - [Suggesting Enhancements](#suggesting-enhancements)
  - [Code Contributions](#code-contributions)
    - [Prerequisites](#prerequisites)
    - [Development Setup](#development-setup)
    - [Making Changes](#making-changes)
    - [Pull Request Guidelines](#pull-request-guidelines)
  - [Code Style](#code-style)
  - [Testing](#testing)
  - [Documentation](#documentation)
- [Code of Conduct](#-code-of-conduct)
- [Security](#-security)
- [License](#-license)
- [Getting Help](#-getting-help)

## 🤝 How to Contribute

### Reporting Issues

- Search existing issues first.
- Use the issue templates if available.
- Provide clear reproduction steps.
- Include environment details (OS, .NET version, MonoGame version).

### Suggesting Enhancements

- Check the roadmap and existing discussions.
- Explain the use case and expected behavior.
- Consider implementation complexity.

### Code Contributions

#### Prerequisites

- .NET 10 SDK or later
- Git

#### Development Setup

```bash
# Clone the repository
git clone https://github.com/hmlendea/nucixna.primitives.git
cd nucixna.primitives

# Restore dependencies
dotnet restore NuciXNA.sln
```

#### Making Changes

1. Fork the repository.
2. Create a feature branch: `git checkout -b feature/your-feature-name`
3. Make your changes.
4. Run tests: `dotnet test NuciXNA.sln --configuration Release`
5. Run build: `dotnet build NuciXNA.sln --configuration Release --no-restore`
6. Commit with clear and descriptive messages.
7. Push to your fork.
8. Open a Pull Request.

#### Pull Request Guidelines

- Target the `main` branch.
- Keep PRs focused and atomic.
- Update documentation if applicable.
- Add tests for any new functionality.
- Ensure the CI checks pass.

### Code Style

Follow the project's coding standards:
- C# coding conventions per `csharp.coding.instructions.md` and `csharp.naming.instructions.md`
- Use `dotnet format` before committing (if available)
- All public APIs must have XML documentation comments
- Structs for value types; sealed classes only when reference semantics are required
- Implement `IEquatable<T>` for all primitives

### Testing

```bash
# Run all tests
dotnet test NuciXNA.sln --configuration Release

# Run specific test project
dotnet test NuciXNA.Primitives.UnitTests/NuciXNA.Primitives.UnitTests.csproj --configuration Release
```

Tests use NUnit 4.5.1. Add tests for:
- Construction, equality, and arithmetic for new primitive types
- Edge cases (empty/zero values, boundary conditions)
- Bidirectional mapping correctness for new extension methods
- `ColourTranslator` hex/ARGB round-trips

### Documentation

- Update relevant docs for changes (README.md, ARCHITECTURE.md, XML comments)
- Follow the documentation style guide (Markdown, repository-relative links)
- Preview changes locally if possible

## 📋 Code of Conduct

This project does not currently have a Code of Conduct document. Contributors are expected to interact respectfully and professionally.

## 🔒 Security

Report security vulnerabilities per the [Security Policy](SECURITY.md).

## 📄 License

By contributing, you agree that your contributions will be licensed under the GNU General Public License v3.0 or later.

## ❓ Getting Help

- Check existing discussions and documentation first.
- Open a GitHub Issue for questions not covered by documentation.
- Review the [Architecture](ARCHITECTURE.md) and [README](README.md) for context.