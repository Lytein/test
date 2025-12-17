using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_management_WebAPI.Data;
using System.Data;

namespace store_management_WebAPI.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Pay(CreatePaymentDto dto)
        {
            using var tx = await _context.Database.BeginTransactionAsync(
                IsolationLevel.Serializable);

            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.order_id == dto.order_id);

            if (order == null)
                return NotFound("Order not found");

            if (order.status == OrderStatus.paid)
                return BadRequest("Order already paid");

            foreach (var item in order.Items)
            {
                var inventory = await _context.Inventory
                    .FromSqlRaw(
                        "SELECT * FROM inventories WHERE product_id = {0} FOR UPDATE",
                        item.product_id)
                    .FirstOrDefaultAsync();

                if (inventory == null || inventory.quantity < item.quantity)
                    return BadRequest("Not enough stock");

                inventory.quantity -= item.quantity;
                inventory.updated_at = DateTime.Now;
            }

            var payment = new Payment
            {
                order_id = order.order_id,
                amount = order.total_amount ?? 0,
                payment_method = dto.payment_method,
                payment_date = DateTime.Now
            };

            _context.Payments.Add(payment);
            order.status = OrderStatus.paid;

            await _context.SaveChangesAsync();
            await tx.CommitAsync();

            return Ok(payment);
        }
    }
}
