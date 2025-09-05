using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using BE__Small_Shop_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.Services;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserPermissionService _service;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(UserPermissionService service, IUnitOfWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }


        // Lấy map quyền của user (bao gồm cả quyền từ role)
        [HttpGet("{userId}/permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPermissionsOfUser(int userId)
        {
            var map = await _service.GetPermissionMapAsync(userId, includeRolePermissions: true);
            return Ok(new { userId, permissions = map });
        }

        // Gán quyền trực tiếp cho user (replace all) và trả về map
        [HttpPost("{userId}/assign-permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignPermissionsToUser(int userId, [FromBody] AssignPermissionsRequest request)
        {
            // lấy current permissions
            var currentPermissions = await _unitOfWork.UserPermissionRepository
                .GetPermissionsByUserIdAsync(userId);
            var currentIds = currentPermissions.Select(p => p.Id).ToHashSet();

            // lặp qua request
            foreach (var item in request.Permissions)
            {
                if (item.Granted && !currentIds.Contains(item.Id))
                {
                    // thêm mới
                    await _unitOfWork.UserPermissionRepository.AssignAsync(userId, new[] { item.Id });
                }
                else if (!item.Granted && currentIds.Contains(item.Id))
                {
                    // gỡ bỏ
                    await _unitOfWork.UserPermissionRepository.RemoveAsync(userId, new[] { item.Id });
                }
            }

            await _unitOfWork.CompleteAsync();

            // lấy all permissions để trả về kèm trạng thái
            var allPermissions = await _unitOfWork.PermissionRepository.GetAllPermissionsAsync();
            var updated = await _unitOfWork.UserPermissionRepository.GetPermissionsByUserIdAsync(userId);
            var grantedIds = updated.Select(p => p.Id).ToHashSet();

            var result = allPermissions.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                module = p.Module,
                description = p.Description,
                granted = grantedIds.Contains(p.Id)
            });

            return Ok(new
            {
                message = "Updated user permissions",
                userId,
                permissions = result
            });
        }

        [HttpPut("{id}/deactivate")]
        [Authorize(Policy = PermissionConstants.Users.Lock)]
        public async Task<IActionResult> Deactivate(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.IsActive = false;
            await _unitOfWork.CompleteAsync();
            return Ok(new { message = "Tài khoản đã bị khóa", user });
        }

        [HttpPut("{id}/activate")]
        
        [Authorize(Policy = PermissionConstants.Users.Lock)]
        public async Task<IActionResult> Activate(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.IsActive = true;
            await _unitOfWork.CompleteAsync();
            return Ok(new { message = "Tài khoản đã được mở khóa", user });
        }
        // ===== READ ALL =====
        [HttpGet]
        [Authorize(Policy = PermissionConstants.Users.View)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();

            var result = users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                IsActive = u.IsActive
                //Role = u.UserRoles != null && u.UserRoles.Any()
                //    ? string.Join(", ", u.UserRoles.Select(ur => ur.Role.Name))
                //    : ""
            });

            return Ok(result);
        }

        // ===== READ by Id =====
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionConstants.Users.View)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            var result = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                //Role = user.UserRoles != null && user.UserRoles.Any()
                //    ? string.Join(", ", user.UserRoles.Select(ur => ur.Role.Name))
                //    : ""
            };

            return Ok(result);
        }

        [HttpGet("search")]
        [Authorize(Policy = PermissionConstants.Users.View)]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest(new { message = "Keyword is required" });

            var users = await _unitOfWork.UserRepository.FindAsync(u =>
                u.Username.ToLower().Contains(keyword.ToLower()));

            if (!users.Any())
                return NotFound(new { message = "No users found matching the keyword" });

            var result = users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                //Role = u.UserRoles != null && u.UserRoles.Any()
                //    ? string.Join(", ", u.UserRoles.Select(ur => ur.Role.Name))
                //    : ""
            });

            return Ok(result);
        }


        // ===== CREATE =====
        //[HttpPost]
        //[Authorize(Policy = PermissionConstants.Users.Create)]
        //public async Task<IActionResult> Create([FromBody] UserDto dto)
        //{
        //    if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Email))
        //        return BadRequest("Username and Email are required");

        //    // Kiểm tra trùng Username
        //    var exists = await _unitOfWork.UserRepository.ExistsAsync(u => u.Username == dto.Username);
        //    if (exists)
        //        return BadRequest("Username already exists");

        //    var user = new User
        //    {
        //        Username = dto.Username,
        //        Email = dto.Email,
        //        IsActive = true
        //    };

        //    await _unitOfWork.UserRepository.AddAsync(user);
        //    await _unitOfWork.CompleteAsync();

        //    var result = new UserDto
        //    {
        //        Id = user.Id,
        //        Username = user.Username,
        //        Email = user.Email,
        //        Role = ""
        //    };

        //    return Ok(new
        //    {
        //        message = "User created successfully",
        //        data = result
        //    });
        //}

        // ===== UPDATE =====
        [HttpPut("{id}")]
        [Authorize(Policy = PermissionConstants.Users.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto dto)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            // Check trùng username nhưng bỏ qua chính nó
            var exists = await _unitOfWork.UserRepository.ExistsAsync(u => u.Username == dto.Username && u.Id != id);
            if (exists)
                return BadRequest("Username already exists");

            user.Username = dto.Username;
            user.Email = dto.Email;

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CompleteAsync();

            var result = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                //Role = user.UserRoles != null && user.UserRoles.Any()
                //    ? string.Join(", ", user.UserRoles.Select(ur => ur.Role.Name))
                //    : ""
            };

            return Ok(new
            {
                message = "User updated successfully",
                data = result
            });
        }

        [HttpPost("{userId}/assign-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(int userId, [FromBody] AssignRoleRequest request)
        {
            await _unitOfWork.UserRoleRepository.AssignRoleAsync(userId, request.RoleId);
            return Ok(new
            {
                message = "Role assigned successfully",
                userId,
                roleId = request.RoleId
            });
        }

        // Xoá role khỏi user
        [HttpDelete("{userId}/remove-role/{roleId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveRole(int userId, int roleId)
        {
            await _unitOfWork.UserRoleRepository.RemoveRoleAsync(userId, roleId);
            return Ok(new
            {
                message = "Role removed successfully",
                userId,
                roleId
            });
        }
    }
}

    

