namespace TechcareerWebApiTutorial.Models
{
    public class Product
    {
        // Ürün ID'si
        public int ProductID { get; set; }

        // Ürün Adı
        public string? ProductName { get; set; }

        // Ürün Fiyatı
        public decimal UnitPrice { get; set; }
        public Category? Category { get; set; }
    }
}
