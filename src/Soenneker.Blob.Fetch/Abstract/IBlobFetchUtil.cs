using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Soenneker.Blob.Fetch.Abstract;

/// <summary>
/// Lists blob metadata from Azure Blob Storage containers.
/// </summary>
public interface IBlobFetchUtil
{
    /// <summary>
    /// Lists every blob whose name begins with an optional prefix.
    /// </summary>
    /// <param name="blobContainer">Name of the blob container.</param>
    /// <param name="prefix">Optional case-sensitive blob name prefix.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>All matching blob items. Blob content is not downloaded.</returns>
    ValueTask<List<BlobItem>> GetAllBlobItems(string blobContainer, string? prefix = null, CancellationToken cancellationToken = default);
}
