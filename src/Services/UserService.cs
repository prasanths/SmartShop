using AutoMapper;
using SmartShop.Db;
using SmartShop.Db.Entities;
using SmartShop.Models;
using SmartShop.Models.Request;
using SmartShop.Models.Response;
using SmartShop.Repositories.Interfaces;
using SmartShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Services
{
    public class UserService : IUserService<UserRequestModel, UserResponseModel>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UserResponseModel> Add(UserRequestModel model)
        {
            var entity = _mapper.Map(model, new User());
            var returner = _userRepository.Add(entity);
            return _mapper.Map(returner, Task.FromResult(new UserResponseModel()));
        }

        public Task<UserResponseModel> Delete(int id)
        {
            var model = _userRepository.Delete(id);
            return _mapper.Map(model, Task.FromResult(new UserResponseModel()));
        }
        public Task<UserResponseModel> GetUserByEmail(string email)
        {
            var model = _userRepository.GetUserByEmail(email);
            return _mapper.Map(model, Task.FromResult(new UserResponseModel()));
        }

        public Task<UserResponseModel> Get(int id)
        {
            var model = _userRepository.Get(id);
            return _mapper.Map(model, Task.FromResult(new UserResponseModel()));
        }

        public Task<IEnumerable<UserResponseModel>> GetAll()
        {
            var model = _userRepository.GetAll();
            IEnumerable<UserResponseModel> responseModels = new List<UserResponseModel>();
            return _mapper.Map(model, Task.FromResult(responseModels));
        }

        public Task<UserResponseModel> Update(UserRequestModel model)
        {
            var entity = _mapper.Map(model, new User());
            var returner = _userRepository.Add(entity);
            return _mapper.Map(returner, Task.FromResult(new UserResponseModel()));
        }
    }
}
