using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace p0.StoreApplication.Storage.Repositories
{
  public class ProductRepository : IRepository<Product>
  {
    private readonly List<Product> products;
    public ProductRepository()
    {
      using var context = new StoreApplicationDBContext();
      products = context.Products.FromSqlRaw<Product>("SELECT * FROM Store.Product").ToList();
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

    public List<Product> Select(Store store)
    {
      using var context = new StoreApplicationDBContext();
      return context.Products.FromSqlRaw<Product>($"SELECT * FROM Store.Product WHERE ProductId IN (SELECT ProductId from Store.StoreInventory WHERE StoreId = {store.StoreId})").ToList();
    }

    public List<Product> Select(StoreOrder order)
    {
      using var context = new StoreApplicationDBContext();
      return context.Products.FromSqlRaw<Product>($"SELECT p.ProductId, [Name], [Description], Price, Quantity FROM Store.Product AS p RIGHT JOIN Store.OrderProduct AS op ON p.ProductId = op.ProductId WHERE OrderId = {order.OrderId}").ToList();
    }

    public bool Update()
    {
      throw new System.NotImplementedException();
    }
  }
}