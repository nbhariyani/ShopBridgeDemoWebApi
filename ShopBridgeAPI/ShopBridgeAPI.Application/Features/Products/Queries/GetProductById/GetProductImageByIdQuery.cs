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
    public class GetProductImageByIdQuery : IRequest<Response<ProductImageViewModel>>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public class GetProductImageByIdQueryHandler : IRequestHandler<GetProductImageByIdQuery, Response<ProductImageViewModel>>
        {
            private readonly IProductImageRepositoryAsync _productImageRepository;
            private readonly IMapper _mapper;

            public GetProductImageByIdQueryHandler(IProductImageRepositoryAsync productImageRepository, IMapper mapper)
            {
                _productImageRepository = productImageRepository;
                _mapper = mapper;
            }

            public async Task<Response<ProductImageViewModel>> Handle(GetProductImageByIdQuery query, CancellationToken cancellationToken)
            {
                var productImage = await _productImageRepository.GetByIdAsync(query.Id);
                if (productImage == null) throw new ApiException($"Image Not Found.");
                if (query.ProductId != 0 && productImage.ProductId != query.ProductId) throw new ApiException($"Image not found for this product.");
                var productImageViewModel = _mapper.Map<ProductImageViewModel>(productImage);
                return new Response<ProductImageViewModel>(productImageViewModel);
            }
        }
    }
}
