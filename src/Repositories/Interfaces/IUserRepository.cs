using SmartShop.Db.Entities;

namespace SmartShop.Repositories.Interfaces
{
    public interface IUserRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        User GetUserByEmail(string email);
    }
}
