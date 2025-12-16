using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_management_WebAPI.Data;
using store_management_WebAPI.Models;

namespace store_management_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/customer
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers
                .Include(c => c.Account) // Include account
                .ToListAsync();
            return Ok(customers);
        }

        // GET: api/customer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Account) // Include account
                .FirstOrDefaultAsync(c => c.customer_id == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST: api/customer
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            customer.created_at = DateTime.Now;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.customer_id }, customer);
        }

        // PUT: api/customer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.customer_id)
                return BadRequest();

            var existing = await _context.Customers.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.name = customer.name;
            existing.email = customer.email;
            existing.phone = customer.phone;
            existing.address = customer.address;

            _context.Customers.Update(existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/customer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var existing = await _context.Customers.FindAsync(id);
            if (existing == null)
                return NotFound();

            _context.Customers.Remove(existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
