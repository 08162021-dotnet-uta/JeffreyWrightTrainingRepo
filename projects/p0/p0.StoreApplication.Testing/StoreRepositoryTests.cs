using Xunit;
using p0.StoreApplication.Storage.Repositories;

namespace p0.StoreApplication.Testing
{
  public class StoreRepositoryTests
  {
    [Fact]
    public void Test_StoreCollection()
    {
      // arrange = instance of the entity to test
      var sut = StoreRepository.Instance;

      // act = execute sut for data
      var actual = sut.Stores;

      // assert
      Assert.NotNull(actual);
    }
  }
}