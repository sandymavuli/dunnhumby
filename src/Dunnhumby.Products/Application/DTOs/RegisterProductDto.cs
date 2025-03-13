using Dunnhumby.Products.Domains.Enum;
using System.ComponentModel.DataAnnotations;

namespace Dunnhumby.Products.Application.DTOs
{
    public class RegisterProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public int Category { get; set; }

    }
}
