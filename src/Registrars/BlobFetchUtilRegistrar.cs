using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blob.Container.Registrars;
using Soenneker.Blob.Fetch.Abstract;
using Soenneker.Utils.Cancellation.Registrars;

namespace Soenneker.Blob.Fetch.Registrars;

/// <summary>
/// A utility library for Azure Blob storage fetch operations
/// </summary>
public static class BlobFetchUtilRegistrar
{
    public static void AddBlobFetchUtilAsScoped(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton();
        services.AddCancellationUtil();
        services.TryAddScoped<IBlobFetchUtil, BlobFetchUtil>();
    }
}