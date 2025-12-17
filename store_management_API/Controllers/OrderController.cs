using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_management_WebAPI.Data;
using store_management_WebAPI.DTOs;

namespace store_management_WebAPI.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // CREATE ORDER (POS / ONLINE)
        // =========================
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            if (dto.items == null || !dto.items.Any())
                return BadRequest("Order must have items");

            using var tx = await _context.Database.BeginTransactionAsync();

            var order = new Order
            {
                customer_id = dto.order_type == OrderType.online ? dto.customer_id : null,
                user_id = dto.order_type == OrderType.pos ? dto.user_id : null,
                promo_id = dto.promo_id,
                order_type = dto.order_type,
                order_date = DateTime.Now,
                status = OrderStatus.pending
            };

            decimal total = 0;

            foreach (var i in dto.items)
            {
                order.Items.Add(new Order_item
                {
                    product_id = i.product_id,
                    quantity = i.quantity,
                    price = i.price
                });

                total += i.quantity * i.price;
            }

            order.total_amount = total;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            await tx.CommitAsync();

            return Ok(order);
        }

        // =========================
        // GET ALL ORDERS (SAFE JSON)
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Items)
                .Include(o => o.Payment)
                .OrderByDescending(o => o.order_date)
                .Select(o => new
                {
                    o.order_id,
                    o.order_date,
                    o.total_amount,
                    status = o.status.ToString(),
                    items = o.Items.Select(i => new
                    {
                        i.product_id,
                        i.quantity,
                        i.price
                    }),
                    payment = o.Payment == null ? null : new
                    {
                        o.Payment.payment_method,
                        o.Payment.amount,
                        o.Payment.payment_date
                    }
                })
                .ToListAsync();

            return Ok(orders);
        }

        // =========================
        // CANCEL ORDER (ROLLBACK STOCK)
        // =========================
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            using var tx = await _context.Database.BeginTransactionAsync();

            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.order_id == id);

            if (order == null)
                return NotFound();

            if (order.status == OrderStatus.canceled)
                return BadRequest("Already canceled");

            if (order.status == OrderStatus.paid)
            {
                foreach (var item in order.Items)
                {
                    var inventory = await _context.Inventory
                        .FirstOrDefaultAsync(i => i.product_id == item.product_id);

                    if (inventory != null)
                    {
                        inventory.quantity += item.quantity;
                        inventory.updated_at = DateTime.Now;
                    }
                }
            }

            order.status = OrderStatus.canceled;
            await _context.SaveChangesAsync();
            await tx.CommitAsync();

            return Ok(order);
        }
    }
}
