using ShopBridgeAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<bool> IsUniqueProductNameAsync(string productname, int id);
    }
}
