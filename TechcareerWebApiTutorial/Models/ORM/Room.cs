namespace TechcareerWebApiTutorial.Models.ORM
{
    public class Room : BaseModelReservation
    {
        public string? Name { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
