using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class OrderModel : BaseModel
    {
        public int UserId { get; set; }
        public double Total { get; set; }

        public IEnumerable<OrderDetailModel> OrderDetails { get; set; }

        public OrderShippingDetailModel OrderShippingDetail { get; set; }
    }
    public class OrderDetailModel : BaseModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderShippingDetailModel : BaseModel
    {
        public int OrderId { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
    }
}
