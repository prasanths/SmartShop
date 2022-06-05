using SmartShop.Db;
using SmartShop.Db.Entities;
using SmartShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory, SmartShopDbContext>, IProductCategoryRepository<ProductCategory>
    {
        public ProductCategoryRepository(SmartShopDbContext context) : base(context)
        {

        }
    }
}
