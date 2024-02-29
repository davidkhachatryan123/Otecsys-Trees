using SQL.ClosureTable.Extensions;
using SQL.ClosureTable.Services;
using SQL.ClosureTable.Services.OrganizationsComposite;
using SQL.ClosureTable.Services.Repositories;
using Common.Extensions;
using SQL.ClosureTable.Data;
using SQL.ClosureTable.Models;
using Common.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddScoped<IOrganizationRepository<Organization>, OrganizationRepository>();
builder.Services.AddScoped<IOrganizationClosureRepsotory, OrganizationClosureRepsotory>();
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

namespace SQL.ClosureTable { public partial class Program { public Program() { } } }
