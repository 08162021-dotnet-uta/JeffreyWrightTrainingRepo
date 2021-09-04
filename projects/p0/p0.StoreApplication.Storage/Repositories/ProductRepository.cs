using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;
using System;

namespace p0.StoreApplication.Storage.Repositories
{
  public class ProductRepository : IRepository<Product>
  {
    private readonly List<Product> products;
    //private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Revature\dotnet-batch-2021-08-p0\StoreApplication\products.xml";
    //private static readonly FileAdapter _fileAdapter = new();
    private static readonly DataAdapter _dataAdapter = new();
    public ProductRepository()
    {
      
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Product entry)
    {
      products.Add(entry);
      return true;
    }

    public List<Product> Select()
    {
      return products;
    }

    public Product Update()
    {
      throw new System.NotImplementedException();
    }
  }
}