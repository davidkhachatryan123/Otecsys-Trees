using AutoMapper;
using Nest;
using TreeElasticStack.Services;

namespace TreeElasticStack.Data;

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
                throw new Exception("Error was occurred in ElasticSearch when trying to create indices");
        }
    }

    public static async Task SeedTestData(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        IMapper mapper =
            scope.ServiceProvider.GetRequiredService<IMapper>();

        CompositeOrganization office1 = new("Office number 1");
        CompositeOrganization office2 = new("Office number 2");
        CompositeOrganization office3 = new("Office number 3");
        CompositeOrganization office4 = new("Office number 4");
        CompositeOrganization office5 = new("Office number 5");

        office1.Add(office2);
        office2.Add(office3);
        office1.Add(office4);
        office2.Add(office5);
    }
}
