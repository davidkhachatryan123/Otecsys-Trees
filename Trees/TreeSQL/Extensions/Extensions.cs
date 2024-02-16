using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TreeSQL.Database;
using TreeSQL.Mappings;

namespace TreeSQL.Extensions;

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

  public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("OrganizationDb"),
        x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));

    return services;
  }

  public static void MigrateDatabase(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
  }

  public static IServiceCollection AddMappings(this IServiceCollection services)
  {
    var mapperConfig = new MapperConfiguration(map =>
    {
      map.AddProfile<OrganizationMappingProfile>();
    });

    services.AddSingleton(mapperConfig.CreateMapper());

    return services;
  }
}
