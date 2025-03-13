using Dunnhumby.Products.Application.DTOs;
using Dunnhumby.Products.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Dunnhumby.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterProduct([FromBody] RegisterProductDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid product data.");

            var productId = await _productService.RegisterProductAsync(dto);
            return CreatedAtAction(nameof(RegisterProduct), new { id = productId }, new { id = productId });
        }

        [HttpGet("period")]
        public async Task<IActionResult> ProductsByPeriod()
        {
            var productsbyPeriod = await _productService.GetProductsByPeriodAsync(); //await _productService.GetProductsByPeriodV1();
            return Ok(productsbyPeriod);
        }

        [HttpGet("category")]
        public async Task<IActionResult> ProductsByCategory()
        {
            var productsbyCategories = await _productService.GetProductsByCategory();
            return Ok(productsbyCategories);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> ProductDetails()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

    }
}
