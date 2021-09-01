using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Abstracts;
using p0.StoreApplication.Storage.Adapters;
using p0.StoreApplication.Domain.Models;
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
        new FurnitureStore(){ Name = "IKEA", State = "IN", City = "Fishers" },
        new TechStore(){ Name = "Best Buy", State = "TX", City = "San Antonio" },
        new MultimediaStore(){ Name = "Home Entertainment", State = "AZ", City = "Mesa" },
        new TechStore(){ Name = "Smartphones and Gizmos", State = "CA", City = "Long Beach"},
        new MultimediaStore(){ Name = "GameStop", State = "DC", City = "Washington"},
        new FurnitureStore(){ Name = "Office Funiture", State = "UT", City = "Orem"}
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