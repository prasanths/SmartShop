using AutoMapper;
using SmartShop.Db;
using SmartShop.Db.Entities;
using SmartShop.Models;
using SmartShop.Models.Response;
using SmartShop.Repositories.Interfaces;
using SmartShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Services
{
    public class OrderService : IOrderService<OrderModel, OrderResponseModel>
    {
        private readonly IOrderRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task<OrderResponseModel> Add(OrderModel model)
        {
            var entity = _mapper.Map(model, new Order());
            var returner = _orderRepository.Add(entity);
            return _mapper.Map(returner, Task.FromResult(new OrderResponseModel()));
        }

        public Task<OrderResponseModel> Delete(int id)
        {
            var model = _orderRepository.Delete(id);
            return _mapper.Map(model, Task.FromResult(new OrderResponseModel()));
        }

        public Task<OrderResponseModel> Get(int id)
        {
            var model = _orderRepository.Get(id);
            return _mapper.Map(model, Task.FromResult(new OrderResponseModel()));
        }

        public Task<IEnumerable<OrderResponseModel>> GetAll()
        {
            var model = _orderRepository.GetAll();
            IEnumerable<OrderResponseModel> responseModels = new List<OrderResponseModel>();
            return _mapper.Map(model, Task.FromResult(responseModels));
        }

        public Task<OrderResponseModel> Update(OrderModel model)
        {
            var entity = _mapper.Map(model, new Order());
            var returner = _orderRepository.Add(entity);
            return _mapper.Map(returner, Task.FromResult(new OrderResponseModel()));
        }
    }
}
