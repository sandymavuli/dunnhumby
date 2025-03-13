namespace Dunnhumby.Products.Application.DTOs
{
    public class ProductsbyPeriodV1Dto
    {
        public int Year { get; set; }
        public int Period { get; set; } // Week number or Month number
        public string PeriodType { get; set; } // "Weekly" or "Monthly"
        public int TotalProducts { get; set; }
    }
}
