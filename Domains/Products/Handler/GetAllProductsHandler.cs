using CQRS.Core.Queries;
using CQRS.Database;
using CQRS.Domains.Products.Models;
using CQRS.Domains.Products.Queries;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Domains.Products.Handler
{
    public class GetAllProductsHandler : IQueryHandler<GetAllProducts, List<Product>>
    {

        private readonly MyDbContext _dbContext;

        public GetAllProductsHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> Handle(GetAllProducts query, CancellationToken ct)
        {
            var productList = await _dbContext.Products.ToListAsync(ct); 

            return productList;
        }
    }
}
