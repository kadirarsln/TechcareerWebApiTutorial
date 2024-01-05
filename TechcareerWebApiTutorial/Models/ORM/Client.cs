﻿namespace TechcareerWebApiTutorial.Models.ORM
{
    public class Client : BaseModelReservation
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
