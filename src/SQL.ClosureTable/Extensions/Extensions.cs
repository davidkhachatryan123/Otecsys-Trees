using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SQL.ClosureTable.Database;

namespace SQL.ClosureTable.Extensions;

public static class Extensions
{
  public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("ClosureTableOrganizationDb"),
        x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));

    return services;
  }

  public static void MigrateDatabase(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
  }
}
