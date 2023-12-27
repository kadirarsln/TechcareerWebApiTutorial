using System.ComponentModel.DataAnnotations;

namespace TechcareerWebApiTutorial.Models.ORM
{
    public class Blog:BaseModel
    {

        [MaxLength(100)]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
