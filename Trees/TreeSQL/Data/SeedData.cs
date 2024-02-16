using Microsoft.EntityFrameworkCore;
using TreeSQL.Database;
using TreeSQL.Models;
using TreeSQL.Services.OrganizationsComposite;
using TreeSQL.Services.Repositories;

namespace TreeSQL;

public static class SeedData
{
  public static async Task SeedDevDataAsync(WebApplication app)
  {
    using var scope = app.Services.CreateScope();

    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (await context.Organizations.AnyAsync()) return;

    var repo = scope.ServiceProvider.GetRequiredService<IOrganizationRepository>();
    var root = scope.ServiceProvider.GetRequiredService<CompositeOrganization>();

    var org1 = new CompositeOrganization(repo) { Name = "Office number 1" };
    var org2 = new CompositeOrganization(repo) { Name = "Office number 2" };
    var org3 = new CompositeOrganization(repo) { Name = "Office number 3" };
    var org4 = new CompositeOrganization(repo) { Name = "Office number 4" };
    var org5 = new CompositeOrganization(repo) { Name = "Office number 5" };

    await root.AddAsync(org1);
    await org1.AddAsync(org2);
    await org2.AddAsync(org3);
    await org1.AddAsync(org4);
    await org2.AddAsync(org5);
  }
}
