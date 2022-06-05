using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartShop.Common;
using SmartShop.Models;
using SmartShop.Models.Response;
using SmartShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN,CUSTOMER")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService<ProductModel, ProductResponseModel> _productService;
        public ProductController(IProductService<ProductModel, ProductResponseModel> productService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("filter")]
        public IActionResult GetProductsByPage([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                return Ok(_productService.GetProductsByPage(paginationFilter));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        // GET: api/Cart/1
        [HttpGet("{id}", Name = "GetProduct")]
        public Task<ProductResponseModel> Get(int id)
        {
            return _productService.Get(id);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN")]
        public IActionResult Create([FromBody] ProductModel requestModel)
        {
            if (requestModel == null)
            {
                _logger.LogError("Cart object from client is null.");
                return BadRequest("Cart is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid cart object sent from client.");
                return BadRequest("Invalid model object");
            }

            return Ok(_productService.Add(requestModel));
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN")]
        public IActionResult Update(int id, [FromBody] ProductModel requestModel)
        {
            if (requestModel == null)
            {
                _logger.LogError("Owner object sent from client is null.");
                return BadRequest("Owner object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid owner object sent from client.");
                return BadRequest("Invalid model object");
            }

            var cart = _productService.Get(id);
            if (cart == null)
            {
            	_logger.LogError($"Owner with id: {id}, hasn't been found in db.");
            	return NotFound();
            }

            return Ok(_productService.Update(requestModel));
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            var cart = _productService.Get(id);
            if (cart == null)
            {
                _logger.LogError($"Cart with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            return Ok(_productService.Delete(id));
        }
    }
}
