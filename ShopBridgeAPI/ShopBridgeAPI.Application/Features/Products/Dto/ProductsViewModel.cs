using ShopBridgeAPI.Domain.Common;
using System.Collections.Generic;

namespace ShopBridgeAPI.Application.Features.Products.Dto
{
    public class ProductsViewModel : AuditableViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> ImageNames { get; set; }

    }
}
