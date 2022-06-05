using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Models.Request
{
    public class CartRequestModel
    {
        public int UserId { get; set; }
        public int Total { get; set; }

        public IList<CartDetailModel> CartDetails { get; set; }

    }
}
