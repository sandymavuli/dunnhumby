using Dunnhumby.Products.Application.DTOs;
using Dunnhumby.Products.Application.Interfaces;
using Dunnhumby.Products.Domains.Entities;
using Dunnhumby.Products.Domains.Enum;
using Dunnhumby.Products.Domains.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace Dunnhumby.Products.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// registers new product
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>guid unique product id</returns>
        public async Task<Guid> RegisterProductAsync(RegisterProductDto dto)
        {
            var product = new Product(dto.Name, dto.ProductCode, dto.Price, dto.SKU, dto.Quantity, dto.DateAdded, (ProductCategory)dto.Category);
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
            return product.Id;
        }

        /// <summary>
        /// get number of products by category
        /// </summary>
        /// <returns>ProductsbyCategoryDto object</returns>
        public async Task<List<ProductsbyCategoryDto>> GetProductsByCategory()
        {
            var products = await _productRepository.GetProductsByCategory();

            return products;
        }

        /// <summary>
        /// get products
        /// </summary>
        /// <returns>ProductsDto list</returns>
        public async Task<List<ProductsDto>> GetProductsAsync()
        {
            var products = await _productRepository.GetAllProductsQuery();

            var prodDtos = products.Select(x => new ProductsDto()
            {
                DateAdded = x.DateAdded,
                Name = x.Name,
                Price = x.Price,
                ProductCode = x.ProductCode,
                Quantity = x.StockQuantity,
                SKU = x.SKU,
                Category = Enum.IsDefined(typeof(ProductCategory), x.Category) ? ((ProductCategory)x.Category).ToString() : ""            //((ProductCategory)x.Category).ToString(),

            }).ToList();

            return prodDtos;
        }

        /// <summary>
        /// get products by period - weekly, monthly, yearly
        /// </summary>
        /// <returns>ProductsDto list</returns>
        public async Task<List<ProductsByPeriod>> GetProductsByPeriodAsync()
        {
            var prods = await _productRepository.GetProductsByPeriodsAsync();

            var prodDtos = new List<ProductsByPeriod>()
            {
                new ProductsByPeriod {ProductsPerWeek = prods?.ProductsPerWeek ?? 0, PeriodType = "weekly"},
                new ProductsByPeriod {ProductsPerMonth = prods?.ProductsPerMonth ?? 0, PeriodType = "monthly"},
                new ProductsByPeriod {ProductsPerYear = prods?.ProductsPerYear ?? 0, PeriodType = "yearly"}
            };

            return prodDtos;
        }
    }
}
