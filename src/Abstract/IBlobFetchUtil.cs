using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Soenneker.Blob.Fetch.Abstract;

/// <summary>
/// A utility library for Azure Blob fetch (metadata) operations
/// </summary>
public interface IBlobFetchUtil
{
    /// <summary>
    /// Doesn't download blobs, just grabs the metadata or reference to it. <para/>
    /// DON'T use this to download a blob; use BlobDownloadUtil instead. <para/>
    /// Typically Scoped IoC
    /// </summary>
    [Pure]
    ValueTask<List<BlobItem>> GetAllBlobItems(string blobContainer, string? prefix = null);
}