using System;
using System.Collections.Generic;

#nullable disable

namespace p0.StoreApplication.Domain.Models
{
    public partial class StoreOrder
    {
        public StoreOrder()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }
        public short OrderId { get; set; }
        public short CustomerId { get; set; }
        public short StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public override string ToString()
        {
            /*string orderProducts = string.Join("\n", Products);*/
            return "Customer: " + CustomerId + "\nStore: " + StoreId + "\nOrder Date: " + OrderDate /*+ "\nProducts: " + orderProducts*/;
        }
  }
}
