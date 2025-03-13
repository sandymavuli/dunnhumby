using Dunnhumby.Products.Application.DTOs;
using Dunnhumby.Products.Application.Services;
using Dunnhumby.Products.Domains.Entities;
using Dunnhumby.Products.Domains.Enum;
using Dunnhumby.Products.Domains.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Dunnhumby.Products.Test
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductService _productService;

        private ProductsByPeriod GetProductsByPeriodTestData()
        {
            return new ProductsByPeriod(){ ProductsPerMonth = 9, ProductsPerWeek = 6, ProductsPerYear = 11};
        }

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task RegisterProductAsync_ShouldReturnProductId_WhenProductIsValid()
        {
            // Arrange
            var productDto = new RegisterProductDto
            {
                Name = "Dunnhumby Product",
                Price = 150,
                Quantity = 25,
                Category = 1,
                DateAdded = DateTime.Now,
                ProductCode = "PS 101",
                SKU = "SKU 101"
            };

            _productRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                                  .Returns(Task.CompletedTask);

            _productRepositoryMock.Setup(repo => repo.SaveChangesAsync())
                                  .Returns(Task.CompletedTask);

            // Act
            var result = await _productService.RegisterProductAsync(productDto);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            _productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
            _productRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetProductsByPeriodAsync_ShouldReturnGroupedResults()
        {
            // Arrange
            _productRepositoryMock.Setup(repo => repo.GetProductsByPeriodsAsync())
                                 .ReturnsAsync(GetProductsByPeriodTestData);

            //act
            var result = await _productService.GetProductsByPeriodAsync();

            //assert
            Assert.True(result.Count() == 3);

        }

        //TODO - similar way to create tests for other methods and other layers like controller and repo

    }
}