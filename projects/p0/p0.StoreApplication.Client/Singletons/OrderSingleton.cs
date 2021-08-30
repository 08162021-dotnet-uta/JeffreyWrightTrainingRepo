using System.Collections.Generic;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Repositories;

namespace p0.StoreApplication.Client.Singletons
{
  public class OrderSingleton
  {
    private static OrderSingleton _orderSingleton;
    private static readonly OrderRepository _orderRepo = new();
    public List<Order> Orders { get; private set; }
    public static OrderSingleton Instance
    {
      get
      {
        if (_orderSingleton == null)
        {
          _orderSingleton = new OrderSingleton();
        }

        return _orderSingleton;
      }
    }
    private OrderSingleton()
    {
      Orders = _orderRepo.Select();
    }

    public void Add(Order order)
    {
      _orderRepo.Insert(order);
      Orders = _orderRepo.Select();
    }
  }
}