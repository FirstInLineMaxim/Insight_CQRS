using CQRS.Core.Commands;
using CQRS.Database;
using CQRS.Domains.Products.Commands;
using CQRS.Domains.Products.Models;

namespace CQRS.Domains.Products.Handler
{
    public class RegisterProductHandler : ICommandHandler<RegisterProduct>
    {
        private readonly MyDbContext _dbContext;


        public RegisterProductHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(RegisterProduct command, CancellationToken cancellationToken = default)
        {

            await Task.Delay(10000);
            var product = new Product(command.productId,command.name,command.description);
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
