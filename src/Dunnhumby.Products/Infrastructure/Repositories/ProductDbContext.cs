using Dunnhumby.Products.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Dunnhumby.Products.Infrastructure.Repositories
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
