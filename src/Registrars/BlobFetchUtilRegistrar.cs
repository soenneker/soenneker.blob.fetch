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
    public static IServiceCollection AddBlobFetchUtilAsSingleton(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton()
                .TryAddSingleton<IBlobFetchUtil, BlobFetchUtil>();

        return services;
    }

    public static IServiceCollection AddBlobFetchUtilAsScoped(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton()
                .TryAddScoped<IBlobFetchUtil, BlobFetchUtil>();

        return services;
    }
}