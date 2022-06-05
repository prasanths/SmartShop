using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Services.Interfaces
{
    public interface IService<T, U>
    {
        Task<IEnumerable<U>> GetAll();
        Task<U> Get(int id);
        Task<U> Add(T entity);
        Task<U> Update(T entity);
        Task<U> Delete(int id);
    }
}
