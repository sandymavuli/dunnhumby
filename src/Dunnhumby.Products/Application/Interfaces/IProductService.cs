using Dunnhumby.Products.Application.DTOs;

namespace Dunnhumby.Products.Application.Interfaces
{
    public interface IProductService
    {
        Task<Guid> RegisterProductAsync(RegisterProductDto dto);

        Task<List<ProductsbyCategoryDto>> GetProductsByCategory();

        Task<List<ProductsDto>> GetProductsAsync();

        Task<List<ProductsByPeriod>> GetProductsByPeriodAsync();
    }
}
