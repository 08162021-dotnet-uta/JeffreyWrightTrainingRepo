using System.Collections.Generic;
using p0.StoreApplication.Domain.Abstracts;

namespace p0.StoreApplication.Domain.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    public Customer Customer { get; set; }
    public Product Product { get; set; }
    public Store Store { get; set; }
    public List<Product> Products { get; set; }
  }
}