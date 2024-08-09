using CQRS.Core.Commands;
using CQRS.Core.Queries;
using CQRS.Database;
using CQRS.Domains.Products.Commands;
using CQRS.Domains.Products.Handler;
using CQRS.Domains.Products.Models;
using CQRS.Domains.Products.Queries;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Domains.Products
{
    internal static class Configuration
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services)
        {
            return services.AddTransient(sp => sp.GetRequiredService<MyDbContext>().Set<Product>().AsNoTracking())
                .AddCommandHandler<RegisterProduct,RegisterProductHandler>()
                .AddQueryHandler<GetAllProducts,List<Product>,GetAllProductsHandler>()
                .AddQueryHandler<GetProductById,Product?,GetProductByIdHandler>();
        }
        public static void SetupProductModel(this ModelBuilder modelBuilder) => modelBuilder.Entity<Product>();
    }
}
