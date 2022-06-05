using AutoMapper;
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
    public class ProductCategoryService : IProductCategoryService<ProductCategoryModel, ProductCategoryResponseModel>
    {
        private readonly IProductCategoryRepository<ProductCategory> _productCategoryRepository;
        private readonly IMapper _mapper;
        public ProductCategoryService(IProductCategoryRepository<ProductCategory> productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public Task<ProductCategoryResponseModel> Add(ProductCategoryModel model)
        {
            var entity = _mapper.Map(model, new ProductCategory());
            var returner = _productCategoryRepository.Add(entity);
            return _mapper.Map(returner, Task.FromResult(new ProductCategoryResponseModel()));
        }

        public Task<ProductCategoryResponseModel> Delete(int id)
        {
            var model = _productCategoryRepository.Delete(id);
            return _mapper.Map(model, Task.FromResult(new ProductCategoryResponseModel()));
        }

        public Task<ProductCategoryResponseModel> Get(int id)
        {
            var model = _productCategoryRepository.Get(id);
            return _mapper.Map(model, Task.FromResult(new ProductCategoryResponseModel()));
        }

        public Task<IEnumerable<ProductCategoryResponseModel>> GetAll()
        {
            var model = _productCategoryRepository.GetAll();
            IEnumerable<ProductCategoryResponseModel> responseModels = new List<ProductCategoryResponseModel>();
            return _mapper.Map(model, Task.FromResult(responseModels));
        }

        public Task<ProductCategoryResponseModel> Update(ProductCategoryModel model)
        {
            var entity = _mapper.Map(model, new ProductCategory());
            var returner = _productCategoryRepository.Update(entity);
            return _mapper.Map(returner, Task.FromResult(new ProductCategoryResponseModel()));
        }
    }
}
