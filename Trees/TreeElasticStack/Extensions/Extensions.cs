using Elasticsearch.Net;
using Nest;

namespace TreeElasticStack.Extensions;

public static class Extensions
{
  public static IServiceCollection AddDefaultSwagger(this IServiceCollection services)
  {
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    return services;
  }

  public static IApplicationBuilder UseDefaultSwagger(this WebApplication app, IConfiguration configuration)
  {
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

    return app;
  }

  public static IServiceCollection AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionPool = new SingleNodeConnectionPool(new Uri(configuration["ElasticSearchUrl"]!));

    var connectionSettings = new ConnectionSettings(connectionPool)
        .DefaultIndex("organizations_tree")
        .EnableApiVersioningHeader();

    var client = new ElasticClient(connectionSettings);

    services.AddSingleton(client);

    return services;
  }
}
