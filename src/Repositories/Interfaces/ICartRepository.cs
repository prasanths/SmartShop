
namespace SmartShop.Repositories.Interfaces
{
    public interface ICartRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
    }
}
