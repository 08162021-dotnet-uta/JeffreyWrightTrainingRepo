using Microsoft.EntityFrameworkCore;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p0.StoreApplication.Storage.Repositories
{
  class EF_Orders
  {
    private readonly DataAdapter _dataAdapter = new();

    public List<Order> GetOrders()
    {
      return _dataAdapter.Orders.FromSqlRaw("Select * from Store.StoreOrder").ToList();
    }

    public void SetOrder(Order order)
    {
      _dataAdapter.Database.ExecuteSqlRaw("insert into Store.Order(orderid, customerid, storeid, orderdate) values ({0})", order.OrderId);
    }
  }
}
