namespace IdentityProvaider.API.Commands
{
    public record UpdateRoomCommand(int id, string? number, int? max_capacity, int? price_per_nigth, string? state);

}
