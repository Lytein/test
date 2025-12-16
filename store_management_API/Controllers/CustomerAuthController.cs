using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using store_management_WebAPI.Data;
using store_management_WebAPI.DTOs;
using store_management_WebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace store_management_WebAPI.Controllers
{
    [Route("api/customer-auth")]
    [ApiController]
    public class CustomerAuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<CustomerAccount> _hasher;

        public CustomerAuthController(AppDbContext context)
        {
            _context = context;
            _hasher = new PasswordHasher<CustomerAccount>();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAccounts()
        {
            var accounts = await _context.CustomerAccounts
                .Include(a => a.Customer)
                .ToListAsync();

            var result = accounts.Select(a => new CustomerAccountResponse
            {
                Id = a.id,
                Username = a.username,
                CreatedAt = a.created_at,
                Customer = a.Customer == null ? null : new CustomerResponse
                {
                    Id = a.Customer.customer_id,
                    Name = a.Customer.name,
                    Email = a.Customer.email,
                    Phone = a.Customer.phone,
                    Address = a.Customer.address,
                    CreatedAt = a.Customer.created_at
                }
            });

            return Ok(result);
        }

        // REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool usernameExists = await _context.CustomerAccounts
                .AnyAsync(x => x.username == dto.username);

            if (usernameExists)
                return BadRequest(new { message = "Username đã tồn tại" });

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Tạo customer
                var customer = new Customer
                {
                    name = dto.full_name,
                    email = dto.email,
                    phone = dto.phone,
                    address = dto.address,
                    created_at = DateTime.Now
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                // Tạo account và hash password
                var account = new CustomerAccount
                {
                    customer_id = customer.customer_id,
                    username = dto.username,
                    password = _hasher.HashPassword(null, dto.password),
                    created_at = DateTime.Now
                };

                _context.CustomerAccounts.Add(account);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(new
                {
                    message = "Đăng ký thành công",
                    customer_id = customer.customer_id
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new
                {
                    message = "Lỗi khi đăng ký",
                    error = ex.Message
                });
            }
        }

        // LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var acc = await _context.CustomerAccounts
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.username == dto.username);

            if (acc == null)
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu" });

            var result = _hasher.VerifyHashedPassword(acc, acc.password, dto.password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu" });

            // Tạo JWT
            var claims = new[]
            {
                new Claim("customer_id", acc.customer_id.ToString()),
                new Claim("username", acc.username),
                new Claim(ClaimTypes.Role, "customer")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("store_management_super_secret_hehe"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourapp",
                audience: "yourapp",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                customer = acc.Customer
            });
        }
    }
}
