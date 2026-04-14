using DemoAPI.Core.DTOs;
using DemoAPI.Core.Entities;
using DemoAPI.Core.Helpers;
using DemoAPI.Core.Interfaces;

namespace DemoAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<object>> GetAllAsync(PaginationParams param)
        {
            var products = await _repo.GetAllAsync(param);

            return products.Select(p => new
            {
                p.Id,
                p.Name,
                p.Price
            });
        }

        public async Task CreateAsync(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };

            await _repo.AddAsync(product);
        }
    }
}