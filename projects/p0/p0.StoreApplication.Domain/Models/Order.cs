using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using p0.StoreApplication.Domain.Abstracts;

namespace p0.StoreApplication.Domain.Models
{
  [Serializable()]
  [XmlRoot("order")]
  public class Order
  {
    [XmlAttribute("id")]
    public int OrderId { get; set; }
    [XmlElement("customer")]
    public Customer Customer { get; set; }
    [XmlElement("orderdate")]
    public DateTime OrderDate { get; set; }
    [XmlElement("store")]
    public Store Store { get; set; }
    [XmlElement("products")]
    public List<Product> Products { get; set; }
    public override string ToString()
    {
      string orderProducts = string.Join("\n", Products);
      return "Customer: " + Customer + "\nStore: " + Store + "\nOrder Date: " + OrderDate + "\nProducts: " + orderProducts;
    }
  }
}