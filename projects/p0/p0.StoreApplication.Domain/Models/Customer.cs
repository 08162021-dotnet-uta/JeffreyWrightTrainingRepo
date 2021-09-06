using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace p0.StoreApplication.Domain.Models
{
  [Serializable()]
  public class Customer
  {
    private string name;
    public short CustomerId { get; set; }
    public string Name
    { get; set; }
    public List<Order> Orders { get; } = new List<Order>();

    public override string ToString()
    {
      return Name;
    }
  }
}