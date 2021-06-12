using AutoMapper;
using MediatR;
using ShopBridgeAPI.Application.Features.Products.Dto;
using ShopBridgeAPI.Application.Interfaces.Repositories;
using ShopBridgeAPI.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductImagesQuery : IRequest<PagedResponse<IEnumerable<ProductImageViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllProductImagesQueryHandler : IRequestHandler<GetAllProductImagesQuery, PagedResponse<IEnumerable<ProductImageViewModel>>>
    {
        private readonly IProductImageRepositoryAsync _productImageRepository;
        private readonly IMapper _mapper;
        public GetAllProductImagesQueryHandler(IProductImageRepositoryAsync productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ProductImageViewModel>>> Handle(GetAllProductImagesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllProductsParameter>(request);
            var product = await _productImageRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var productImageViewModel = _mapper.Map<IEnumerable<ProductImageViewModel>>(product);
            return new PagedResponse<IEnumerable<ProductImageViewModel>>(productImageViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
