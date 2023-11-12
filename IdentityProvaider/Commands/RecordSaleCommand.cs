namespace IdentityProvaider.API.Commands
{
    public record RecordSaleCommand(int id_user, int id_action, int id_product, int id_module, int quantity, string? state, DateTime? date);
}
