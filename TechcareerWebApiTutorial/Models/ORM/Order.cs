namespace TechcareerWebApiTutorial.Models.ORM
{
    public class Order:BaseModel
    {
        public string? OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public List<WebUser> WebUsers { get; set; }

    }
}
