using Microsoft.Extensions.DependencyInjection;
using SmartShop.Db.Entities;
using SmartShop.Models;
using SmartShop.Models.Request;
using SmartShop.Models.Response;
using SmartShop.Repositories;
using SmartShop.Repositories.Interfaces;
using SmartShop.Services;
using SmartShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Middleswares
{
    public static class ServiceCollectionExtensions
    {
		public static void ConfigureRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IUserRepository<User>, UserRepository>();
			services.AddScoped<ICartRepository<Cart>, CartRepository>();
			services.AddScoped<IOrderRepository<Order>, OrderRepository>();
			services.AddScoped<IProductRepository<Product>, ProductRepository>();
			services.AddScoped<IProductCategoryRepository<ProductCategory>, ProductCategoryRepository>();
		}

		public static void ConfigureServicesWrapper(this IServiceCollection services)
		{
			services.AddScoped<IUserService<UserRequestModel, UserResponseModel>, UserService>();
			services.AddScoped<ICartService<CartRequestModel, CartResponseModel>, CartService>();
			services.AddScoped<IOrderService<OrderModel, OrderResponseModel>, OrderService>();
			services.AddScoped<IProductService<ProductModel, ProductResponseModel>, ProductService>();
			services.AddScoped<IProductCategoryService<ProductCategoryModel, ProductCategoryResponseModel>, ProductCategoryService>();
			services.AddScoped<IAuthService<LoginRequestModel, LoginResponseModel>, AuthService>();
		}
	}
}
