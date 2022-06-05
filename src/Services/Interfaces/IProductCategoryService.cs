using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Services.Interfaces
{
    public interface IProductCategoryService<TEntity, TModel> : IService<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
    }
}
