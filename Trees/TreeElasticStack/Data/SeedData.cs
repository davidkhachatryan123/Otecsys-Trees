using AutoMapper;
using Nest;
using TreeElasticStack.Services;
using TreeElasticStack.Services.Repositories;

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

    public static void SeedTestData(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var elasticClient = scope.ServiceProvider.GetRequiredService<ElasticClient>();

        if (elasticClient.Count<Organization>().Count > 0) return;

        var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
        var orgRepo = scope.ServiceProvider.GetRequiredService<IOrganizationRepository>();

        CompositeOrganization root = new StorableOrganization("root", orgRepo);
        CompositeOrganization office1 = new StorableOrganization("Office number 1", orgRepo);
        CompositeOrganization office2 = new StorableOrganization("Office number 2", orgRepo);
        CompositeOrganization office3 = new StorableOrganization("Office number 3", orgRepo);
        CompositeOrganization office4 = new StorableOrganization("Office number 4", orgRepo);
        CompositeOrganization office5 = new StorableOrganization("Office number 5", orgRepo);

        root.Add(office1);
        office1.Add(office2);
        office2.Add(office3);
        office1.Add(office4);
        office2.Add(office5);
    }
}
