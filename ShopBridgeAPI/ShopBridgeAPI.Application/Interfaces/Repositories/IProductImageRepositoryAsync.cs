using ShopBridgeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Application.Interfaces.Repositories
{
    public interface IProductImageRepositoryAsync : IGenericRepositoryAsync<ProductImage>
    {
        Task<IReadOnlyList<ProductImage>> GetProductImagesAsync(int productId);
    }
}
