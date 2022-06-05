using SmartShop.Models.Request;
using SmartShop.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Services.Interfaces
{
    public interface IAuthService<TEntity, TModel> //: IService<TEntity, TModel>
    {
        LoginResponseModel Login(LoginRequestModel loginRequestLogin);
    }
}
