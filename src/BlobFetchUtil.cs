using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using Soenneker.Blob.Container.Abstract;
using Soenneker.Blob.Fetch.Abstract;
using Soenneker.Utils.Cancellation.Abstract;

namespace Soenneker.Blob.Fetch;

///<inheritdoc cref="IBlobFetchUtil"/>
public class BlobFetchUtil : IBlobFetchUtil
{
    private readonly ILogger<BlobFetchUtil> _logger;
    private readonly ICancellationUtil _cancellationUtil;
    private readonly IBlobContainerUtil _blobContainerUtil;

    public BlobFetchUtil(ILogger<BlobFetchUtil> logger, IBlobContainerUtil blobContainerUtil, ICancellationUtil cancellationUtil)
    {
        _logger = logger;
        _blobContainerUtil = blobContainerUtil;
        _cancellationUtil = cancellationUtil;
    }
        
    public async ValueTask<List<BlobItem>> GetAllBlobItems(string blobContainer, string? prefix = null)
    {
        _logger.LogDebug("Getting all blob items from container {container} with prefix {prefix}", blobContainer, prefix);

        BlobContainerClient container = await _blobContainerUtil.GetClient(blobContainer);

        var blobItems = new List<BlobItem>();

        CancellationToken cancellationToken = _cancellationUtil.Get();

        await foreach (BlobItem blobItem in container.GetBlobsAsync(prefix: prefix, cancellationToken: cancellationToken))
        {
            blobItems.Add(blobItem);
        }

        _logger.LogDebug("Completed getting all blob items in container {container} with prefix: {prefix}", blobContainer, prefix);

        return blobItems;
    }
}