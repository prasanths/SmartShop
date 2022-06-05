using SmartShop.Common;
using SmartShop.Db;
using SmartShop.Db.Entities;
using SmartShop.Helpers;
using SmartShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Repositories
{
    public class ProductRepository : BaseRepository<Product, SmartShopDbContext>, IProductRepository<Product>
    {
        private readonly SmartShopDbContext _context;
        public ProductRepository(SmartShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pagination<Product>> GetProdcutsByPage(PaginationFilter paginationFilter)
        {
            // Add search
            IQueryable<Product> query = null;
            if (!string.IsNullOrEmpty(paginationFilter.SearchKeyword)){
                query = _context.Products.Where(x => paginationFilter.SearchKeyword.ToLower().Contains(x.Name.ToLower())).AsQueryable();
            }
            else
            {
                query = _context.Products.AsQueryable();
            }
            return await PaginationHelper.GetPagination(query, paginationFilter.PageNumber, paginationFilter.PageSize, paginationFilter.OrderBy, paginationFilter.IsDesc);
                
        }
    }
}
