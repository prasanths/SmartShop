using AutoMapper;
using SmartShop.Db;
using SmartShop.Db.Entities;
using SmartShop.Models.Request;
using SmartShop.Models.Response;
using SmartShop.Repositories.Interfaces;
using SmartShop.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartShop.Services
{
    public class CartService : ICartService<CartRequestModel, CartResponseModel>
    {
        private readonly ICartRepository<Cart> _cartRepository;
        private readonly IMapper _mapper;
        public CartService(ICartRepository<Cart> cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public Task<CartResponseModel> Add(CartRequestModel model)
        {
            var entity = _mapper.Map(model, new Cart());
            var returner = _cartRepository.Add(entity);
            return _mapper.Map(returner, Task.FromResult(new CartResponseModel()));
        }

        public Task<CartResponseModel> Delete(int id)
        {
            var model = _cartRepository.Delete(id);
            return _mapper.Map(model, Task.FromResult(new CartResponseModel()));
        }

        public Task<CartResponseModel> Get(int id)
        {
            var model = _cartRepository.Get(id);
            return _mapper.Map(model, Task.FromResult(new CartResponseModel()));
        }

        public Task<IEnumerable<CartResponseModel>> GetAll()
        {
            var model = _cartRepository.GetAll();
            IEnumerable<CartResponseModel> responseModels = new List<CartResponseModel>();
            return _mapper.Map(model, Task.FromResult(responseModels));
        }

        public Task<CartResponseModel> Update(CartRequestModel model)
        {
            var entity = _mapper.Map(model, new Cart());
            var returner = _cartRepository.Add(entity);
            return _mapper.Map(returner, Task.FromResult(new CartResponseModel()));
        }
    }
}
