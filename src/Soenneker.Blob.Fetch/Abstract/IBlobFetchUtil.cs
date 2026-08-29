using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
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
    /// <param name="blobContainer">Blob Container for the get all blob items operation.</param>
    /// <param name="prefix">Prefix prepended to generated keys or names.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the collection returned by get All Blob Items.</returns>
    [Pure]
    ValueTask<List<BlobItem>> GetAllBlobItems(string blobContainer, string? prefix = null, CancellationToken cancellationToken = default);
}
