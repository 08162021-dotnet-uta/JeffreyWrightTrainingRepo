using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Abstracts;
using p0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;
using System;

namespace p0.StoreApplication.Storage.Repositories
{
  public class StoreRepository : IRepository<Store>
  {
    private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Revature\dotnet-batch-2021-08-p0\StoreApplication\stores.xml";
    private static readonly FileAdapter _fileAdapter = new();
    public StoreRepository()
    {
      if (_fileAdapter.ReadFromFile<Store>(_path) == null)
      {
        _fileAdapter.WriteToFile<Store>(_path, new List<Store>());
      }
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Store entry)
    {
      _fileAdapter.WriteToFile<Store>(_path, new List<Store> { entry });
      return true;
    }

    public List<Store> Select()
    {
      return _fileAdapter.ReadFromFile<Store>(_path);
    }

    public Store Update()
    {
      throw new System.NotImplementedException();
    }
  }
}