# Privacy and Personal Data

This document describes how NuciXNA.Primitives handles personal data. NuciXNA.Primitives is a .NET library that provides reusable geometry, size, scale, vector, rectangle, and colour types for projects built on top of MonoGame/XNA. It is distributed as a NuGet package and its source code is available on GitHub. The library does not provide a hosted service, does not collect telemetry, and does not transmit data to project maintainers or third parties.

**Information reviewed:** 2026-10-13

## 📑 Table of Contents

- [What This Document Covers](#-what-this-document-covers)
- [Data We Handle](#-data-we-handle)
  - [Data Provided to the Application](#-data-provided-to-the-application)
  - [Data Generated or Collected by the Application](#-data-generated-or-collected-by-the-application)
  - [Data Received from Integrations](#-data-received-from-integrations)
- [Processing and Use](#-processing-and-use)
- [Storage, Retention, and Deletion](#-storage-retention-and-deletion)
- [External Processing and Integrations](#-external-processing-and-integrations)
- [Document Changes](#-document-changes)
- [Contact](#-contact)

## 🔎 What This Document Covers

This document describes how NuciXNA.Primitives at https://github.com/hmlendea/nucixna.primitives handles personal data. It covers the application behaviour and verified integrations described below. Where the software is self-hosted, the instance operator may have separate responsibilities described below.

NuciXNA.Primitives is a .NET class library. It is not a hosted service and does not include a server, daemon, or background process. The library is consumed by downstream applications that reference it via NuGet or source code. This document covers only the library itself; downstream applications are responsible for their own data handling.

## 📥 Data We Handle

### Data Provided to the Application

- No personal data is requested, collected, or processed by NuciXNA.Primitives. The library does not expose APIs that accept personal data from users or administrators.

### Data Generated or Collected by the Application

- No personal data is generated or collected automatically. The library does not produce telemetry, crash reports, access logs, or update checks.

### Data Received from Integrations

- No personal data is received from integrations or third parties. The library does not call external services or transmit data over the network.

## 🧭 Processing and Use

The application processes the data described above for these verified functions:
- No processing activities are performed. The library performs only in-memory computations on geometry, size, scale, vector, rectangle, and colour values.

## 🗄️ Storage, Retention, and Deletion

No personal data is stored, retained, or deleted by NuciXNA.Primitives. The library does not write to disk, maintain databases, or persist data between sessions. Any storage, retention, or deletion of data is the responsibility of the downstream application that consumes the library.

## 🔗 External Processing and Integrations

NuciXNA.Primitives has no built-in external data transfer. The library does not integrate with external services, analytics providers, or telemetry systems.

| Service or integration | Purpose | Data involved | Configuration or documentation |
|-----------------------|---------|---------------|--------------------------------|

## 🔄 Document Changes

Update this document when application data flows, storage, integrations, or deployment responsibilities change. The current version is published at https://github.com/hmlendea/nucixna.primitives/blob/main/PRIVACY.md.

## 📬 Contact

For questions about application data handling, contact the project maintainers. For a self-hosted instance, contact the instance operator, unless the project explicitly handles the request. Include the repository name or issue reference if relevant; do not send passwords, access tokens, or other secrets.
