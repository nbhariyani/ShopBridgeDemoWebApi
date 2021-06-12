using FluentValidation;
using ShopBridgeAPI.Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepositoryAsync productRepository;

        public UpdateProductCommandValidator(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueProductName).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} should be greater than equal to zero.");
        }
        private async Task<bool> IsUniqueProductName(UpdateProductCommand model, string productname, CancellationToken cancellationToken)
        {
            return await productRepository.IsUniqueProductNameAsync(productname, model.Id);
        }

    }
}
