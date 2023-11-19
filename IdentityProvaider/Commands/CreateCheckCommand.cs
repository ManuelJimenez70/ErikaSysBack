namespace IdentityProvaider.API.Commands
{
    public record CreateCheckCommand(int id_room, int? id_reservation, int num_hosts, string titular_person_id, string titular_person_name);
}
