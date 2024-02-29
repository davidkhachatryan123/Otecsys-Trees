using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SQL.ClosureTable.Database;

namespace Trees.Benchmark;

[MemoryDiagnoser]
public class SQLClosureTableBenchmark
{
  public static IEnumerable<object[]> Data()
  {
    yield return new object[] { 2, 3 };
    yield return new object[] { 2, 6 };
    yield return new object[] { 3, 6 };
  }

  private ApplicationDbContext _context = null!;

  [GlobalSetup]
  public void Setup()
  {
    var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("config.json", optional: false);

    var config = builder.Build();

    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
      .UseSqlServer(config.GetConnectionString("ClosureTableOrganizationDb"));

    _context = new ApplicationDbContext(optionsBuilder.Options);
  }

  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public async Task<bool> HasAccess(int nodeId, int parentId)
  => await _context.OrganizationClosures
                   .AsNoTracking()
                   .AnyAsync(o => o.NodeId == nodeId && o.ParentId == parentId);
}
