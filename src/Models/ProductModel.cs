using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public string imageUrl { get; set; }

        public int CategoryId { get; set; }

        //public ProductCategoryModel ProductCategory { get; set; }
    }
}
