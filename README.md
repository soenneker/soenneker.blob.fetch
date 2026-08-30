[![](https://img.shields.io/nuget/v/Soenneker.Blob.Fetch.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Fetch/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.fetch/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blob.fetch/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Blob.Fetch.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Blob.Fetch/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blob.fetch/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blob.fetch/actions/workflows/codeql.yml)

# Soenneker.Blob.Fetch

Lists Azure Blob Storage items and their metadata, optionally filtered by a blob-name prefix.

## Installation

```bash
dotnet add package Soenneker.Blob.Fetch
```

## Configuration

Provide the Azure Storage connection string through configuration:

```json
{
  "Azure": {
    "Storage": {
      "Blob": {
        "ConnectionString": "<connection string>"
      }
    }
  }
}
```

## Registration

```csharp
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Blob.Fetch.Registrars;

services.AddBlobFetchUtilAsSingleton();
```

Use `AddBlobFetchUtilAsScoped()` when the consuming service should be scoped.

## Usage

```csharp
using Azure.Storage.Blobs.Models;
using Soenneker.Blob.Fetch.Abstract;

public sealed class ExportCatalog
{
    private readonly IBlobFetchUtil _fetch;

    public ExportCatalog(IBlobFetchUtil fetch)
    {
        _fetch = fetch;
    }

    public async ValueTask<IReadOnlyList<BlobItem>> ListCsvExports(
        CancellationToken cancellationToken)
    {
        return await _fetch.GetAllBlobItems(
            "exports",
            prefix: "daily/",
            cancellationToken);
    }
}
```

Each returned `BlobItem` describes a blob. The blob content is not downloaded.

## Behavior

- `prefix` is a blob-name prefix, not a wildcard or regular expression. For example, `daily/` matches blobs stored beneath that virtual path.
- Azure may retrieve the listing in multiple service pages, but this library collects every result into one `List<BlobItem>` before returning.
- Because the complete result is held in memory, use Azure's pageable APIs directly when listing a very large or untrusted container.
- The underlying container utility creates a missing container before listing it. An empty result can therefore mean either an existing empty container or a newly created one.
- Blob content and optional metadata fields that were not requested by the underlying Azure listing are not fetched.
- Cancellation is observed while retrieving listing pages.
