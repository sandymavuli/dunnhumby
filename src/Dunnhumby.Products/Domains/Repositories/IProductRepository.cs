using Dunnhumby.Products.Application.DTOs;
using Dunnhumby.Products.Domains.Entities;

namespace Dunnhumby.Products.Domains.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task SaveChangesAsync();
        Task<List<Product>> GetAllProductsQuery();
        Task<List<ProductsbyCategoryDto>> GetProductsByCategory();
        Task<ProductsByPeriod> GetProductsByPeriodsAsync();
    }
}
