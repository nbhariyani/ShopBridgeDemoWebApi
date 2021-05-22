using ShopBridgeAPI.Domain.Common;

namespace ShopBridgeAPI.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
