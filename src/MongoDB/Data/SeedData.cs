using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Models;
using MongoDB.Services.OrganizationsComposite;

namespace MongoDB.Data;

public static class SeedData
{
  public static async Task SeedCollectionOptions(WebApplication app)
  {
    using var scope = app.Services.CreateScope();

    var client = scope.ServiceProvider.GetRequiredService<IMongoClient>();

    var database = client.GetDatabase("organizationdb");
    var collection = database.GetCollection<Organization>("organizations");

    var indexKeysDefinition = Builders<Organization>.IndexKeys.Ascending(org => org.Ancestors);
    await collection.Indexes.CreateOneAsync(new CreateIndexModel<Organization>(indexKeysDefinition));

    await collection.ReplaceOneAsync(
      Builders<Organization>.Filter.Eq(o => o.Id, new ObjectId("000000000000000000000000")),
      new Organization("root") { Id = new ObjectId("000000000000000000000000"), },
      new ReplaceOptions() { IsUpsert = true });
  }

  public static async Task SeedDevDataAsync(WebApplication app)
  {
    using var scope = app.Services.CreateScope();

    var client = scope.ServiceProvider.GetRequiredService<IMongoClient>();
    var database = client.GetDatabase("organizationdb");
    var collection = database.GetCollection<Organization>("organizations");
    if (await collection.CountDocumentsAsync(new BsonDocument()) > 1) return;

    var orgs = scope.ServiceProvider.GetRequiredService<CompositeOrganization>();

    var root = await orgs.PickAsync();
    var org1 = await root.AddAsync(new Organization("Office 1"));
    var org2 = await org1.AddAsync(new Organization("Office 2"));
    var org3 = await org2.AddAsync(new Organization("Office 3"));
    var org4 = await org1.AddAsync(new Organization("Office 4"));
    var org5 = await org2.AddAsync(new Organization("Office 5"));
  }
}
