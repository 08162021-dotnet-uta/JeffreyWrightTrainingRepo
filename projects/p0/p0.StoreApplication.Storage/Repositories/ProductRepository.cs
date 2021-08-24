using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;

namespace p0.StoreApplication.Storage.Repositories
{
  public class ProductRepository : IRepository<Product>
  {
    private const string _path = @"/home/jeffrey/revature/training_repo/data/products.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();
    public ProductRepository()
    {

    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Product entry)
    {
      _fileAdapter.WriteToFile<Product>(_path, entry);
      return true;
    }

    public List<Product> Select()
    {
      return _fileAdapter.ReadFromFile<List<Product>>(_path);
    }

    public Product Update()
    {
      throw new System.NotImplementedException();
    }
  }
}