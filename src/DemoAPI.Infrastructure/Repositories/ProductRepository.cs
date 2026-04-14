using DemoAPI.Core.Entities;
using DemoAPI.Core.Helpers;
using DemoAPI.Core.Interfaces;
using DemoAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(PaginationParams param)
        {
            try
            {
                var query = _context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(param.Search))
                    query = query.Where(x => x.Name.Contains(param.Search));

                return await query
                    .Skip((param.PageNumber - 1) * param.PageSize)
                    .Take(param.PageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }          
        }

        public async Task AddAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}