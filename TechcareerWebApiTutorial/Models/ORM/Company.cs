namespace TechcareerWebApiTutorial.Models.ORM
{
    public class Company : BaseModelReservation
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
