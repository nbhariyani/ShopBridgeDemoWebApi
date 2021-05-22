using FluentValidation;
using ShopBridgeAPI.Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepositoryAsync productRepository;

        public CreateProductCommandValidator(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;

            RuleFor(p => p.ProductCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(3).WithMessage("{PropertyName} must be minimum 3 characters.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueProductCode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} should be greater than equal to zero.");
        }

        private async Task<bool> IsUniqueProductCode(string productcode, CancellationToken cancellationToken)
        {
            return await productRepository.IsUniqueProductCodeAsync(productcode, 0);
        }
    }
}
