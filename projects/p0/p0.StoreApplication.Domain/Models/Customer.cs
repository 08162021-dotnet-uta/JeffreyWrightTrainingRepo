using System.Collections.Generic;

namespace p0.StoreApplication.Domain.Models
{
  public class Customer
  {
    public string Name { get; set; }
    public List<Order> Orders { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}