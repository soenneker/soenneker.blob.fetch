using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using Soenneker.Blob.Container.Abstract;
using Soenneker.Blob.Fetch.Abstract;
using Soenneker.Extensions.ValueTask;

namespace Soenneker.Blob.Fetch;

///<inheritdoc cref="IBlobFetchUtil"/>
public sealed class BlobFetchUtil : IBlobFetchUtil
{
    private readonly ILogger<BlobFetchUtil> _logger;
    private readonly IBlobContainerUtil _blobContainerUtil;

    public BlobFetchUtil(ILogger<BlobFetchUtil> logger, IBlobContainerUtil blobContainerUtil)
    {
        _logger = logger;
        _blobContainerUtil = blobContainerUtil;
    }

    public async ValueTask<List<BlobItem>> GetAllBlobItems(string blobContainer, string? prefix = null, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Getting all blob items from container ({container}) with prefix ({prefix})...", blobContainer, prefix);

        BlobContainerClient container = await _blobContainerUtil.Get(blobContainer, cancellationToken: cancellationToken)
                                                                .NoSync();

        var blobItems = new List<BlobItem>();

        var blobGetOptions = new GetBlobsOptions
        {
            Prefix = prefix
        };

        await foreach (BlobItem blobItem in container.GetBlobsAsync(blobGetOptions, cancellationToken: cancellationToken)
                                                     .ConfigureAwait(false))
        {
            blobItems.Add(blobItem);
        }

        _logger.LogDebug("Completed getting all blob items in container ({container}) with prefix ({prefix})", blobContainer, prefix);

        return blobItems;
    }
}