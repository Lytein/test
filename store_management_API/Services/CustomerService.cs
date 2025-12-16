using store_management_WebAPI.Data;
using store_management_WebAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace store_management_WebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerResponse>> GetAllAsync()
        {
            return await _context.Customers
                .Select(c => new CustomerResponse
                {
                    Id = c.customer_id,
                    Name = c.name,
                    Email = c.email,
                    Phone = c.phone,
                    Address = c.address,
                    CreatedAt = c.created_at
                })
                .ToListAsync();
        }

        public async Task<CustomerResponse?> GetByIdAsync(int id)
        {
            var c = await _context.Customers.FindAsync(id);
            if (c == null) return null;

            return new CustomerResponse
            {
                Id = c.customer_id,
                Name = c.name,
                Email = c.email,
                Phone = c.phone,
                Address = c.address,
                CreatedAt = c.created_at
            };
        }

        public async Task<CustomerResponse> AddAsync(CustomerRequest request)
        {
            var customer = new Customer
            {
                name = request.Name,
                email = request.Email,
                phone = request.Phone,
                address = request.Address,
                created_at = DateTime.Now
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return new CustomerResponse
            {
                Id = customer.customer_id,
                Name = customer.name,
                Email = customer.email,
                Phone = customer.phone,
                Address = customer.address,
                CreatedAt = customer.created_at
            };
        }

        public async Task<bool> UpdateAsync(int id, CustomerRequest request)
        {
            var existing = await _context.Customers.FindAsync(id);
            if (existing == null) return false;

            existing.name = request.Name;
            existing.email = request.Email;
            existing.phone = request.Phone;
            existing.address = request.Address;

            _context.Customers.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Customers.FindAsync(id);
            if (existing == null) return false;

            _context.Customers.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
