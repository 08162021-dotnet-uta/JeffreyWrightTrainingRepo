using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace p0.StoreApplication.Storage.Repositories
{
  public class StoreRepository : IRepository<Store>
  {
    private readonly List<Store> stores;
    public StoreRepository()
    {
      using var context = new StoreApplicationDBContext();
      stores = context.Stores.FromSqlRaw<Store>("SELECT * FROM Store.Store").ToList();
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
    public Store Select(short id)
    {
      using var context = new StoreApplicationDBContext();
      return context.Stores.FromSqlRaw<Store>($"SELECT * FROM Store.Store WHERE StoreId = {id}").FirstOrDefault();
    }
    public bool Update()
    {
      throw new System.NotImplementedException();
    }
  }
}