using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class CartDetailModel : BaseModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //public CartModel Cart { get; set; }

        //public ProductModel Product { get; set; }
    }
}
