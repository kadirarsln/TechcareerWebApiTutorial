namespace TechcareerWebApiTutorial.Models.Auth
{
    public class TokenModel
    {
        public string? accesToken { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
