using AutoMapper;
using ShopBridgeAPI.Application.Features.Products.Commands.CreateProduct;
using ShopBridgeAPI.Application.Features.Products.Dto;
using ShopBridgeAPI.Application.Features.Products.Queries.GetAllProducts;
using ShopBridgeAPI.Domain.Entities;

namespace ShopBridgeAPI.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, ProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
