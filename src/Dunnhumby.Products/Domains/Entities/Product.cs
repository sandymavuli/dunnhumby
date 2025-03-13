using Dunnhumby.Products.Domains.Enum;

namespace Dunnhumby.Products.Domains.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ProductCode { get; private set; }
        public decimal Price { get; private set; }
        public string SKU { get; private set; }
        public int StockQuantity { get; private set; }
        public DateTime DateAdded { get; private set; }

        // New column Category with default value
        public int Category { get; set; } = (int)ProductCategory.Electronics;

        private Product() { }

        public Product(string name,
                       string productCode,
                       decimal price,
                       string sku,
                       int stockQuantity,
                       DateTime dateAdded,
                       ProductCategory productCategory)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
            SKU = sku;
            ProductCode = productCode;
            DateAdded = dateAdded;
            Category = (int)productCategory;
        }
    }
}
