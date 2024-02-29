using System.Collections;

namespace Trees.Test.Data;

public class TestDataSQLClosureTable : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    //                  Parent ID   Children IDs
    //                          ^   ^
    //                          |   |
    //                          |    _ _ _ _
    //                          |           |
    yield return new object[] { 2, new[] { 3, 4, 5, 6 } };
    yield return new object[] { 3, new[] { 4, 6 } };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
