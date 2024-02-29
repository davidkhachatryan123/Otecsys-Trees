using System.Collections;

namespace Trees.Test;

public class Data : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    //                  Parent ID   Children IDs
    //                          ^   ^
    //                          |   |
    //                          |    _ _ _ _
    //                          |           |
    yield return new object[] { 1, new[] { 100, 2 } };
    yield return new object[] { 99, new[] { 100 } };
    yield return new object[] { 50, new[] { 100 } };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
