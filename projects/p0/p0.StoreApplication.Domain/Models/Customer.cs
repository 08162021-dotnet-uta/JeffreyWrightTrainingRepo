using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace p0.StoreApplication.Domain.Models
{
  [Serializable()]
  [XmlRoot("customer")]
  public class Customer
  {
    [XmlAttribute("id")]
    public int CustomerId { get; set; }
    [XmlElement("name")]
    public string Name { get; set; }
    [XmlElement("orders")]
    public List<Order> Orders { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}