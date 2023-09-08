namespace IdentityProvaider.API.Commands
{
    public record CreateUserCommand(string email,string name, string lastName, string typeDocument, string document_number, string direction, string password, int[] roles, string? state);
}
