using Elasticsearch.Net;
using Nest;

namespace ElasticStack.Extensions;

public static class Extensions
{
  public static IServiceCollection AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionPool = new SingleNodeConnectionPool(new Uri(configuration["ElasticSearchUrl"]!));

    var connectionSettings = new ConnectionSettings(connectionPool)
        .DefaultIndex("organizations_tree")
        .EnableApiVersioningHeader()
        .DisableDirectStreaming();

    var client = new ElasticClient(connectionSettings);

    services.AddSingleton(client);

    return services;
  }
}
