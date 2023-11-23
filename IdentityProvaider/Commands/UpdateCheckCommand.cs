namespace IdentityProvaider.API.Commands
{
    public record UpdateCheckCommand(int id, int? id_room, int? id_reservation, int? num_hosts, string? titular_person_id, string? titular_person_name, DateTime? checkout_date, int? productsTotal);  
}
