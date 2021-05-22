using ShopBridgeAPI.Domain.Entities;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<bool> IsUniqueProductCodeAsync(string productcode, int id);
    }
}
