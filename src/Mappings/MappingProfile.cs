using AutoMapper;
using SmartShop.Common;
using SmartShop.Db.Entities;
using SmartShop.Models;
using SmartShop.Models.Request;
using SmartShop.Models.Response;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //AddGlobalIgnore("");
            CreateMap<UserRequestModel, User>();
            CreateMap<User, UserRequestModel>();
            CreateMap<User, UserResponseModel>();
            CreateMap<UserRequestModel, UserResponseModel>();

            CreateMap<CartDetailModel, CartDetail>()                
                .ForMember(_ => _.Product,
                x => x.Ignore())
                .ForMember(_ => _.Cart,
                x => x.Ignore());

            CreateMap<CartRequestModel, Cart>()
                .ForMember(_=>_.CartDetails,
                x=>x.MapFrom(opt=>opt.CartDetails))
                .ForMember(_ => _.User,
                x => x.Ignore());

            //CreateMap<Task<CartRequestModel>, Task<Cart>>();
            //.ForMember(_ => _.CartDetails,
            //x => x.MapFrom(opt => opt.CartDetails));

            //CreateMap<Cart, CartRequestModel>();
            CreateMap<Task<Cart>, Task<CartResponseModel>>(MemberList.None);
            CreateMap<Cart, CartResponseModel>(MemberList.None) //MemberList.None
                .ForMember(_ => _.CartDetails,
                x => x.MapFrom(opt => opt.CartDetails))
                .ForMember(_ => _.User,
                x => x.Ignore())
                .ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();


            CreateMap<CartDetailModel, CartDetail>()
                .ForMember(_ => _.Product,
                x => x.Ignore())
                .ForMember(_ => _.Cart,
                x => x.Ignore());

            CreateMap<CartRequestModel, Cart>()
                .ForMember(_ => _.CartDetails,
                x => x.MapFrom(opt => opt.CartDetails))
                .ForMember(_ => _.User,
                x => x.Ignore());

            CreateMap<Task<ProductCategory>, Task<ProductCategoryModel>>(MemberList.None).ReverseMap();
            CreateMap<Task<ProductCategoryModel>, Task<ProductCategoryResponseModel>>(MemberList.None).ReverseMap();
            CreateMap<Task<ProductCategory>, Task<ProductCategoryResponseModel>>(MemberList.None).ReverseMap();
            //CreateMap<Task<ProductCategoryModel>, Task<ProductCategory>>(MemberList.None);
            CreateMap<ProductCategoryModel, ProductCategory>(MemberList.None)
                .ForMember(_ => _.Products,
                x => x.Ignore()).ReverseMap();
            CreateMap<ProductCategoryModel, ProductCategoryResponseModel>(MemberList.None).ReverseMap();
            CreateMap<ProductCategory, ProductCategoryModel>();
            CreateMap<ProductCategory, ProductCategoryResponseModel>(MemberList.None).ReverseMap();

            CreateMap<Task<IEnumerable<ProductCategory>>, Task<IEnumerable<ProductCategoryResponseModel>>>(MemberList.None).ReverseMap();



            CreateMap<Task<Product>, Task<ProductModel>>(MemberList.None)
                .ForMember(_ => _.Result,
                x => x.MapFrom(opt => opt.Result))
                .ReverseMap();
            CreateMap<Task<ProductModel>, Task<ProductResponseModel>>(MemberList.None)
                .ForMember(_ => _.Result,
                x => x.MapFrom(opt => opt.Result))
                .ReverseMap();
            CreateMap<Task<Product>, Task<ProductResponseModel>>(MemberList.None)
                 .ForMember(_ => _.Result,
                x => x.MapFrom(opt => opt.Result))
                .ReverseMap();
            //CreateMap<Task<ProductCategoryModel>, Task<ProductCategory>>(MemberList.None);
            CreateMap<ProductModel, Product>(MemberList.None)
                .ForMember(_ => _.ProductCategory,
                x => x.Ignore())
                .ForMember(_ => _.OrderDetails,
                x => x.Ignore()).ReverseMap();

            CreateMap<Task<Pagination<Product>>, Task<Pagination<ProductResponseModel>>>(MemberList.None)
                
                .ForMember(_ => _.Result,
                x => x.MapFrom(opt => opt.Result))
                .IgnoreAllUnwanted()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            //.ReverseMap();

            CreateMap<Pagination<Product>, Pagination<ProductResponseModel>>(MemberList.None)
                //.ForMember(_ => _.Result,
                //x => x.MapFrom(opt => opt.Result))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
                //.ReverseMap();

            CreateMap<ProductModel, ProductResponseModel>(MemberList.None).ReverseMap();
            CreateMap<Product, ProductModel>();
            CreateMap<Product, ProductResponseModel>(MemberList.None).ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Task<IEnumerable<Product>>, Task<IEnumerable<ProductResponseModel>>>(MemberList.None).ReverseMap();


            CreateMap<Task<Order>, Task<OrderModel>>(MemberList.None).ReverseMap();
            CreateMap<Task<OrderModel>, Task<OrderResponseModel>>(MemberList.None).ReverseMap();
            CreateMap<Task<Order>, Task<OrderResponseModel>>(MemberList.None).ReverseMap();
            //CreateMap<Task<ProductCategoryModel>, Task<ProductCategory>>(MemberList.None);
            CreateMap<OrderModel, Order>(MemberList.None)
                .ForMember(_ => _.OrderDetails,
                x => x.Ignore())
                .ForMember(_ => _.OrderShippingDetail,
                x => x.Ignore()).ReverseMap();
            CreateMap<OrderModel, OrderResponseModel>(MemberList.None).ReverseMap();
            CreateMap<Order, OrderModel>();
            CreateMap<Order, OrderResponseModel>(MemberList.None).ReverseMap();

            CreateMap<Task<IEnumerable<Order>>, Task<IEnumerable<OrderResponseModel>>>(MemberList.None).ReverseMap();


            CreateMap<Task<User>, Task<UserModel>>(MemberList.None).ReverseMap()
                .ForMember(_ => _.Result,
                x => x.MapFrom(opt => opt.Result))
                .ReverseMap(); ;
            CreateMap<Task<UserModel>, Task<UserResponseModel>>(MemberList.None).ReverseMap()
                .ForMember(_ => _.Result,
                x => x.MapFrom(opt => opt.Result))
                .ReverseMap(); ;
            CreateMap<Task<User>, Task<UserResponseModel>>(MemberList.None).ReverseMap()
                .ForMember(_ => _.Result,
                x => x.MapFrom(opt => opt.Result))
                .ReverseMap(); ;
            CreateMap<UserModel, User>(MemberList.None)
                .ForMember(_ => _.UserAddresses,
                x => x.Ignore()).ReverseMap();
            CreateMap<UserModel, UserResponseModel>(MemberList.None).ReverseMap();
            CreateMap<User, UserModel>();
            CreateMap<User, UserResponseModel>(MemberList.None).ReverseMap();

            CreateMap<Task<IEnumerable<Order>>, Task<IEnumerable<UserResponseModel>>>(MemberList.None).ReverseMap();
        }

        
    }

    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDest> IgnoreAllUnwanted<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            //expression.ForAllMembers(opt => opt.Ignore());
            var sourceType = typeof(TDest);//

            if(sourceType.GetGenericTypeDefinition() == typeof(Task<>)) {
                var t = sourceType.GetProperties().Where(p => p.Name != "Result" && p.Name != "Factory");
                foreach (var property in t)
                {
                    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }


}
