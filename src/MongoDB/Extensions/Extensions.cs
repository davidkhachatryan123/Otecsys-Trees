using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Models;

namespace MongoDB.Extensions;

public static class Extensions
{
  public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddSingleton<IMongoClient>(
      _ => new MongoClient(
      configuration.GetConnectionString("OrganizationDb")));

    BsonClassMap.RegisterClassMap<Organization>(classMap =>
    {
      classMap.AutoMap();
    });

    return services;
  }
}
