using Nest;
using ElasticStack.Services.OrganizationsComposite;

namespace ElasticStack.Data;

public class SeedData
{
    private const string IndexName = "organizations_tree";
    private const string TokenizerName = "hierarchy";
    private const string AnalyzerName = "path_tree";

    public static async Task SeedIndices(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        ElasticClient client =
            scope.ServiceProvider.GetRequiredService<ElasticClient>();

        if (!client.Indices.ExistsAsync(IndexName).Result.Exists)
        {
            var createIndexResponse = await client.Indices.CreateAsync(IndexName, c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Tokenizers(t => t
                            .PathHierarchy(TokenizerName, ph => ph
                                .Delimiter('/')
                            )
                        )
                        .Analyzers(a => a
                            .UserDefined(AnalyzerName, new CustomAnalyzer
                            {
                                Tokenizer = TokenizerName
                            })
                        )
                    )
                )
                .Map<Organization>(m => m
                    .Properties(p => p
                        .Text(t => t
                            .Name(n => n.Path)
                            .Fields(ff => ff
                                .Text(tt => tt
                                    .Name("tree")
                                    .Analyzer("path_tree")
                                )
                            )
                        )
                    )
                )
            );

            if (!createIndexResponse.Acknowledged)
                throw new Exception("Error was occurred in ElasticSearch when was trying to create indices");
        }
    }

    public static async void SeedDevDataAsync(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var elasticClient = scope.ServiceProvider.GetRequiredService<ElasticClient>();
        if (elasticClient.Count<Organization>().Count > 0) return;

        var root = scope.ServiceProvider.GetRequiredService<CompositeOrganization>();
        var org1 = await root.AddAsync(new Organization("Office 1"));
        var org2 = await org1.AddAsync(new Organization("Office 2"));
        var org3 = await org2.AddAsync(new Organization("Office 3"));
        var org4 = await org1.AddAsync(new Organization("Office 4"));
        var org5 = await org2.AddAsync(new Organization("Office 5"));
    }
}
