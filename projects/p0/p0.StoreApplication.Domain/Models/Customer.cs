using System;
using System.Collections.Generic;

namespace p0.StoreApplication.Domain.Models
{
  [Serializable()]
  public class Customer
  {
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}