using System;
using System.Collections.Generic;
using p0.StoreApplication.Domain.Models;

namespace p0.StoreApplication.Domain.Abstracts
{
  public abstract class Store
  {
    public int StoreId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public List<Order> Orders { get; set; }

    public override string ToString()
    {
      return Name + ": " + City + ", " + State;
    }
  }
}