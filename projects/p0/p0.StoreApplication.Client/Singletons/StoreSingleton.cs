using System.Collections.Generic;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Repositories;

namespace p0.StoreApplication.Client.Singletons
{
  public class StoreSingleton
  {
    private static StoreSingleton _storeSingleton;
    private static readonly StoreRepository _storeRepo = new();
    public List<Store> Stores { get; private set; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_storeSingleton == null)
        {
          _storeSingleton = new StoreSingleton();
        }

        return _storeSingleton;
      }
    }
    private StoreSingleton()
    {
      Stores = _storeRepo.Select();
    }

    public void Add(Store store)
    {
      _storeRepo.Insert(store);
      Stores = _storeRepo.Select();
    }
  }
}