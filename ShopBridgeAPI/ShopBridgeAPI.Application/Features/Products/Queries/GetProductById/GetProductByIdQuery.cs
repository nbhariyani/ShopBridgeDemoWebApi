using AutoMapper;
using MediatR;
using ShopBridgeAPI.Application.Exceptions;
using ShopBridgeAPI.Application.Features.Products.Dto;
using ShopBridgeAPI.Application.Interfaces.Repositories;
using ShopBridgeAPI.Application.Wrappers;
using ShopBridgeAPI.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<ProductsViewModel>>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductsViewModel>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            private readonly IProductImageRepositoryAsync _productImageRepository;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IProductRepositoryAsync productRepository, IProductImageRepositoryAsync productImageRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _productImageRepository = productImageRepository;
                _mapper = mapper;
            }

            public async Task<Response<ProductsViewModel>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(query.Id);
                if (product == null) throw new ApiException($"Product Not Found.");
                var productViewModel = _mapper.Map<ProductsViewModel>(product);
                var productImages = await _productImageRepository.GetProductImagesAsync(query.Id);
                if (productImages != null && productImages.Count > 0)
                {
                    productViewModel.ImageNames = productImages.Select(x => x.ImageName).ToList();
                }
                return new Response<ProductsViewModel>(productViewModel);
            }
        }
    }
}
