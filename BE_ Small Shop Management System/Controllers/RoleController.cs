using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Services;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RolePermissionService _service;
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(RolePermissionService service, IUnitOfWork unitOfWork)
        { _service = service;
          _unitOfWork = unitOfWork;
        }

        // Lấy list permission của role (true/false)
        [HttpGet("{roleId}/permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPermissionsOfRole(int roleId)
        {
            var map = await _service.GetPermissionMapAsync(roleId);
            return Ok(new { roleId, permissions = map });
        }

        // Gán quyền cho Role
        [HttpPost("{roleId}/assign-permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignPermissionsToRole(int roleId, [FromBody] AssignPermissionsRequest request)
        {
            //// lấy current permissions của role
            //var currentPermissions = await _unitOfWork.RolePermissionRepository.GetPermissionsByRoleIdAsync(roleId);
            //var currentIds = currentPermissions.Select(p => p.Id).ToHashSet();

            //// lặp qua request
            //foreach (var item in request.Permissions)
            //{
            //    if (item.Granted && !currentIds.Contains(item.Id))
            //    {
            //        // thêm mới
            //        await _unitOfWork.RolePermissionRepository.AssignAsync(roleId, new[] { item.Id });
            //    }
            //    else if (!item.Granted && currentIds.Contains(item.Id))
            //    {
            //        // gỡ bỏ
            //        await _unitOfWork.RolePermissionRepository.RemoveAsync(roleId, new[] { item.Id });
            //    }
            //}

            // Xóa toàn bộ quyền cũ
            //var currentPermissions = await _unitOfWork.RolePermissionRepository.GetPermissionsByRoleIdAsync(roleId);
            //if (currentPermissions.Any())
            //{
                await _unitOfWork.RolePermissionRepository.RemoveAllByRoleIdAsync(roleId);
            //}

            // Thêm lại theo danh sách request (chỉ những cái granted = true)
            var grantedIds = request.Permissions
                .Where(p => p.Granted)
                .Select(p => p.Id)
                .ToList();

            if (grantedIds.Any())
            {
                await _unitOfWork.RolePermissionRepository.AssignAsync(roleId, grantedIds);
            }

            await _unitOfWork.CompleteAsync();

            // lấy all permissions để trả về kèm trạng thái
            var allPermissions = await _unitOfWork.PermissionRepository.GetAllPermissionsAsync();
            var updated = await _unitOfWork.RolePermissionRepository.GetPermissionsByRoleIdAsync(roleId);
            var updateIds = updated.Select(p => p.Id).ToHashSet();

            var result = allPermissions.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                module = p.Module,
                description = p.Description,
                granted = updateIds.Contains(p.Id)
            });

            return Ok(new
            {
                message = "Updated role permissions",
                roleId,
                permissions = result
            });
        }
        
        // ===== READ ALL =====
        [HttpGet]
        [Authorize(Policy = PermissionConstants.Roles.View)]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _unitOfWork.RoleRepository.GetAllAsync();
            return Ok(roles.Select(r => new
            {
                r.Id,
                r.Name
            }));
        }

        // ===== READ by Id =====
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionConstants.Roles.View)]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            if (role == null) return NotFound();
            return Ok(role);
        }
        // ===== SEARCH =====
        [HttpGet("search")]
        [Authorize(Policy = PermissionConstants.Roles.View)]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest(new { message = "Keyword is required" });

            // Dùng FindAsync trong repository
            var roles = await _unitOfWork.RoleRepository.FindAsync(r =>
                r.Name.ToLower().Contains(keyword.ToLower()));

            if (!roles.Any())
                return NotFound(new { message = "No roles found matching the keyword" });

            return Ok(roles.Select(r => new
            {
                r.Id,
                r.Name
            }));
        }

        // ===== CREATE =====
        [HttpPost]
        [Authorize(Policy = PermissionConstants.Roles.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Role name is required");

            // 🔥 Kiểm tra trùng tên trước khi thêm
            var exists = await _unitOfWork.RoleRepository.ExistsAsync(r => r.Name == dto.Name);
            if (exists)
                return BadRequest("Role name already exists");

            var role = new Role
            {
                Name = dto.Name
            };

            await _unitOfWork.RoleRepository.AddAsync(role);
            await _unitOfWork.CompleteAsync();

            return Ok(new
            {
                message = "Role created successfully",
                roleId = role.Id,
                name = role.Name
            });
        }


        // ===== UPDATE =====
        [HttpPut("{id}")]
        [Authorize(Policy = PermissionConstants.Roles.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleDto update)
        {
            if (string.IsNullOrWhiteSpace(update.Name))
                return BadRequest("Role name is required");

            var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            if (role == null) return NotFound();

            // 🔥 Kiểm tra xem tên role mới có bị trùng với role khác không
            var exists = await _unitOfWork.RoleRepository.ExistsAsync(r => r.Name == update.Name && r.Id != id);
            if (exists)
                return BadRequest("Role name already exists");

            role.Name = update.Name;

            _unitOfWork.RoleRepository.Update(role);
            await _unitOfWork.CompleteAsync();

            return Ok(new
            {
                message = "Role updated successfully",
                roleId = role.Id,
                name = role.Name
            });
        }


        // ===== DELETE =====
        [HttpDelete("{id}")]
        [Authorize(Policy = PermissionConstants.Roles.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            if (role == null) return NotFound();

            _unitOfWork.RoleRepository.Delete(role);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Role deleted successfully", roleId = id });
        }
    }
}

   


