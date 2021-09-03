using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;
using System;

namespace p0.StoreApplication.Storage.Repositories
{
  public class StoreRepository : IRepository<Store>
  {
    //private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Revature\dotnet-batch-2021-08-p0\StoreApplication\stores.xml";
    //private static readonly FileAdapter _fileAdapter = new();
    private readonly List<Store> stores;
    public StoreRepository()
    {
      stores = new List<Store>()
      {
        new Store(){ Name = "IKEA", State = "IN", City = "Fishers" },
        new Store(){ Name = "Best Buy", State = "IN", City = "Lafayette" },
        new Store(){ Name = "Home Entertainment", State = "IN", City = "Indianapolis" },
        new Store(){ Name = "Smartphone Accessories and Gizmos", State = "IN", City = "Fort Wayne"},
        new Store(){ Name = "Walmart", State = "IN", City = "Lebanon"},
        new Store(){ Name = "Office Depot", State = "IN", City = "Carmel"}
      };
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Store entry)
    {
      //_fileAdapter.WriteToFile<Store>(_path, new List<Store> { entry });
      stores.Add(entry);
      return true;
    }

    public List<Store> Select()
    {
      //return _fileAdapter.ReadFromFile<Store>(_path);
      return stores;
    }

    public Store Update()
    {
      throw new System.NotImplementedException();
    }
  }
}