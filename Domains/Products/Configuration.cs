using CQRS.Database;
using CQRS.Domains.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Domains.Products
{
    internal static class Configuration
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services)
        {
            return services.AddTransient(sp => sp.GetRequiredService<MyDbContext>().Set<Product>().AsNoTracking());
        }
        public static void SetupProductModel(this ModelBuilder modelBuilder) => modelBuilder.Entity<Product>();
    }
}
