using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechcareerWebApiTutorial.Models;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private List<Product> productList = new List<Product>
    {
        new Product { ProductID = 1, ProductName = "Laptop", UnitPrice = 35000,
            Category = new Category { CategoryID = 1, CategoryName = "Electronics" } },

        new Product { ProductID = 2, ProductName = "Phone", UnitPrice = 25000,
            Category = new Category { CategoryID = 1, CategoryName = "Electronics" } },

        new Product { ProductID = 3, ProductName = "T-Shirt", UnitPrice = 500,
            Category = new Category { CategoryID = 2, CategoryName = "Clothing" } },

        new Product { ProductID = 4, ProductName = "Jeans", UnitPrice = 1200,
            Category = new Category { CategoryID = 2, CategoryName = "Clothing" } }
    };



        // Tüm ürünleri getiren endpoint
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(productList);
        }

        // Yeni ürün oluşturan endpoint
        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            newProduct.ProductID = productList.Count + 1;
            productList.Add(newProduct);

            return StatusCode(StatusCodes.Status201Created, newProduct);
        }

        // Belirtilen ID'ye sahip ürünü silen endpoint
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // ID'ye sahip ürünü bul
            var productToDelete = productList.FirstOrDefault(p => p.ProductID == id);

            if (productToDelete == null)
            {
                return NotFound("Ürün bulunamadı");
            }

            productList.Remove(productToDelete);
            return NoContent();
        }

        // Belirtilen ID'ye sahip ürünü getiren endpoint
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // ID'ye sahip ürünü bul
            var product = productList.FirstOrDefault(p => p.ProductID == id);

            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            return Ok(product);
        }
    }
}
