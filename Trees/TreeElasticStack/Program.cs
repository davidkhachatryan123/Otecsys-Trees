using TreeElasticStack.Data;
using TreeElasticStack.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddElasticSearch(builder.Configuration);

builder.Services.AddDefaultSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
  app.UseDefaultSwagger(builder.Configuration);

app.MapControllers();

await SeedData.SeedIndices(app);

await app.RunAsync();
