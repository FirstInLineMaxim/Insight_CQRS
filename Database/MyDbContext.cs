using CQRS.Domains.Products;
using CQRS.Domains.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetupProductModel();
        }
        public DbSet<Product> Products { get; set; }
    }
}
