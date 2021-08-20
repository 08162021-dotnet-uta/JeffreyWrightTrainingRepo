using System;

namespace p0.StoreApplication.Domain.Models
{
  public class Store
  {
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public override string ToString()
    {
      return Name + ": " + City + ", " + State;
    }
  }
}