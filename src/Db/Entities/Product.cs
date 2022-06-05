using SmartShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Db.Entities
{
    public class Product : BaseEntity
    {
        [Sortable(OrderBy = "Name")]
        public string Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public string imageUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
