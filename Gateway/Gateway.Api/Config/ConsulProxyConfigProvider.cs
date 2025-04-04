using Consul;
using Microsoft.Extensions.Primitives;
using Yarp.ReverseProxy.Configuration;

public class ConsulProxyConfigProvider : IProxyConfigProvider
{
    private readonly IConsulClient _consulClient;
    private ConsulProxyConfig _config;

    public ConsulProxyConfigProvider(IConsulClient consulClient)
    {
        _consulClient = consulClient;
        _config = new ConsulProxyConfig(new List<RouteConfig>(), new List<ClusterConfig>());
        _ = UpdateConfigAsync();
    }

    public IProxyConfig GetConfig() => _config;

    private async Task UpdateConfigAsync()
    {
        var services = await _consulClient.Catalog.Services();

        var routes = new List<RouteConfig>();
        var clusters = new List<ClusterConfig>();

        foreach (var service in services.Response.Keys)
        {
            var serviceInstances = await _consulClient.Health.Service(service, null, true);
            var destinations = serviceInstances.Response
                .Select((s, i) =>
                {
                    var scheme = "http"; // Default fallback

                    // Try to read scheme from service metadata
                    if (s.Service.Meta != null && s.Service.Meta.TryGetValue("scheme", out var metaScheme))
                    {
                        scheme = metaScheme;
                    }

                    var address = $"{scheme}://{s.Service.Address}:{s.Service.Port}";

                    return new
                    {
                        Key = $"dest-{i}",
                        Destination = new DestinationConfig
                        {
                            Address = address
                        }
                    };
                })
                .ToDictionary(x => x.Key, x => x.Destination);

            clusters.Add(new ClusterConfig
            {
                ClusterId = service,
                Destinations = destinations
            });

            routes.Add(new RouteConfig
            {
                RouteId = $"route-{service}",
                ClusterId = service,
                Match = new RouteMatch
                {
                    Path = $"/{service}/{{**catch-all}}"
                },
                Transforms =
                [
                    new Dictionary<string, string>
                    {
                        { "PathRemovePrefix", $"/{service}" }
                    }
                ]
            });
        }

        _config = new ConsulProxyConfig(routes, clusters);
    }

    private class ConsulProxyConfig : IProxyConfig
    {
        public ConsulProxyConfig(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
        {
            Routes = routes;
            Clusters = clusters;
            ChangeToken = new CancellationChangeToken(new CancellationTokenSource().Token);
        }

        public IReadOnlyList<RouteConfig> Routes { get; }
        public IReadOnlyList<ClusterConfig> Clusters { get; }
        public IChangeToken ChangeToken { get; }
    }
}
