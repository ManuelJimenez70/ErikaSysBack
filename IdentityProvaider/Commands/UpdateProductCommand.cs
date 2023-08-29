using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.API.Commands
{
    public record UpdateProductCommand(int id, string? title,int? price, string? description, string? image, int? stock, string? state);
    
    
}
