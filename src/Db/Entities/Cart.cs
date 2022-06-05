using SmartShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Db.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public int Total { get; set; }

        public ICollection<CartDetail> CartDetails { get; set; }

        public User User { get; set; }
    }

    public class CartDetail : BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }

        public Product Product { get; set; }
    }
}
