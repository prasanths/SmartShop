using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
	[Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN")]
	[AllowAnonymous]
	public class ProductCategoryController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly ILogger<ProductCategoryController> _logger;
		private readonly IProductCategoryService<ProductCategoryModel, ProductCategoryResponseModel> _productCategoryService;
		public ProductCategoryController(IProductCategoryService<ProductCategoryModel, ProductCategoryResponseModel> productCategoryService, IConfiguration configuration, ILogger<ProductCategoryController> logger)
		{
			_configuration = configuration;
			_logger = logger;
			_productCategoryService = productCategoryService;

		}

		[HttpGet]
		public Task<IEnumerable<ProductCategoryResponseModel>> Get()
		{
			return _productCategoryService.GetAll();
		}

		// GET: api/Cart/1
		[HttpGet("{id}", Name = "GetProductCategory")]
		public Task<ProductCategoryResponseModel> Get(int id)
		{
			return _productCategoryService.Get(id);
		}

		[HttpPost]
		public IActionResult Create([FromBody] ProductCategoryModel cartRequestModel)
		{
			if (cartRequestModel == null)
			{
				_logger.LogError("Cart object from client is null.");
				return BadRequest("Cart is null");
			}

			if (!ModelState.IsValid)
			{
				_logger.LogError("Invalid cart object sent from client.");
				return BadRequest("Invalid model object");
			}

			return Ok(_productCategoryService.Add(cartRequestModel));
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] ProductCategoryModel cartRequestModel)
		{
			if (cartRequestModel == null)
			{
				_logger.LogError("Owner object sent from client is null.");
				return BadRequest("Owner object is null");
			}

			if (!ModelState.IsValid)
			{
				_logger.LogError("Invalid owner object sent from client.");
				return BadRequest("Invalid model object");
			}

			//var cart = _productCategoryService.Get(id);
			//if (cart == null)
			//{
			//	_logger.LogError($"Owner with id: {id}, hasn't been found in db.");
			//	return NotFound();
			//}

			return Ok(_productCategoryService.Update(cartRequestModel));

			//return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var cart = _productCategoryService.Get(id);
			if (cart == null)
			{
				_logger.LogError($"Cart with id: {id}, hasn't been found in db.");
				return NotFound();
			}

			return Ok(_productCategoryService.Delete(id));

			//return NoContent();
		}
	}
}
