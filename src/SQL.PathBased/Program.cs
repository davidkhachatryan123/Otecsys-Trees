using TreeSQL;
using TreeSQL.Extensions;
using TreeSQL.Services;
using TreeSQL.Services.OrganizationsComposite;
using TreeSQL.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<OrganizationHelperService>();
builder.Services.AddTransient<CompositeOrganization>();
builder.Services.AddControllers();
builder.Services.AddDefaultSwagger();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
  app.UseDefaultSwagger(builder.Configuration);

  app.MigrateDatabase();
  await SeedData.SeedDevDataAsync(app);
}

await app.RunAsync();

namespace TreeSQL { public partial class Program { public Program() { } } }
