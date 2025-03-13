using System.ComponentModel.DataAnnotations;

namespace Dunnhumby.Products.Application.DTOs
{
    public class ProductsDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ProductCode { get; set; }

        public string SKU { get; set; }
        public DateTime DateAdded { get; set; }

        public string Category { get; set; }

    }
}
