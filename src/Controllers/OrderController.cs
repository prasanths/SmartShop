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
	[Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN,CUSTOMER")]
	public class OrderController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly ILogger<OrderController> _logger;
		private readonly IOrderService<OrderModel, OrderResponseModel> _orderService;
		public OrderController(IOrderService<OrderModel, OrderResponseModel> orderService, IConfiguration configuration, ILogger<OrderController> logger)
		{
			_configuration = configuration;
			_logger = logger;
			_orderService = orderService;

		}

		[HttpGet]
		public Task<IEnumerable<OrderResponseModel>> Get()
		{
			return _orderService.GetAll();
		}

		// GET: api/Cart/1
		[HttpGet("{id}", Name = "GetOrder")]
		public Task<OrderResponseModel> Get(int id)
		{
			return _orderService.Get(id);
		}

		[HttpPost]
		public IActionResult Create([FromBody] OrderModel requestModel)
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

			return Ok(_orderService.Add(requestModel));
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] OrderModel requestModel)
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

			//var cart = _orderService.Get(id);
			//if (cart == null)
			//{
			//	_logger.LogError($"Owner with id: {id}, hasn't been found in db.");
			//	return NotFound();
			//}

			return Ok(_orderService.Update(requestModel));

			//return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var cart = _orderService.Get(id);
			if (cart == null)
			{
				_logger.LogError($"Cart with id: {id}, hasn't been found in db.");
				return NotFound();
			}

			return Ok(_orderService.Delete(id));

			//return NoContent();
		}
	}
}
