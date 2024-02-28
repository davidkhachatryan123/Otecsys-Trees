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
    yield return new object[] { "bd4c6c5a-1aa7-4d0b-a9aa-09d4cce4fbb2", new[] { "855930f6-7be6-4074-8528-055a0aed89f0", "6666cf80-0648-49c3-b111-99cec838b812", "0cbc7e23-cc4d-4382-a409-5e0ffab13283", "e0708924-d51c-41bc-b856-7e59ad0af2b3" } };
    yield return new object[] { "855930f6-7be6-4074-8528-055a0aed89f0", new[] { "6666cf80-0648-49c3-b111-99cec838b812", "e0708924-d51c-41bc-b856-7e59ad0af2b3" } };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
