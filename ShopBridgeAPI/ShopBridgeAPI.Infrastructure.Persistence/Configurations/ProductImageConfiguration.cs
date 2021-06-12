using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBridgeAPI.Domain.Entities;

namespace ShopBridgeAPI.Infrastructure.Persistence.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.Property(t => t.ImageName)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
