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
    /// <summary>
    /// Registers Blob Fetch Util with a singleton lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddBlobFetchUtilAsSingleton(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton().TryAddSingleton<IBlobFetchUtil, BlobFetchUtil>();

        return services;
    }

    /// <summary>
    /// Registers Blob Fetch Util with a scoped lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddBlobFetchUtilAsScoped(this IServiceCollection services)
    {
        services.AddBlobContainerUtilAsSingleton().TryAddScoped<IBlobFetchUtil, BlobFetchUtil>();

        return services;
    }
}
