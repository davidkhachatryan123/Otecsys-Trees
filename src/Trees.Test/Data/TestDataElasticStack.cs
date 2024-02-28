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
    yield return new object[] { "b9cc3caa-6f46-4295-852d-1ccc55ab9fb3", new[] { "dccf3fa7-0552-46ba-978d-6af4d0c8540e", "36285aee-5ae7-4790-9fb6-6706b65c0e91", "b44cff48-0d2d-44c2-8147-fcd99b231429", "502875f9-8320-425e-94e7-c0b8cd0ca627" } };
    yield return new object[] { "dccf3fa7-0552-46ba-978d-6af4d0c8540e", new[] { "36285aee-5ae7-4790-9fb6-6706b65c0e91", "502875f9-8320-425e-94e7-c0b8cd0ca627" } };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
