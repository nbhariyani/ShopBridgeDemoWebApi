using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ShopBridgeAPI.Application.Exceptions;
using ShopBridgeAPI.Application.Interfaces.Repositories;
using ShopBridgeAPI.Application.Wrappers;
using ShopBridgeAPI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Application.Features.Products.Commands.UploadProductImage
{
    public partial class UploadProductImageCommand : IRequest<Response<int>>
    {
        public int ProductId { get; set; }
        public string ImageName { get; set; }

        public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommand, Response<int>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            private readonly IProductImageRepositoryAsync _productImageRepository;
            private readonly IMapper _mapper;
            public UploadProductImageCommandHandler(IProductRepositoryAsync productRepository, IProductImageRepositoryAsync productImageRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _productImageRepository = productImageRepository;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(request.ProductId);
                if (product == null) throw new ApiException($"Product Not Found.");
                var productImage = _mapper.Map<ProductImage>(request);
                await _productImageRepository.AddAsync(productImage);
                return new Response<int>(productImage.Id);
            }
        }
    }
}
