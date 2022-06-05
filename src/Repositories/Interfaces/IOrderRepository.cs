using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Repositories.Interfaces
{
    public interface IOrderRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
    }
}
