using SmartShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Db.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public double Total { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public OrderShippingDetail OrderShippingDetail { get; set; }
        public DateTime Date { get; set; }
    }
}
