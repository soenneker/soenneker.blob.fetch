using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blob.Fetch.Abstract;

namespace Soenneker.Blob.Fetch.Registrars;

/// <summary>
/// A utility library for Azure Blob storage fetch operations
/// </summary>
public static class BlobFetchUtilRegistrar
{
    public static void AddBlobFetchUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IBlobFetchUtil, BlobFetchUtil>();
    }

    /// <summary>
    /// Recommended
    /// </summary>
    public static void AddBlobFetchUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IBlobFetchUtil, BlobFetchUtil>();
    }
}