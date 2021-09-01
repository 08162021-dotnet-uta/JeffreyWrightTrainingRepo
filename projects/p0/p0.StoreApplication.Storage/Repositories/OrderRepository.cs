using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;
using System;

namespace p0.StoreApplication.Storage.Repositories
{
  public class OrderRepository : IRepository<Order>
  {
    private readonly List<Order> orders;
    //private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Revature\dotnet-batch-2021-08-p0\StoreApplication\orders.xml";
    //private static readonly FileAdapter _fileAdapter = new();
    public OrderRepository()
    {
      orders = new List<Order>(){};
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Order entry)
    {
      orders.Add(entry);
      return true;
    }

    public List<Order> Select()
    {
      return orders;
    }

    public Order Update()
    {
      throw new System.NotImplementedException();
    }
  }
}