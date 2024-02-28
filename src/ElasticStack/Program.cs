using ElasticStack.Data;
using ElasticStack.Extensions;
using ElasticStack.Services;
using ElasticStack.Services.Repositories;
using Common.Extensions;
using ElasticStack.Services.OrganizationsComposite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<OrganizationHelperService>();
builder.Services.AddTransient<CompositeOrganization>();
builder.Services.AddControllers();
builder.Services.AddElasticSearch(builder.Configuration);
builder.Services.AddDefaultSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
  app.UseDefaultSwagger(builder.Configuration);

app.MapControllers();

await SeedData.SeedIndices(app);

if (app.Environment.IsDevelopment())
  SeedData.SeedDevDataAsync(app);

await app.RunAsync();

namespace ElasticStack { public partial class Program { public Program() { } } }
