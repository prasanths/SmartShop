using AutoMapper;
using SmartShop.Common;
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
    public class ProductService : IProductService<ProductModel, ProductResponseModel>
    {
        private readonly IProductRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<ProductResponseModel> Add(ProductModel model)
        {
            var entity = _mapper.Map(model, new Product());
            var returner = _productRepository.Add(entity);
            return _mapper.Map(returner, Task.FromResult(new ProductResponseModel()));
        }

        public Task<ProductResponseModel> Delete(int id)
        {
            var model = _productRepository.Delete(id);
            return _mapper.Map(model, Task.FromResult(new ProductResponseModel()));
        }

        public Task<ProductResponseModel> Get(int id)
        {
            var model = _productRepository.Get(id);
            return _mapper.Map(model, Task.FromResult(new ProductResponseModel()));
        }

        public Task<IEnumerable<ProductResponseModel>> GetAll()
        {
            var model = _productRepository.GetAll();
            IEnumerable<ProductResponseModel> responseModels = new List<ProductResponseModel>();
            return _mapper.Map(model, Task.FromResult(responseModels));
        }

        public Task<Pagination<ProductResponseModel>> GetProductsByPage(PaginationFilter paginationFilter)
        {
            var model = _productRepository.GetProdcutsByPage(paginationFilter);
            Pagination<ProductResponseModel> responseModels = new Pagination<ProductResponseModel>();
            return _mapper.Map(model, Task.FromResult(responseModels));
        }

        public Task<ProductResponseModel> Update(ProductModel model)
        {
            var entity = _mapper.Map(model, new Product());
            var returner = _productRepository.Add(entity);
            return _mapper.Map(returner, Task.FromResult(new ProductResponseModel()));
        }
    }
}
