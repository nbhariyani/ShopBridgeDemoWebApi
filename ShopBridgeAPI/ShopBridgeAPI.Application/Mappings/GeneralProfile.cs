using AutoMapper;
using ShopBridgeAPI.Application.Features.Products.Commands.CreateProduct;
using ShopBridgeAPI.Application.Features.Products.Commands.UpdateProduct;
using ShopBridgeAPI.Application.Features.Products.Commands.UploadProductImage;
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
            CreateMap<ProductImage, ProductImageViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UploadProductImageCommand, ProductImage>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            CreateMap<GetAllProductImagesQuery, GetAllProductsParameter>();
        }
    }
}
