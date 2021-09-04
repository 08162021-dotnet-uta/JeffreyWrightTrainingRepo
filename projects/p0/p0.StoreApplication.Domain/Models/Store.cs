using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p0.StoreApplication.Domain.Models
{
  [Serializable()]
  public class Store
  {
    public short StoreId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public List<Order> Orders { get; set; }
    public List<Product> Products { get; set; }

    public override string ToString()
    {
      return Name + ": " + City + ", " + State;
    }
  }
}
