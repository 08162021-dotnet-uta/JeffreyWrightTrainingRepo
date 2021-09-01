using System;
using System.Xml.Serialization;

namespace p0.StoreApplication.Domain.Models
{
  [Serializable()]
  [XmlRoot("prodcut")]
  public class Product
  {
    [XmlAttribute("id")]
    public int ProdcutId { get; set; }
    [XmlElement("name")]
    public string Name { get; set; }
    [XmlElement("description")]
    public string Description { get; set; }
    [XmlElement("price")]
    public decimal Price { get; set; }
    public override string ToString()
    {
      return Name + ": " + Description + "\n$" + Price;
    }
  }
}