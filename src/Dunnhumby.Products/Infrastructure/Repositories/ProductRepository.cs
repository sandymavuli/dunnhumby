using Dunnhumby.Products.Application.DTOs;
using Dunnhumby.Products.Domains.Entities;
using Dunnhumby.Products.Domains.Enum;
using Dunnhumby.Products.Domains.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dunnhumby.Products.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductsQuery()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<ProductsbyCategoryDto>> GetProductsByCategory()
        {
            var products = await _context.Products.GroupBy(s => s.Category)
                .Select(g => new ProductsbyCategoryDto
                {
                    Category = ((ProductCategory)g.Key).ToString(),
                    TotalProducts = g.Count(),
                }).ToListAsync();

            return products;
        }

        public async Task<ProductsByPeriod> GetProductsByPeriodsAsync()
        {
            var currentDate = DateTime.UtcNow;

            var prods = await _context.Products
                        .Where(s => s.DateAdded.Year == currentDate.Year)
                        .GroupBy(s => 1)
                        .Select(g => new ProductsByPeriod()
                        {
                            ProductsPerWeek = g.Count(s => EF.Functions.DateDiffWeek(s.DateAdded, currentDate) == 0),
                            ProductsPerMonth = g.Count(s => EF.Functions.DateDiffMonth(s.DateAdded, currentDate) == 0),
                            ProductsPerYear = g.Count()
                        }).FirstOrDefaultAsync() ?? new ProductsByPeriod { ProductsPerWeek = 0, ProductsPerMonth = 0, ProductsPerYear = 0 };

            return prods;
        }
    }
}
