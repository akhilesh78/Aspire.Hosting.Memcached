# Aspire.Hosting.Memcached library

Provides extension methods and resource definitions for a .NET Aspire AppHost to configure a Memcached resource.

## Getting started

### Install the package

In your AppHost project, install the .NET Aspire Memcached Hosting library with [NuGet](https://www.nuget.org):

```dotnetcli
dotnet add package Aspire.Hosting.Memcached
```

## Usage example

Then, in the _Program.cs_ file of `AppHost`, add a Memcached resource and consume the connection using the following methods:

```csharp
var Memcached = builder.AddMemcached("Memcached");

var myService = builder.AddProject<Projects.MyService>()
                       .WithReference(Memcached);
```

### Custom Configuration
You can customize the Memcached resource with optional parameters such as specifying a custom port, memory limits, and maximum item size:

```csharp
var memcached = builder.AddMemcached(
name: "CustomMemcached",
port: 11212,          // Custom host port
maxMemory: 128,       // Maximum memory size in MB
maxSizePerItem: 20    // Maximum memory size per item in MB
);

var myService = builder.AddProject<Projects.MyService>()
.WithReference(memcached);
```

## Additional documentation

* https://www.memcached.org/
* https://github.com/cnblogs/EnyimMemcachedCore

## Feedback & contributing

https://github.com/akhilesh78/Aspire.Hosting.Memcached
