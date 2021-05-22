using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBridgeAPI.Domain.Entities;

namespace ShopBridgeAPI.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.ProductCode)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(200);
        }
    }
}
