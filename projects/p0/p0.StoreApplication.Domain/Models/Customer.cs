using System;
using System.Collections.Generic;

#nullable disable

namespace p0.StoreApplication.Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            StoreOrders = new HashSet<StoreOrder>();
        }

        public short CustomerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StoreOrder> StoreOrders { get; set; }

        public override string ToString()
        {
            return Name;
        }
  }
}
