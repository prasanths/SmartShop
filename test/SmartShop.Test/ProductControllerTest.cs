using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SmartShop.Common;
using SmartShop.Controllers;
using SmartShop.Models;
using SmartShop.Models.Response;
using SmartShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SmartShop.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductService<ProductModel, ProductResponseModel>> _productService;
        private readonly Mock<ILogger<ProductController>> _logger;
        public ProductControllerTest()
        {
            _productService = new Mock<IProductService<ProductModel, ProductResponseModel>>();
            _logger = new Mock<ILogger<ProductController>>();
        }

        [Fact]
        public void GetAll_ListofProdust_CheckIfProductsExists()
        {
            //arrange
            var products = GetSampleProducts();
            _productService.Setup(x => x.GetAll())
                .Returns(products);
            var controller = new ProductController(_productService.Object, _logger.Object);

            //act
            var actionResult = controller.Get();
            var result = actionResult as OkObjectResult;
            var actual = result.Value as Task<IEnumerable<ProductResponseModel>>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(products.Result.Count(), actual.Result.Count());
        }

        [Fact]
        public void GetAll_ListofProdust_CheckIfProductsWithNameExists()
        {
            //arrange
            var products = GetSampleProducts();
            var pagedModel = new Pagination<ProductResponseModel>();
            
            var pageinationFilter = new PaginationFilter()
            {
              SearchKeyword = "prod",
              IsDesc = true,
              OrderBy = "Name",
              PageNumber = 1,
              PageSize = 10
            };

            pagedModel.Result = products.Result.ToList();
            pagedModel.OrderBy = pageinationFilter.OrderBy;

            _productService.Setup(x => x.GetProductsByPage(pageinationFilter))
                .Returns(Task.FromResult(pagedModel));
            var controller = new ProductController(_productService.Object, _logger.Object);

            //act
            var actionResult = controller.GetProductsByPage(pageinationFilter);
            var result = actionResult as OkObjectResult;
            var actual = result.Value as Task<Pagination<ProductResponseModel>>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(products.Result.Count(), actual.Result.Result.Count());
        }

        private Task<IEnumerable<ProductResponseModel>> GetSampleProducts()
        {
            IEnumerable<ProductResponseModel> response = new List<ProductResponseModel>
            {
                new ProductResponseModel()
                {
                    Name = "Product 1",
                    CategoryId = 1,
                    Description = "Product 1 Descritpion",
                    Price = 250
                },
                new ProductResponseModel()
                {
                    Name = "Product 2",
                    CategoryId = 1,
                    Description = "Product 2 Descritpion",
                    Price = 50
                },
                new ProductResponseModel()
                {
                    Name = "Product 3",
                    CategoryId = 1,
                    Description = "Product 3 Descritpion",
                    Price = 100
                }
            };
            return Task.FromResult(response);
        }
    }
}
