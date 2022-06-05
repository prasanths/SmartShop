using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Db.Entities
{
    public class OrderShippingDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }

        public Order Order { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; internal set; }
    }
}
