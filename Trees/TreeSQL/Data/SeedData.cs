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

    var org1 = await root.AddAsync(new Organization("Office 1"));
    var org2 = await org1.AddAsync(new Organization("Office 2"));
    var org3 = await org2.AddAsync(new Organization("Office 3"));
    var org4 = await org1.AddAsync(new Organization("Office 4"));
    var org5 = await org2.AddAsync(new Organization("Office 5"));
  }
}
