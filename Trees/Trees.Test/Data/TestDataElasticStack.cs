using System.Collections;

namespace Trees.Test.Data;

public class TestDataElasticStack : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    //                  Parent ID   Children IDs
    //                          ^   ^
    //                          |   |
    //                          |   |_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
    //                          |                                               |
    yield return new object[] { "c4c5fdfa-f209-4b02-8a47-6359cc9b3af1", new[] { "b13f0b8b-9bd7-4452-bca9-11b2f1f33a35", "b13f0b8b-9bd7-4452-bca9-11b2f1f33a35", "a925b209-be58-4d86-80dc-e9d026baf9e3", "e010e128-2d18-4044-b326-6add66057195" } };
    yield return new object[] { "b13f0b8b-9bd7-4452-bca9-11b2f1f33a35", new[] { "c31992eb-461b-4705-b508-e3995b1b10af", "e010e128-2d18-4044-b326-6add66057195" } };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
