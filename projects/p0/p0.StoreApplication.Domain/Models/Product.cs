using System;
using System.Xml.Serialization;

namespace p0.StoreApplication.Domain.Models
{
  [Serializable()]
  public class Product
  {
    public short ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public override string ToString()
    {
      return Name + ": " + Description + "\n$" + Price;
    }
  }
}