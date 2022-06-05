using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartShop.Models.Request;
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
    //[AllowAnonymous]
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartService<CartRequestModel,CartResponseModel> _cartService;
        public CartController(ICartService<CartRequestModel, CartResponseModel> cartService, ILogger<CartController> logger)
        {
            _logger = logger;
            _cartService = cartService;

        }

        [HttpGet]
        public IActionResult Get()
        {
			try
			{
				return Ok(_cartService.GetAll());
			}
			catch (Exception e)
			{
				return new BadRequestObjectResult(e.Message);
			}
		}

        // GET: api/Cart/1
        [HttpGet("{id}", Name = "GetCart")]
        public IActionResult Get(int id)
        {
			try
			{
				return Ok(_cartService.Get(id));
			}
			catch (Exception e)
			{
				return new BadRequestObjectResult(e.Message);
			}
		}

		[HttpPost]
		public IActionResult Create([FromBody] CartRequestModel cartRequestModel)
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

			return Ok(_cartService.Add(cartRequestModel));
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] CartRequestModel cartRequestModel)
		{
			if (cartRequestModel == null)
			{
				_logger.LogError("Cart object is null.");
				return BadRequest("Owner object is null");
			}

			if (!ModelState.IsValid)
			{
				_logger.LogError("Invalid owner object sent from client.");
				return BadRequest("Invalid model object");
			}

			var cart = _cartService.Get(id);
			if (cart == null)
			{
				_logger.LogError($"Owner with id: {id}, hasn't been found in db.");
				return NotFound();
			}

			return Ok(_cartService.Update(cartRequestModel));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var cart = _cartService.Get(id);
			if (cart == null)
			{
				_logger.LogError($"Cart with id: {id}, hasn't been found in db.");
				return NotFound();
			}

			return Ok(_cartService.Delete(id));
		}
	}
}
