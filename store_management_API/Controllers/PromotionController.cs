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
    }
}
