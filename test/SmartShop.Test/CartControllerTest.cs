using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SmartShop.Controllers;
using SmartShop.Models;
using SmartShop.Models.Request;
using SmartShop.Models.Response;
using SmartShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartShop.Test
{
    public class CartControllerTest
    {
        private readonly Mock<ICartService<CartRequestModel, CartResponseModel>> _cartService;
        private readonly Mock<ILogger<CartController>> _logger;
        public CartControllerTest()
        {
            _cartService = new Mock<ICartService<CartRequestModel, CartResponseModel>>();
            _logger = new Mock<ILogger<CartController>>();
        }

        [Fact]
        public void GetAll_ListofProdust_CheckIfCartExists()
        {
            //arrange
            var products = GetSampleCart();
            _cartService.Setup(x => x.GetAll())
                .Returns(products);
            var controller = new CartController(_cartService.Object, _logger.Object);

            //act
            var actionResult = controller.Get();
            var result = actionResult as OkObjectResult;
            var actual = result.Value as Task<IEnumerable<CartResponseModel>>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(products.Result.Count(), actual.Result.Count());
        }


        private Task<IEnumerable<CartResponseModel>> GetSampleCart()
        {
            IEnumerable<CartResponseModel> response = new List<CartResponseModel>
            {
                new CartResponseModel()
                {
                   UserId = 1,
                   Total = 2,
                   CartDetails = new List<CartDetailModel>()
                   {
                      new CartDetailModel()
                      {
                          CartId = 1,
                          ProductId = 1,
                          Quantity = 1
                      },
                      new CartDetailModel()
                      {
                          CartId = 1,
                          ProductId = 2,
                          Quantity = 1
                      }
                   }
                },
                new CartResponseModel()
                {
                    UserId = 1,
                   Total = 2,
                   CartDetails = new List<CartDetailModel>()
                   {
                      new CartDetailModel()
                      {
                          CartId = 1,
                          ProductId = 1,
                          Quantity = 3
                      },
                      new CartDetailModel()
                      {
                          CartId = 1,
                          ProductId = 2,
                          Quantity = 1
                      }
                   }
                }
            };
            return Task.FromResult(response);
        }
    }
}
