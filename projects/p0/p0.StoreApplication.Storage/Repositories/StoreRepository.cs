using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Abstracts;
using p0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;

namespace p0.StoreApplication.Storage.Repositories
{
  public class StoreRepository : IRepository<Store>
  {
    private const string _path = @"/home/jeffrey/revature/training_repo/data/stores.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public StoreRepository()
    {

    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Store entry)
    {
      _fileAdapter.WriteToFile<Store>(_path, entry);
      return true;
    }

    public List<Store> Select()
    {
      return _fileAdapter.ReadFromFile<List<Store>>(_path);
    }

    public Store Update()
    {
      throw new System.NotImplementedException();
    }
  }
}