using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Interfaces;
using Tmdt.Infrastructure.Persistence.Data;
using Tmdt.Infrastructure.Persistence.Services.Base;

namespace Tmdt.Infrastructure.Persistence.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(ApplicationContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Product>> GetProductsByFilter(string search, int pageNumber, int pageSize)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{search}%"));
            }

            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var products = await query.ToListAsync();
            return products;
        }

        public async Task<int> GetTotalProductsByFilter(string search)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{search}%"));
            }

            var totalProduct = await query.CountAsync();
            return totalProduct;
        }

        public new async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public new async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
