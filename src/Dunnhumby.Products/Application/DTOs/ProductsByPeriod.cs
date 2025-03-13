namespace Dunnhumby.Products.Application.DTOs
{
    public class ProductsByPeriod
    {
        public int ProductsPerWeek { get; set; }

        public int ProductsPerMonth { get; set; }

        public int ProductsPerYear { get; set; }

        public string PeriodType { get; set;}
    }
}
