namespace IdentityProvaider.API.Commands
{
    public record CreateRoomCommand(string number, int max_capacity, int price_per_nigth);
}
