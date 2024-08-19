using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for adding Memcached server resources to the application model.
/// </summary>
public static class MemcachedBuilderExtensions
{
    /// <summary>
    /// Adds a Memcached server resource to the application model. This resource will be 
    /// configured to run inside a container, making it suitable for local development.
    /// </summary>
    /// <param name="builder">The <see cref="IDistributedApplicationBuilder"/> to add the resource to.</param>
    /// <param name="name">The name of the Memcached resource.</param>
    /// <param name="port">Optional. The host port for the Memcached server. Defaults to null, which auto-assigns a port.</param>
    /// <param name="maxMemory">Optional. The maximum memory size in megabytes. Defaults to 64 MB.</param>
    /// <param name="maxSizePerItem">Optional. The maximum memory size per item in megabytes. Defaults to 10 MB.</param>
    /// <returns>An <see cref="IResourceBuilder{TResource}"/> for further configuration of the Memcached resource.</returns>
    public static IResourceBuilder<MemcachedResource> AddMemcached(
        this IDistributedApplicationBuilder builder,
        string name,
        int? port = null,
        int? maxMemory = 64,
        int? maxSizePerItem = 10)
    {
        // Create a new MemcachedResource with the specified name.
        var memcachedResource = new MemcachedResource(name);

        // Configure the resource builder with the necessary settings for the Memcached container.
        var resourceBuilder = builder.AddResource(memcachedResource)
            .WithEndpoint(port: port, targetPort: 11211, scheme: "tcp", name: "tcp")
            .WithImage(MemcachedContainerImageTags.Image, MemcachedContainerImageTags.Tag)
            .WithImageRegistry(MemcachedContainerImageTags.Registry)
            .WithEntrypoint("memcached")
            .WithArgs($"-m {maxMemory} -I {maxSizePerItem}m");

        return resourceBuilder;
    }
}