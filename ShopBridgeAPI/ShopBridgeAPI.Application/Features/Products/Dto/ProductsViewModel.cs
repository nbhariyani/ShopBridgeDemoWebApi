using ShopBridgeAPI.Domain.Common;

namespace ShopBridgeAPI.Application.Features.Products.Dto
{
    public class ProductsViewModel : AuditableViewModel
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
