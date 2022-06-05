using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartShop.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }

    public interface IEntity
    {
        int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
