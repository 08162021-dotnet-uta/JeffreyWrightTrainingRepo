using Xunit;
using p0.StoreApplication.Client.Singletons;
using System.Collections.Generic;
using p0.StoreApplication.Storage.Adapters;
using p0.StoreApplication.Domain.Models;

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
      //Assert.IsType(actual);
    }
  }
}