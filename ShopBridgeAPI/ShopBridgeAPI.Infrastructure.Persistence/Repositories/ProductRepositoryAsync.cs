using Microsoft.EntityFrameworkCore;
using ShopBridgeAPI.Application.Interfaces.Repositories;
using ShopBridgeAPI.Domain.Entities;
using ShopBridgeAPI.Infrastructure.Persistence.Contexts;
using ShopBridgeAPI.Infrastructure.Persistence.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _products;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Product>();
        }

        public Task<bool> IsUniqueProductCodeAsync(string productcode, int id)
        {
            return _products.Where(x => x.Id != id).AllAsync(p => p.ProductCode != productcode);
        }
    }
}
