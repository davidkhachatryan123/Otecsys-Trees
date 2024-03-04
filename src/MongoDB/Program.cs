using Common.Extensions;
using MongoDB.Extensions;
using MongoDB.Services;
using MongoDB.Services.OrganizationsComposite;
using MongoDB.Services.Repositories;
using MongoDB.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<OrganizationHelperService>();
builder.Services.AddTransient<CompositeOrganization>();
builder.Services.AddControllers();
builder.Services.AddDefaultSwagger();

var app = builder.Build();

app.MapControllers();

await SeedData.SeedCollectionOptions(app);

if (app.Environment.IsDevelopment())
{
  app.UseDefaultSwagger(builder.Configuration);

  await SeedData.SeedDevDataAsync(app);
}

await app.RunAsync();

namespace MongoDB { public partial class Program { public Program() { } } }
