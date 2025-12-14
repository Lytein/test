using Microsoft.AspNetCore.Mvc;
using store_management_WebAPI.Data;
using store_management_WebAPI;
using System.Linq;

namespace store_management_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.product_id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProductById), new { id = product.product_id }, product);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.product_id) return BadRequest();

            var existing = _context.Products.FirstOrDefault(p => p.product_id == id);
            if (existing == null) return NotFound();

            // Cập nhật các trường
            existing.product_name = product.product_name;
            existing.category_id = product.category_id;
            existing.supplier_id = product.supplier_id;
            existing.barcode = product.barcode;
            existing.price = product.price;
            existing.unit = product.unit;
            existing.created_at = product.created_at;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.product_id == id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
