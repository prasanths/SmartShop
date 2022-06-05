using SmartShop.Common;
using SmartShop.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Repositories.Interfaces
{
    public interface IProductRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<Pagination<Product>> GetProdcutsByPage(PaginationFilter paginationFilter);
    }
}
