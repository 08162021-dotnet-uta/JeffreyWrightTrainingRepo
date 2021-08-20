using System.Collections.Generic;
using p0.StoreApplication.Domain.Models;

namespace p0.StoreApplication.Storage.Repositories
{
  public class StoreRepository
  {
    public List<Store> Stores { get; }

    public StoreRepository()
    {
      Stores = new List<Store>()
      {
        new Store(){ Name = "Store001", State = "IN", City = "Lafayette"},
        new Store(){ Name = "Store002", State = "TX", City = "San Antonio" },
        new Store(){ Name = "Store003", State = "AZ", City = "Mesa" },
        new Store(){ Name = "Store004", State = "CA", City = "Long Beach"}
      };
    }
  }
}