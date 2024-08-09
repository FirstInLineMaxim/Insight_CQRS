namespace CQRS.Domains.Products.Models
{
public class Product(Guid id, string name, string? description)
{

    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
}
}
