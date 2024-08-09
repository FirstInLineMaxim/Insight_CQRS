using CQRS.Domains.Products.Commands;

namespace CQRS.Domains.Products.Commands
{
    public record RegisterPrudctRequest(string? Name, string? Description);
    public record RegisterProduct(Guid productId, string name, string? description);

}

