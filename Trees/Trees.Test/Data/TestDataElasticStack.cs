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
    yield return new object[] { "8ccb96af-ee2e-4f58-88ca-100efd1dacdb", new[] { "afcded51-4ca4-4417-a63b-11a8e6135c62", "005ac52d-92f2-4baa-adcc-b2bc71cab7c0", "1670a752-c7f6-4a78-b8d1-b0d961ec15fc", "9685d767-7734-48a1-a2cd-b1098db6ec16" } };
    yield return new object[] { "afcded51-4ca4-4417-a63b-11a8e6135c62", new[] { "005ac52d-92f2-4baa-adcc-b2bc71cab7c0", "9685d767-7734-48a1-a2cd-b1098db6ec16" } };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
