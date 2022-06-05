using SmartShop.Common;
using SmartShop.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Services.Interfaces
{
    public interface IProductService<TEntity, TModel> : IService<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        Task<Pagination<ProductResponseModel>> GetProductsByPage(PaginationFilter paginationFilter);
    }
}
