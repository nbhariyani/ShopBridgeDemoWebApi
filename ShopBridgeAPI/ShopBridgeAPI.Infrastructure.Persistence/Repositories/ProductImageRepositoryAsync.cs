using Microsoft.EntityFrameworkCore;
using ShopBridgeAPI.Application.Interfaces.Repositories;
using ShopBridgeAPI.Domain.Entities;
using ShopBridgeAPI.Infrastructure.Persistence.Contexts;
using ShopBridgeAPI.Infrastructure.Persistence.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Infrastructure.Persistence.Repositories
{
    public class ProductImageRepositoryAsync : GenericRepositoryAsync<ProductImage>, IProductImageRepositoryAsync
    {
        private readonly DbSet<ProductImage> _productImages;

        public ProductImageRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _productImages = dbContext.Set<ProductImage>();
        }

        public async Task<IReadOnlyList<ProductImage>> GetProductImagesAsync(int productId)
        {
            return await _productImages.Where(x => x.ProductId == productId).ToListAsync();
        }


        public override async Task<IReadOnlyList<ProductImage>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _productImages.Include(x => x.product)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
