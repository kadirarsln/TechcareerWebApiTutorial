namespace TechcareerWebApiTutorial.Models.ORM
{
    public class Author:BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
    }
}
