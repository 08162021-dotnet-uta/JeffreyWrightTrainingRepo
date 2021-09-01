using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using p0.StoreApplication.Domain.Models;

namespace p0.StoreApplication.Domain.Abstracts
{
  [Serializable()]
  [XmlRoot("store")]
  public abstract class Store
  {
    [XmlAttribute("id")]
    public int StoreId { get; set; }
    [XmlElement("name")]
    public string Name { get; set; }
    [XmlElement("city")]
    public string City { get; set; }
    [XmlElement("state")]
    public string State { get; set; }
    [XmlElement("orders")]
    public List<Order> Orders { get; set; }
    public List<Product> Products { get; set; }

    public override string ToString()
    {
      return Name + ": " + City + ", " + State;
    }
  }
}