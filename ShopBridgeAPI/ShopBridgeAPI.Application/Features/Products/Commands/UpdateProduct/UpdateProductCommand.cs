using MediatR;
using ShopBridgeAPI.Application.Exceptions;
using ShopBridgeAPI.Application.Interfaces.Repositories;
using ShopBridgeAPI.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<int>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public UpdateProductCommandHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<int>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id);

                if (product == null)
                {
                    throw new ApiException($"Product Not Found.");
                }
                else
                {
                    product.Name = command.Name;
                    product.Description = command.Description;
                    product.Price = command.Price;
                    await _productRepository.UpdateAsync(product);
                    return new Response<int>(product.Id);
                }
            }
        }
    }

}
