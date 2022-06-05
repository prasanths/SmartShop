using SmartShop.Db.Entities;
using SmartShop.Models.Request;
using SmartShop.Models.Response;
using System.Threading.Tasks;

namespace SmartShop.Services.Interfaces
{
    public interface IUserService<TEntity, TModel> : IService<TEntity, TModel> 
        where TEntity : class        
        where TModel:class
    {
        Task<UserResponseModel> GetUserByEmail(string email);
    }
}
