using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace p0.StoreApplication.Storage.Repositories
{
  public class OrderRepository : IRepository<StoreOrder>
  {
    private readonly List<StoreOrder> orders;
    public OrderRepository()
    {
      orders = new List<StoreOrder>(){};
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(StoreOrder entry)
    {
      using var context = new StoreApplicationDBContext();
      context.StoreOrders.Add(entry);
      context.SaveChanges();
      return true;
    }

    public List<StoreOrder> Select()
    {
      return orders;
    }

    public List<StoreOrder> Select(Store store)
    {
      using var context = new StoreApplicationDBContext();
      return context.StoreOrders.Where(s => s.StoreId == store.StoreId).ToList();
    }

    public List<StoreOrder> Select(Customer customer)
    {
      using var context = new StoreApplicationDBContext();
      return context.StoreOrders.FromSqlRaw<StoreOrder>(
      $"SELECT * FROM Store.StoreOrder AS o WHERE o.CustomerId = {customer.CustomerId}; "
      ).ToList();
    }
    /// <summary>
    /// Selects the latest order from the StoreOrder table by order date
    /// </summary>
    /// <returns></returns>
    public StoreOrder SelectLastOrder()
    {
      using var context = new StoreApplicationDBContext();
      return context.StoreOrders.FromSqlRaw<StoreOrder>(
      $"SELECT * FROM Store.StoreOrder"
      ).OrderBy(s => s.OrderDate).LastOrDefault();
    }

    public bool Update()
    {
      throw new System.NotImplementedException();
    }
  }
}