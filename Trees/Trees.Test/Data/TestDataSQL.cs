using System.Collections;

namespace Trees.Test.Data;

public class TestDataSQL : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    //                  Parent ID   Children IDs
    //                          ^   ^
    //                          |   |
    //                          |_  |_ _ _ _ _ _ _ _ _ _ _ _
    yield return new object[] { 26, new[] { 27, 28, 29, 30 } };
    yield return new object[] { 27, new[] { 28, 30 } };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
