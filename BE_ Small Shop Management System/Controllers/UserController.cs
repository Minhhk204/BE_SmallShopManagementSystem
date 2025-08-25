using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using BE__Small_Shop_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BE__Small_Shop_Management_System.DTOs;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Chỉ Admin mới lấy được danh sách user
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return Ok(users);
        }

        // Chỉ Admin mới tạo user
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return Ok(user);
        }

        // Lấy thông tin cá nhân (user tự xem)
        [HttpGet("Customer")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var user = await _unitOfWork.Users.GetByIdAsync(int.Parse(userId));
            if (user == null) return NotFound();
            return Ok(user);
        }

        // Lấy user theo username (Admin hoặc Seller)
        [HttpGet("{username}")]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(username);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPut("{id}/deactivate")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.IsActive = false;
            await _unitOfWork.CompleteAsync();
            return Ok(new { message = "Tài khoản đã bị khóa", user });
        }

        [HttpPut("{id}/activate")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Activate(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.IsActive = true;
            await _unitOfWork.CompleteAsync();
            return Ok(new { message = "Tài khoản đã được mở khóa", user });
        }
        
        [HttpPost("assign-role")] 
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(dto.UserId);
            if (user == null) return NotFound("User not found");

            var role = await _unitOfWork.Roles.GetByIdAsync(dto.RoleId);
            if (role == null) return NotFound("Role not found");

            // Check nếu user đã có role này
            var hasRole = await _unitOfWork.UserRoles.GetByUserAndRoleAsync(dto.UserId, dto.RoleId);
            if (hasRole != null)
                return BadRequest("User đã có role này rồi");

            // Gán role
            var userRole = new UserRole
            {
                UserId = dto.UserId,
                RoleId = dto.RoleId
            };

            await _unitOfWork.UserRoles.AddAsync(userRole);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = $"Đã gán role '{role.Name}' cho user '{user.Username}'" });
        }
    }
}
