using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace p0.StoreApplication.Domain.Models
{
  [Serializable()]
  public class Order
  {
    public int OrderId { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public Store Store { get; set; }
    public List<Product> Products { get; set; }
    public override string ToString()
    {
      string orderProducts = string.Join("\n", Products);
      return "Customer: " + Customer + "\nStore: " + Store + "\nOrder Date: " + OrderDate + "\nProducts: " + orderProducts;
    }
  }
}