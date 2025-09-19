
using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Extensions;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Services;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BE__Small_Shop_Management_System.Constants.PermissionConstants;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RolePermissionService _service;
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(RolePermissionService service, IUnitOfWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }

        // Lấy list permission của role (true/false)
        [HttpGet("{roleId}/permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPermissionsOfRole(int roleId)
        {
            try
            {
                var map = await _service.GetPermissionMapAsync(roleId);
                return Ok(ApiResponse<object>.SuccessResponse(new { roleId, permissions = map }, "Lấy quyền của role thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("Lỗi khi lấy quyền role", new[] { ex.Message }, 500));
            }
        }

        // Gán quyền cho Role
        [HttpPost("{roleId}/assign-permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignPermissionsToRole(int roleId, [FromBody] AssignPermissionsRequest request)
        {
            try
            {
                await _unitOfWork.RolePermissionRepository.RemoveAllByRoleIdAsync(roleId);

                var grantedIds = request.Permissions
                    .Where(p => p.Granted)
                    .Select(p => p.Id)
                    .ToList();

                if (grantedIds.Any())
                {
                    await _unitOfWork.RolePermissionRepository.AssignAsync(roleId, grantedIds);
                }

                await _unitOfWork.CompleteAsync();

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

                return Ok(ApiResponse<object>.SuccessResponse(new { roleId, permissions = result }, "Cập nhật quyền vai trò thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("Lỗi khi gán quyền", new[] { ex.Message }, 500));
            }
        }

        // ===== READ ALL =====
        [HttpGet]
        [Authorize(Policy = PermissionConstants.Roles.View)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await _unitOfWork.RoleRepository.GetAllWithUsersAsync();
                var result = roles.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    UserCount = r.UserRoles.Count
                });

                return Ok(ApiResponse<IEnumerable<RoleDto>>.SuccessResponse(result, "Lấy danh sách vai trò thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("Lỗi khi lấy danh sách vai trò", new[] { ex.Message }, 500));
            }
        }

        // ===== READ by Id =====
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionConstants.Roles.View)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var role = await _unitOfWork.RoleRepository.GetByIdWithUsersAsync(id);
                if (role == null)
                    return NotFound(ApiResponse<object>.ErrorResponse("Không tìm thấy vai trò", null, 404));

                var dto = new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    UserCount = role.UserRoles.Count
                };

                return Ok(ApiResponse<RoleDto>.SuccessResponse(dto, "Lấy thông tin vai trò thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("Lỗi khi lấy vai trò", new[] { ex.Message }, 500));
            }
        }

        [HttpGet("paged")]
        [Authorize(Policy = PermissionConstants.Roles.View)]
        public async Task<IActionResult> GetPaged([FromQuery] PagedRequest request,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
        {
            try
            {
                var query = _unitOfWork.RoleRepository.Query();

                var result = await query
                    .Select(r => new RoleDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                        UserCount = r.UserRoles.Count
                    })
                    .ToPagedResultAsync(request.PageNumber, request.PageSize);

                return Ok(ApiResponse<object>.SuccessResponse(result, "Lấy danh sách phân trang thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("Lỗi khi phân trang vai trò", new[] { ex.Message }, 500));
            }
        }

        // ===== SEARCH =====
        [HttpGet("search")]
        [Authorize(Policy = PermissionConstants.Roles.View)]
        public async Task<IActionResult> Search(
        [FromQuery] string keyword,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 7)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return BadRequest(ApiResponse<object>.ErrorResponse("Từ khóa là bắt buộc", null, 400));

                var query = _unitOfWork.RoleRepository.Query()
                    .Where(r => r.Name.ToLower().Contains(keyword.ToLower()));
                if (!query.Any())
                    return NotFound(ApiResponse<object>.ErrorResponse("Không tìm thấy vai trò nào phù hợp", null, 404));
                var result = await query
                    .Select(r => new RoleDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                        UserCount = r.UserRoles.Count
                    })
                    .ToPagedResultAsync(pageNumber, pageSize);

                return Ok(ApiResponse<object>.SuccessResponse(result, "Tìm kiếm vai trò thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("Lỗi khi tìm kiếm vai trò", new[] { ex.Message }, 500));
            }
        }


        // ===== CREATE =====
        [HttpPost]
        [Authorize(Policy = PermissionConstants.Roles.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return BadRequest(ApiResponse<object>.ErrorResponse("Tên vai trò là bắt buộc", null, 400));

                var exists = await _unitOfWork.RoleRepository.ExistsAsync(r => r.Name == dto.Name);
                if (exists)
                    return BadRequest(ApiResponse<object>.ErrorResponse("Tên vai trò đã tồn tại", null, 400));

                var role = new Role { Name = dto.Name };

                await _unitOfWork.RoleRepository.AddAsync(role);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<object>.SuccessResponse(new { role.Id, role.Name }, "Tạo vai trò thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("Lỗi khi tạo vai trò", new[] { ex.Message }, 500));
            }
        }

        // ===== UPDATE =====
        [HttpPut("{id}")]
        [Authorize(Policy = PermissionConstants.Roles.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleDto update)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(update.Name))
                    return BadRequest(ApiResponse<object>.ErrorResponse("Tên vai trò là bắt buộc", null, 400));

                var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);
                if (role == null)
                    return NotFound(ApiResponse<object>.ErrorResponse("Không tìm thấy vai trò", null, 404));

                var exists = await _unitOfWork.RoleRepository.ExistsAsync(r => r.Name == update.Name && r.Id != id);
                if (exists)
                    return BadRequest(ApiResponse<object>.ErrorResponse("Tên vai trò đã tồn tại", null, 400));

                role.Name = update.Name;
                _unitOfWork.RoleRepository.Update(role);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<object>.SuccessResponse(new { role.Id, role.Name }, "Cập nhật vai trò thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("Lỗi khi cập nhật vai trò", new[] { ex.Message }, 500));
            }
        }

        // ===== DELETE =====
        [HttpDelete("{id}")]
        [Authorize(Policy = PermissionConstants.Roles.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);
                if (role == null)
                    return NotFound(ApiResponse<object>.ErrorResponse("Không tìm thấy vai trò", null, 404));

                _unitOfWork.RoleRepository.Delete(role);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<object>.SuccessResponse(new { roleId = id }, "Xóa vai trò thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("Lỗi khi xóa vai trò", new[] { ex.Message }, 500));
            }
        }
    }
}
