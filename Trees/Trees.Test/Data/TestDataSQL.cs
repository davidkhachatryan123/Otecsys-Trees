using System.Collections;

namespace Trees.Test.Data;

public class TestDataSQL : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    //                  Parent ID   Children IDs
    //                          ^   ^
    //                          |   |
    //                          |    _ _ _ _
    //                          |           |
    yield return new object[] { 1, new[] { 2, 3, 4, 5 } };
    yield return new object[] { 2, new[] { 3, 5 } };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
