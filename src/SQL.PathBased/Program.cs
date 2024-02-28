using SQL.PathBased.Extensions;
using SQL.PathBased.Services;
using SQL.PathBased.Services.OrganizationsComposite;
using SQL.PathBased.Services.Repositories;
using Common.Extensions;
using SQL.PathBased.Data;

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

namespace SQL.PathBased { public partial class Program { public Program() { } } }
