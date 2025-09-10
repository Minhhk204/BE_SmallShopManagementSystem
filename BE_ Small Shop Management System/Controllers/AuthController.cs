using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        private bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;

            // Regex: bắt đầu bằng 0, theo sau là 9 số (tổng cộng 10 số)
            var regex = new Regex(@"^0\d{9}$");
            return regex.IsMatch(phone);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            if (!IsValidEmail(registerDto.Email))
                return BadRequest("Email không hợp lệ");

            if (!string.IsNullOrEmpty(registerDto.PhoneNumber) && !IsValidPhoneNumber(registerDto.PhoneNumber))
                return BadRequest("Số điện thoại không hợp lệ (phải có 10 chữ số, bắt đầu bằng 0)");

            // Check trùng username/email/phone
            var exists = await _context.Users.AnyAsync(u =>
                u.Username == registerDto.Username ||
                u.Email == registerDto.Email ||
                (!string.IsNullOrEmpty(registerDto.PhoneNumber) && u.PhoneNumber == registerDto.PhoneNumber)
            );
            if (exists)
                return BadRequest("Tên đăng nhập, email hoặc số điện thoại đã tồn tại");

            // Hash mật khẩu
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                FullName = registerDto.FullName ?? string.Empty,
                PhoneNumber = registerDto.PhoneNumber ?? string.Empty,
                PasswordHash = passwordHash,
                IsActive = true
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // Gán role mặc định = Customer
            var customerRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Customer");
            if (customerRole == null)
            {
                customerRole = new Role { Name = "Customer" };
                await _context.Roles.AddAsync(customerRole);
                await _context.SaveChangesAsync();
            }

            await _context.UserRoles.AddAsync(new UserRole
            {
                UserId = user.Id,
                RoleId = customerRole.Id
            });
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Đăng ký thành công",
                user = new
                {
                    user.Id,
                    user.Username,
                    user.Email,
                    user.FullName,
                    user.PhoneNumber,
                    Role = customerRole.Name
                }
            });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {
            if (!IsValidEmail(loginDto.Email))
                return BadRequest("Email không hợp lệ");

            var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email);
            if (user == null) return Unauthorized("Sai thông tin đăng nhập");

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return Unauthorized("Sai thông tin đăng nhập");

            if (user.IsDeleted)
                return Unauthorized("Tài khoản không tồn tại");

            if (!user.IsActive)
                return Unauthorized("Tài khoản đã bị khóa hoặc chưa được kích hoạt");

            // Roles
            var roles = _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.Role.Name)
                .ToList();

            // Permissions (Role + User)
            var rolePermissions = _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .SelectMany(ur => ur.Role.RolePermissions.Select(rp => rp.Permission.Name));

            var directPermissions = _context.UserPermissions
                .Where(up => up.UserId == user.Id)
                .Select(up => up.Permission.Name);

            var permissions = rolePermissions
                .Union(directPermissions)
                .Distinct()
                .ToList();

            // Sinh JWT
            var token = GenerateJwtToken(user, roles, permissions);

            return Ok(new
            {
                message = "Đăng nhập thành công",
                username = user.Username,
                email = user.Email,
                roles,
                permissions,
                token
            });
        }



        private string GenerateJwtToken(User user, List<string> roles, List<string> permissions)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var claims = new List<Claim>
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Email, user.Email)
        };

            // roles
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            // permissions
            foreach (var permission in permissions)
                claims.Add(new Claim("permission", permission));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
