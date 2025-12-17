using Microsoft.AspNetCore.Mvc;
using store_management_WebAPI.Data;

namespace store_management_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : Controller
    {
        private readonly AppDbContext _context;
        public PromotionController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPromotions()
        {
            var promotions = _context.Promotions.ToList();
            return Ok(promotions);
        }
        // POST: api/promotion
        [HttpPost]
        public async Task<IActionResult> AddPromotion([FromBody] Promotion promotion)
        {
            if (promotion == null)
                return BadRequest();

            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPromotions), new { id = promotion.promo_id }, promotion);
        }
    }
}
