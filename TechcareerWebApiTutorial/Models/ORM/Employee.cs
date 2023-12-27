namespace TechcareerWebApiTutorial.Models.ORM
{
    public class Employee:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
