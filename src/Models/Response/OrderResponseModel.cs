
using System.Collections.Generic;

namespace SmartShop.Models.Response
{
    public class OrderResponseModel
    {
        public int UserId { get; set; }
        public double Total { get; set; }

        public IEnumerable<OrderDetailModel> OrderDetails { get; set; }

        public OrderShippingDetailModel OrderShippingDetail { get; set; }
    }
}
