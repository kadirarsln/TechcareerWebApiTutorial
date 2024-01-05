namespace TechcareerWebApiTutorial.Models.ORM
{
    public class Reservation : BaseModelReservation
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
