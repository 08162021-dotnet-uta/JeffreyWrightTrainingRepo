using Xunit;
using p0.StoreApplication.Client.Singletons;

namespace p0.StoreApplication.Testing
{
  public class StoreSingletonTests
  {
    [Fact]
    public void Test_StoreCollection()
    {
      // arrange = instance of the entity to test
      var sut = StoreSingleton.Instance;

      // act = execute sut for data
      var actual = sut.Stores;

      // assert
      Assert.NotNull(actual);
    }
  }
}