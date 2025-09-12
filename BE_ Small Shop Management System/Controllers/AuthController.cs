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

        // =================== REGISTER ===================
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            if (!IsValidEmail(registerDto.Email))
                return BadRequest("Email không hợp lệ");

            if (!string.IsNullOrEmpty(registerDto.PhoneNumber) && !IsValidPhoneNumber(registerDto.PhoneNumber))
                return BadRequest("Số điện thoại không hợp lệ (phải có 10 chữ số, bắt đầu bằng 0)");

            var exists = await _context.Users.AnyAsync(u =>
                u.Username == registerDto.Username ||
                u.Email == registerDto.Email ||
                (!string.IsNullOrEmpty(registerDto.PhoneNumber) && u.PhoneNumber == registerDto.PhoneNumber)
            );
            if (exists) return BadRequest("Tên đăng nhập, email hoặc số điện thoại đã tồn tại");

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

        // =================== LOGIN ===================
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (!IsValidEmail(loginDto.Email))
                return BadRequest("Email không hợp lệ");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return Unauthorized("Sai thông tin đăng nhập");

            if (user.IsDeleted) return Unauthorized("Tài khoản không tồn tại");
            if (!user.IsActive) return Unauthorized("Tài khoản đã bị khóa hoặc chưa được kích hoạt");

            var roles = await _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.Role.Name)
                .ToListAsync();

            var rolePermissions = _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .SelectMany(ur => ur.Role.RolePermissions.Select(rp => rp.Permission.Name));

            var directPermissions = _context.UserPermissions
                .Where(up => up.UserId == user.Id)
                .Select(up => up.Permission.Name);

            var permissions = rolePermissions.Union(directPermissions).Distinct().ToList();

            // Access token
            var token = GenerateJwtToken(user, roles, permissions);

            // Refresh token
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString("N"),
                ExpiresAt = DateTime.Now.AddDays(7),
                UserId = user.Id,
                IsRevoked = false
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Đăng nhập thành công",
                username = user.Username,
                email = user.Email,
                roles,
                permissions,
                token,
                refreshToken = refreshToken.Token
            });
        }

        // =================== REFRESH TOKEN ===================
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            var storedToken = await _context.RefreshTokens
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

            if (storedToken == null || storedToken.IsRevoked || storedToken.ExpiresAt < DateTime.UtcNow)
                return Unauthorized("Refresh token không hợp lệ hoặc đã hết hạn");

            var user = storedToken.User;
            if (user == null) return Unauthorized("Người dùng không tồn tại");

            var roles = await _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.Role.Name)
                .ToListAsync();

            var rolePermissions = _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .SelectMany(ur => ur.Role.RolePermissions.Select(rp => rp.Permission.Name));

            var directPermissions = _context.UserPermissions
                .Where(up => up.UserId == user.Id)
                .Select(up => up.Permission.Name);

            var permissions = rolePermissions.Union(directPermissions).Distinct().ToList();

            var newAccessToken = GenerateJwtToken(user, roles, permissions);

            var newRefreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString("N"),
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                UserId = user.Id,
                IsRevoked = false
            };

            storedToken.IsRevoked = true;
            await _context.RefreshTokens.AddAsync(newRefreshToken);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken.Token
            });
        }

        // =================== LOGOUT ===================
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string refreshToken)
        {
            var storedToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

            if (storedToken == null) return NotFound("Không tìm thấy refresh token");

            storedToken.IsRevoked = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đăng xuất thành công" });
        }

        // =================== HELPERS ===================
        private string GenerateJwtToken(User user, List<string> roles, List<string> permissions)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
            };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
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

        private bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            var regex = new Regex(@"^0\d{9}$");
            return regex.IsMatch(phone);
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
