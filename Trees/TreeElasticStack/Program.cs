using TreeElasticStack.Data;
using TreeElasticStack.Extensions;
using TreeElasticStack.Services;
using TreeElasticStack.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<OrganizationHelperService>();
builder.Services.AddControllers();
builder.Services.AddMappings();
builder.Services.AddElasticSearch(builder.Configuration);
builder.Services.AddDefaultSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
  app.UseDefaultSwagger(builder.Configuration);

app.MapControllers();

await SeedData.SeedIndices(app);

if (app.Environment.IsDevelopment())
  SeedData.SeedTestData(app);

await app.RunAsync();

namespace TreeElasticStack { public partial class Program { public Program() { } } }
