using ShopBridgeAPI.Domain.Common;

namespace ShopBridgeAPI.Domain.Entities
{
    public class ProductImage : AuditableBaseEntity
    {
        public int ProductId { get; set; }
        public Product product { get; set; }
        public string ImageName { get; set; }
    }
}
