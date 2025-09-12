
using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.Models;
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
            try
            {
                if (!IsValidEmail(registerDto.Email))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Email không hợp lệ", null, 400));

                if (!string.IsNullOrEmpty(registerDto.PhoneNumber) && !IsValidPhoneNumber(registerDto.PhoneNumber))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Số điện thoại không hợp lệ", null, 400));

                var exists = await _context.Users.AnyAsync(u =>
                    u.Username == registerDto.Username ||
                    u.Email == registerDto.Email ||
                    (!string.IsNullOrEmpty(registerDto.PhoneNumber) && u.PhoneNumber == registerDto.PhoneNumber)
                );

                if (exists)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Tên đăng nhập, email hoặc số điện thoại đã tồn tại", null, 400));

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

                var responseData = new
                {
                    user.Id,
                    user.Username,
                    user.Email,
                    user.FullName,
                    user.PhoneNumber,
                    Role = customerRole.Name
                };

                return Ok(ApiResponse<object>.SuccessResponse(responseData, "Đăng ký thành công", 200));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi khi đăng ký: {ex.Message}", null, 500));
            }
        }

        // =================== LOGIN ===================
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            try
            {
                if (!IsValidEmail(loginDto.Email))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Email không hợp lệ", null, 400));

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Sai thông tin đăng nhập", null, 401));

                if (user.IsDeleted) return Unauthorized(ApiResponse<string>.ErrorResponse("Tài khoản không tồn tại", null, 401));
                if (!user.IsActive) return Unauthorized(ApiResponse<string>.ErrorResponse("Tài khoản đã bị khóa hoặc chưa được kích hoạt", null, 401));

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

                var token = GenerateJwtToken(user, roles, permissions);

                var refreshToken = new RefreshToken
                {
                    Token = Guid.NewGuid().ToString("N"),
                    ExpiresAt = DateTime.Now.AddDays(7),
                    UserId = user.Id,
                    IsRevoked = false
                };

                await _context.RefreshTokens.AddAsync(refreshToken);
                await _context.SaveChangesAsync();

                var responseData = new
                {
                    username = user.Username,
                    email = user.Email,
                    roles,
                    permissions,
                    token,
                    refreshToken = refreshToken.Token
                };

                return Ok(ApiResponse<object>.SuccessResponse(responseData, "Đăng nhập thành công", 200));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi khi đăng nhập: {ex.Message}", null, 500));
            }
        }

        // =================== REFRESH TOKEN ===================
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            try
            {
                var storedToken = await _context.RefreshTokens
                    .Include(rt => rt.User)
                    .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

                if (storedToken == null || storedToken.IsRevoked || storedToken.ExpiresAt < DateTime.UtcNow)
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Refresh token không hợp lệ hoặc đã hết hạn", null, 401));

                var user = storedToken.User;
                if (user == null) return Unauthorized(ApiResponse<string>.ErrorResponse("Người dùng không tồn tại", null, 401));

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

                var responseData = new
                {
                    accessToken = newAccessToken,
                    refreshToken = newRefreshToken.Token
                };

                return Ok(ApiResponse<object>.SuccessResponse(responseData, "Làm mới token thành công", 200));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi khi làm mới token: {ex.Message}", null, 500));
            }
        }

        // =================== LOGOUT ===================
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string refreshToken)
        {
            try
            {
                var storedToken = await _context.RefreshTokens
                    .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

                if (storedToken == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy refresh token", null, 404));

                storedToken.IsRevoked = true;
                await _context.SaveChangesAsync();

                return Ok(ApiResponse<string>.SuccessResponse("Đăng xuất thành công", "Đăng xuất thành công", 200));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi khi đăng xuất: {ex.Message}", null, 500));
            }
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
