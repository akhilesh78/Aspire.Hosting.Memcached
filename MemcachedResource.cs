using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;

/// <summary>
/// Represents a Memcached resource container.
/// Implements <see cref="IResourceWithConnectionString"/> for connection string handling.
/// </summary>
public class MemcachedResource : ContainerResource, IResourceWithConnectionString
{
    private const string PrimaryEndpointName = "tcp";

    private EndpointReference? _primaryEndpoint;

    /// <summary>
    /// Initializes a new instance of the <see cref="MemcachedResource"/> class.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    public MemcachedResource(string name) : base(name)
    {
    }

    /// <summary>
    /// Gets the primary TCP endpoint for the Memcached server.
    /// This endpoint is lazy-loaded and created if it doesn't already exist.
    /// </summary>
    public EndpointReference PrimaryEndpoint =>
        _primaryEndpoint ??= new EndpointReference(this, PrimaryEndpointName);

    /// <summary>
    /// Gets the connection string expression for the Memcached server.
    /// This expression can be used to retrieve the URL of the primary endpoint.
    /// </summary>
    public ReferenceExpression ConnectionStringExpression =>
        ReferenceExpression.Create($"{PrimaryEndpoint.Property(EndpointProperty.Url)}");
}