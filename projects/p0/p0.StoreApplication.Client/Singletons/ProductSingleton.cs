using System.Collections.Generic;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Repositories;

namespace p0.StoreApplication.Client.Singletons
{
  public class ProductSingleton
  {
    private static ProductSingleton _productSingleton;
    private static readonly ProductRepository _productRepo = new();
    public List<Product> Products { get; private set; }
    public static ProductSingleton Instance
    {
      get
      {
        if (_productSingleton == null)
        {
          _productSingleton = new ProductSingleton();
        }

        return _productSingleton;
      }
    }
    private ProductSingleton()
    {
      Products = _productRepo.Select();
    }

    public void Add(Product product)
    {
      _productRepo.Insert(product);
      Products = _productRepo.Select();
    }
    public List<Product> QueryProductList(Store store)
    {
      return _productRepo.Select(store);
    }
    public List<Product> QueryProductList(StoreOrder order)
    {
      return _productRepo.Select(order);
    }
  }
}