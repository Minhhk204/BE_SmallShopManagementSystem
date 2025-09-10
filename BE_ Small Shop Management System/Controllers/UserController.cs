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
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserPermissionService _service;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(UserPermissionService service, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _service = service;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
                message = "Quyền người dùng được cập nhật",
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

            return Ok(new
            {
                message = "Tài khoản đã bị khóa",
                data = MapToDto(user)
            });
        }

        [HttpPut("{id}/activate")]
        [Authorize(Policy = PermissionConstants.Users.Lock)]
        public async Task<IActionResult> Activate(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.IsActive = true;
            await _unitOfWork.CompleteAsync();

            return Ok(new
            {
                message = "Tài khoản đã được mở khóa",
                data = MapToDto(user)
            });
        }



        // ===== READ ALL =====
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAllWithRolesAsync();
            var result = users.Select(u => MapToDto(u));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdWithRolesAsync(id);
            if (user == null) return NotFound(new { message = "Người dùng không tồn tại hoặc đã bị xóa" });

            return Ok(MapToDto(user));
        }


        // ===== SEARCH =====
        [HttpGet("search")]
        [Authorize(Policy = PermissionConstants.Users.View)]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest(new { message = "Từ khóa là bắt buộc" });

            var users = await _unitOfWork.UserRepository.FindAsync(u =>
                u.Username.ToLower().Contains(keyword.ToLower()) ||
                u.Email.ToLower().Contains(keyword.ToLower()) ||
                (!string.IsNullOrEmpty(u.FullName) && u.FullName.ToLower().Contains(keyword.ToLower()))
            );

            if (!users.Any())
                return NotFound(new { message = "Không tìm thấy người dùng nào khớp với từ khóa" });

            var result = users.Select(u => MapToDto(u));
            return Ok(result);
        }


        [HttpPost]
        [Authorize(Policy = PermissionConstants.Users.Create)]
        public async Task<IActionResult> Create([FromBody] UserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Email))
                return BadRequest("Tên người dùng và Email là bắt buộc");

            // Kiểm tra trùng Username
            var exists = await _unitOfWork.UserRepository.ExistsAsync(u => u.Username == dto.Username);
            if (exists)
                return BadRequest("Tên người dùng đã tồn tại");

            // Hash password (nếu null => để trống => bắt buộc reset khi login lần đầu)
            string passwordHash = string.IsNullOrWhiteSpace(dto.Password)
                ? string.Empty
                : BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // Tạo user
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = passwordHash,
                IsActive = dto.IsActive
            };

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            // Nếu nhập RoleName thì tìm RoleId tương ứng và gán
            if (!string.IsNullOrWhiteSpace(dto.RoleName))
            {
                var role = await _unitOfWork.RoleRepository.FindSingleAsync(r => r.Name == dto.RoleName);
                if (role == null)
                    return BadRequest($"Role '{dto.RoleName}' không tồn tại");

                await _unitOfWork.UserRoleRepository.AddAsync(new UserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id
                });

                await _unitOfWork.CompleteAsync();
            }

            return Ok(new
            {
                message = "Người dùng đã được tạo thành công",
                data = new
                {
                    user.Id,
                    user.Username,
                    user.Email,
                    user.FullName,
                    user.PhoneNumber,
                    user.IsActive,
                    RoleName = !string.IsNullOrWhiteSpace(dto.RoleName) ? dto.RoleName : null
                }
            });
        }





        // ===== UPDATE =====
        [HttpPut("{id}")]
        [Authorize(Policy = PermissionConstants.Users.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto dto)
        {
            var user = await _unitOfWork.UserRepository.GetByIdWithRolesAsync(id);
            if (user == null) return NotFound();

            // Fix cứng Id, Username, Email
            if (dto.Id != id || dto.Username != user.Username || dto.Email != user.Email)
            {
                return BadRequest("Không được phép thay đổi Id, Username hoặc Email");
            }

            // Update các field được phép sửa
            user.FullName = dto.FullName;
            user.PhoneNumber = dto.PhoneNumber;
            user.IsActive = dto.IsActive;

            // === Update Role ===
            user.UserRoles.Clear(); // xoá role cũ

            if (!string.IsNullOrWhiteSpace(dto.RoleName))
            {
                var role = await _unitOfWork.RoleRepository.FindSingleAsync(r => r.Name == dto.RoleName);
                if (role == null)
                    return BadRequest($"Role '{dto.RoleName}' không tồn tại");

                user.UserRoles.Add(new UserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id
                });
            }

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CompleteAsync();

            return Ok(new
            {
                message = "Người dùng đã cập nhật thành công",
                data = new
                {
                    user.Id,
                    user.Username,
                    user.Email,
                    user.FullName,
                    user.PhoneNumber,
                    user.IsActive,
                    RoleName = user.UserRoles.Any()
                        ? string.Join(", ", user.UserRoles.Select(r => r.Role.Name))
                        : null
                }
            });
        }



        // ===== DELETE =====
       
        [HttpPut("{id}/DeleteUser")]
        [Authorize(Policy = PermissionConstants.Users.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            user.IsActive = false;
            user.IsDeleted = true;
            await _unitOfWork.CompleteAsync();

            return Ok(new
            {
                message = "Tài khoản đã bị xóa",
                data = MapToDto(user)
            });
        }


        // ===== Helper mapping =====

        private UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                IsDeleted = user.IsDeleted,
                RoleName = user.UserRoles != null && user.UserRoles.Any()
                    ? string.Join(", ", user.UserRoles.Select(ur => ur.Role.Name))
                    : ""
            };
        }

        [HttpPost("{userId}/assign-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(int userId, [FromBody] AssignRoleRequest request)
        {
            await _unitOfWork.UserRoleRepository.AssignRoleAsync(userId, request.RoleId);
            return Ok(new
            {
                message = "Vai trò đã được chỉ định thành công",
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
                message = "Đã xóa vai trò thành công",
                userId,
                roleId
            });
        }
    }
}

    

