using Nest;

namespace TreeElasticStack.Data;

public class SeedData
{
    private const string IndexName = "organizations_tree";
    private const string TokenizerName = "hierarchy";
    private const string AnalyzerName = "tree";

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
            );


            if (!createIndexResponse.Acknowledged)
                throw new Exception("Error was occurred in ElasticSearch when trying to create indices");
        }
    }
}
