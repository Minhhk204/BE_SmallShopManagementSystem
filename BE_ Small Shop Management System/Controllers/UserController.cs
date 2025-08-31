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

        [HttpGet]
        [Authorize(Policy = PermissionConstants.Users.View)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return Ok(users.Select(u => new {
                u.Id,
                u.Username,
                u.Email,
                u.IsActive
            }));
        }

        // ===== CREATE =====
        [HttpPost]
        [Authorize(Policy = PermissionConstants.Users.Create)]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // ===== READ by Id =====
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionConstants.Users.View)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // ===== UPDATE =====
        [HttpPut("{id}")]
        [Authorize(Policy = PermissionConstants.Users.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] User update)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.Username = update.Username;
            user.Email = update.Email;
            user.IsActive = update.IsActive;

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CompleteAsync();

            return Ok(user);
        }

        // ===== DELETE =====
        //[HttpDelete("{id}")]
        //[Authorize(Policy = PermissionConstants.Users.Delete)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
        //    if (user == null) return NotFound();

        //    _unitOfWork.UserRepository.Delete(user);
        //    await _unitOfWork.CompleteAsync();

        //    return NoContent();
        //}
        // Gán role cho user
        [HttpPost("{userId}/assign-role")]
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

    

