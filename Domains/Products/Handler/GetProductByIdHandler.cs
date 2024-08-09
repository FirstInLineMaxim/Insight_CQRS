using CQRS.Core.Queries;
using CQRS.Database;
using CQRS.Domains.Products.Models;
using CQRS.Domains.Products.Queries;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Domains.Products.Handler
{
    public class GetProductByIdHandler : IQueryHandler<GetProductById, Product?>
    {
        private MyDbContext _dbContext;

        public GetProductByIdHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product?> Handle(GetProductById query, CancellationToken ct)
        {
         var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == query.productId);

            if(product == null)
            {
                return null;
            }
            return product;
        }
    }
}
