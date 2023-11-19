namespace IdentityProvaider.API.Commands
{
    public record UpdateReservationCommand(int id, int? id_room, DateTime? reservation_date, string? titular_person_name, string? state, string? titular_person_id);

}
