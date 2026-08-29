[![](https://img.shields.io/nuget/v/Soenneker.Blob.Fetch.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Fetch/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.fetch/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blob.fetch/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Blob.Fetch.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Fetch/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.fetch/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blob.fetch/actions/workflows/codeql.yml)

# Soenneker.Blob.Fetch

A utility library for Azure Blob fetch (metadata) operations.

## Install

```bash
dotnet add package Soenneker.Blob.Fetch
```

## Quick start

```csharp
using Soenneker.Blob.Fetch.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddBlobFetchUtilAsSingleton();
```

Registers Blob Fetch Util with a singleton lifetime.

## What you get

- `IBlobFetchUtil` — A utility library for Azure Blob fetch (metadata) operations.
- `BlobFetchUtilRegistrar` — A utility library for Azure Blob storage fetch operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IBlobFetchUtil.GetAllBlobItems(blobContainer, prefix, cancellationToken)` | Doesn't download blobs, just grabs the metadata or reference to it. DON'T use this to download a blob; use BlobDownloadUtil instead. Typically Scoped IoC. | Blob metadata and references only; blob content is not downloaded. |
| `BlobFetchUtilRegistrar.AddBlobFetchUtilAsSingleton(services)` | Registers Blob Fetch Util with a singleton lifetime. | The same service collection, so additional registrations can be chained. |
| `BlobFetchUtilRegistrar.AddBlobFetchUtilAsScoped(services)` | Registers Blob Fetch Util with a scoped lifetime. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
