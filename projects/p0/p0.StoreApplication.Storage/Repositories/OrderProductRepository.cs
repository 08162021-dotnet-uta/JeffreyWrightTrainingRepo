using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace p0.StoreApplication.Storage.Repositories
{
  public class OrderProductRepository : IRepository<OrderProduct>
  {
    private readonly List<OrderProduct> orderProducts;
    public OrderProductRepository()
    {
      orderProducts = new List<OrderProduct>(){};
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(OrderProduct entry)
    {
      using var context = new StoreApplicationDBContext();
      context.OrderProducts.Add(entry);
      context.SaveChanges();
      return true;
    }

    public List<OrderProduct> Select()
    {
      return orderProducts;
    }

    public OrderProduct Select(short productId, short orderId)
    {
      using var context = new StoreApplicationDBContext();
      return context.OrderProducts.FromSqlRaw<OrderProduct>(
      $"SELECT * FROM Store.OrderProduct WHERE ProductId = {productId} AND OrderId = {orderId}"
      ).FirstOrDefault();
    }

    public bool Update()
    {
      throw new System.NotImplementedException();
    }
    public bool Update(short productId, short orderId, short quantity)
    {
      using var context = new StoreApplicationDBContext();
      OrderProduct orderProduct = context.OrderProducts.Where(s => s.OrderId == orderId).Where(s => s.ProductId == productId).First<OrderProduct>();
      orderProduct.Quantity = quantity;
      context.SaveChanges();
      return true;
    }
  }
}