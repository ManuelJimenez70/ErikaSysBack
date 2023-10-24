namespace IdentityProvaider.API.Commands
{
    public record CreateProductCommand(string title, string description, string image, int price, int stock, string? id_module);
}
