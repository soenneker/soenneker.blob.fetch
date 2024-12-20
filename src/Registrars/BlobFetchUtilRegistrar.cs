using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blob.Container.Registrars;
using Soenneker.Blob.Fetch.Abstract;

namespace Soenneker.Blob.Fetch.Registrars;

/// <summary>
/// A utility library for Azure Blob storage fetch operations
/// </summary>
public static class BlobFetchUtilRegistrar
{
    public static void AddBlobFetchUtilAsSingleton(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton();
        services.TryAddSingleton<IBlobFetchUtil, BlobFetchUtil>();
    }

    public static void AddBlobFetchUtilAsScoped(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton();
        services.TryAddScoped<IBlobFetchUtil, BlobFetchUtil>();
    }
}