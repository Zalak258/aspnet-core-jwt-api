using DemoAPI.Core.Entities;
using DemoAPI.Core.Helpers;

namespace DemoAPI.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(PaginationParams param);
        Task AddAsync(Product product);
    }
}