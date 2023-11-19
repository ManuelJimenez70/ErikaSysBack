namespace IdentityProvaider.API.Commands
{
    public record CreateReservationCommand(int id_room, DateTime reservation_date, string titular_person_name, string titular_person_id);
}
