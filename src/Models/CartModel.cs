using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class CartModel : BaseModel
    {
        public int UserId { get; set; }
        public int Total { get; set; }
    }
}
