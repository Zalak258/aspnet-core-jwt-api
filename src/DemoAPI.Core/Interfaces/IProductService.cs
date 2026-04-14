using DemoAPI.Core.DTOs;
using DemoAPI.Core.Helpers;

namespace DemoAPI.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<object>> GetAllAsync(PaginationParams param);
        Task CreateAsync(ProductDto dto);
    }
}