using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_management_WebAPI.Data;

namespace store_management_WebAPI.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }

        // =====================
        // GET ALL INVENTORY
        // =====================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventories = await _context.Inventory
                .Include(i => i.Product)
                .ToListAsync();

            return Ok(inventories);
        }

        // =====================
        // GET BY PRODUCT ID
        // =====================
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(i => i.product_id == productId);

            if (inventory == null)
                return NotFound();

            return Ok(inventory);
        }

        // =====================
        // UPDATE STOCK (ADMIN)
        // =====================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(int id, int quantity)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
                return NotFound();

            inventory.quantity = quantity;
            inventory.updated_at = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok(inventory);
        }
    }

}
