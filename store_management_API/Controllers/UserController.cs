using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using store_management_WebAPI.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace store_management_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.username == request.Username && u.password == request.Password);
            if(user == null)
            {
                return Unauthorized(new { message = "Tên đăng nhập hoặc mật khẩu không đúng" });    
            }
            // 1. Tạo claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.username),
                new Claim("user_id", user.user_id.ToString()),
                new Claim("username", user.username),
                new Claim("role", user.role.ToString()) // để phân quyền
            };

                
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("store_management_super_secret_hehe"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "yourapp",
                    audience: "yourapp",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
              );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                user_id = user.user_id,
                username = user.username,
                full_name = user.full_name,
                role = user.role,
                created_at = user.created_at
            });
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            // kiểm tra username đã tồn tại
            if (_context.Users.Any(u => u.username == user.username))
                return BadRequest(new { message = "Username đã tồn tại" });

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "Đăng ký thành công" });
        }

    }
}
