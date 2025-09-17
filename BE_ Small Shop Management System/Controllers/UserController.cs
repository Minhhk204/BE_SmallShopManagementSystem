using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using BE__Small_Shop_Management_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.Services;
using BE__Small_Shop_Management_System.Extensions;
<<<<<<< HEAD
using AutoMapper;
using BE__Small_Shop_Management_System.Helper;
=======
>>>>>>> 0a9ebdc51ae5d7340f24df443d257263092c0d9a
using static BE__Small_Shop_Management_System.Constants.PermissionConstants;

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

        // ================== GET PERMISSIONS ==================
        [HttpGet("{userId}/permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPermissionsOfUser(int userId)
        {
            try
            {
                var map = await _service.GetPermissionMapAsync(userId, includeRolePermissions: true);
                return Ok(ApiResponse<object>.SuccessResponse(
                    new { userId, permissions = map },
                    "Lấy quyền người dùng thành công"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi lấy quyền người dùng", new[] { ex.Message }, 500));
            }
        }

        // ================== ASSIGN PERMISSIONS ==================
        [HttpPost("{userId}/assign-permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignPermissionsToUser(int userId, [FromBody] AssignPermissionsRequest request)
        {
<<<<<<< HEAD
            try
            {
                var currentPermissions = await _unitOfWork.UserPermissionRepository.GetPermissionsByUserIdAsync(userId);
                var currentIds = currentPermissions.Select(p => p.Id).ToHashSet();

                foreach (var item in request.Permissions)
                {
                    if (item.Granted && !currentIds.Contains(item.Id))
                        await _unitOfWork.UserPermissionRepository.AssignAsync(userId, new[] { item.Id });
                    else if (!item.Granted && currentIds.Contains(item.Id))
                        await _unitOfWork.UserPermissionRepository.RemoveAsync(userId, new[] { item.Id });
                }

                await _unitOfWork.CompleteAsync();

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

                return Ok(ApiResponse<object>.SuccessResponse(
                    new { userId, permissions = result },
                    "Quyền người dùng được cập nhật"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi gán quyền người dùng", new[] { ex.Message }, 500));
            }
=======
            // Xóa toàn bộ quyền cũ
            await _unitOfWork.UserPermissionRepository.RemoveAllByUserIdAsync(userId);

            // Thêm lại theo danh sách request (chỉ những cái granted = true)
            var grantedIds = request.Permissions
                .Where(p => p.Granted)
                .Select(p => p.Id)
                .ToList();

            if (grantedIds.Any())
            {
                await _unitOfWork.UserPermissionRepository.AssignAsync(userId, grantedIds);
            }

            await _unitOfWork.CompleteAsync();

            // lấy all permissions để trả về kèm trạng thái
            var allPermissions = await _unitOfWork.PermissionRepository.GetAllPermissionsAsync();
            var updated = await _unitOfWork.UserPermissionRepository.GetPermissionsByUserIdAsync(userId);
            var updateGranted = updated.Select(p => p.Id).ToHashSet();

            var result = allPermissions.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                module = p.Module,
                description = p.Description,
                granted = updateGranted.Contains(p.Id)
            });

            return Ok(new
            {
                message = "Quyền người dùng được cập nhật",
                userId,
                permissions = result
            });
>>>>>>> 0a9ebdc51ae5d7340f24df443d257263092c0d9a
        }

        // ================== ACTIVATE / DEACTIVATE ==================
        [HttpPut("{id}/deactivate")]
        [Authorize(Policy = PermissionConstants.Users.Lock)]
        public async Task<IActionResult> Deactivate(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
                if (user == null) return NotFound(ApiResponse<string>.ErrorResponse("Người dùng không tồn tại", null, 404));

                user.IsActive = false;
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<UserDto>.SuccessResponse(MapToDto(user), "Tài khoản đã bị khóa"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi khóa tài khoản", new[] { ex.Message }, 500));
            }
        }

        [HttpPut("{id}/activate")]
        [Authorize(Policy = PermissionConstants.Users.Lock)]
        public async Task<IActionResult> Activate(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
                if (user == null) return NotFound(ApiResponse<string>.ErrorResponse("Người dùng không tồn tại", null, 404));

                user.IsActive = true;
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<UserDto>.SuccessResponse(MapToDto(user), "Tài khoản đã được mở khóa"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi mở khóa tài khoản", new[] { ex.Message }, 500));
            }
        }

        // ================== GET ALL ==================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _unitOfWork.UserRepository.GetAllWithRolesAsync();
                var result = users.Select(u => MapToDto(u));
                return Ok(ApiResponse<object>.SuccessResponse(result, "Lấy danh sách người dùng thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi lấy danh sách người dùng", new[] { ex.Message }, 500));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdWithRolesAsync(id);
                if (user == null) return NotFound(ApiResponse<string>.ErrorResponse("Người dùng không tồn tại hoặc đã bị xóa", null, 404));

                return Ok(ApiResponse<UserDto>.SuccessResponse(MapToDto(user), "Lấy thông tin người dùng thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi lấy người dùng theo Id", new[] { ex.Message }, 500));
            }
        }

        // ================== PAGING ==================
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] bool? isActive,
            [FromQuery] string? email,
            [FromQuery] string? username,
            [FromQuery] string? phone,
            [FromQuery] string? fullName,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var query = _unitOfWork.UserRepository.Query();

                if (isActive.HasValue) query = query.Where(u => u.IsActive == isActive.Value);
                if (!string.IsNullOrEmpty(email)) query = query.Where(u => u.Email.Contains(email));
                if (!string.IsNullOrEmpty(username)) query = query.Where(u => u.Username.Contains(username));
                if (!string.IsNullOrEmpty(phone)) query = query.Where(u => u.PhoneNumber.Contains(phone));
                if (!string.IsNullOrEmpty(fullName)) query = query.Where(u => u.FullName.Contains(fullName));

                var totalItems = await query.CountAsync();

                var items = await query
                    .OrderBy(u => u.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(u => new UserDto
                    {
                        Id = u.Id,
                        Username = u.Username,
                        Email = u.Email,
                        FullName = u.FullName,
                        PhoneNumber = u.PhoneNumber,
                        IsActive = u.IsActive
                    })
                    .ToListAsync();

                var result = new PagedResult<UserDto>
                {
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Items = items
                };

                return Ok(ApiResponse<PagedResult<UserDto>>.SuccessResponse(result, "Lấy danh sách người dùng phân trang thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi phân trang người dùng", new[] { ex.Message }, 500));
            }
        }

        // ================== SEARCH ==================
        [HttpGet("search")]
        [Authorize(Policy = PermissionConstants.Users.View)]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Từ khóa là bắt buộc", null, 400));

                var users = await _unitOfWork.UserRepository.FindAsync(u =>
                    u.Username.ToLower().Contains(keyword.ToLower()) ||
                    u.Email.ToLower().Contains(keyword.ToLower()) ||
                    (!string.IsNullOrEmpty(u.FullName) && u.FullName.ToLower().Contains(keyword.ToLower()))
                );

                if (!users.Any())
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy người dùng nào khớp với từ khóa", null, 404));

                var result = users.Select(u => MapToDto(u));
                return Ok(ApiResponse<object>.SuccessResponse(result, "Tìm kiếm người dùng thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi tìm kiếm người dùng", new[] { ex.Message }, 500));
            }
        }

        // ================== CREATE ==================
        [HttpPost]
        [Authorize(Policy = PermissionConstants.Users.Create)]
        public async Task<IActionResult> Create([FromBody] UserDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Email))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Tên người dùng và Email là bắt buộc", null, 400));

                var exists = await _unitOfWork.UserRepository.ExistsAsync(u => u.Username == dto.Username);
                if (exists)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Tên người dùng đã tồn tại", null, 400));

                string passwordHash = string.IsNullOrWhiteSpace(dto.Password)
                    ? string.Empty
                    : BCrypt.Net.BCrypt.HashPassword(dto.Password);

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

                //if (!string.IsNullOrWhiteSpace(dto.RoleName))
                //{
                //    var role = await _unitOfWork.RoleRepository.FindSingleAsync(r => r.Name == dto.RoleName);
                //    if (role == null)
                //        return BadRequest(ApiResponse<string>.ErrorResponse($"Role '{dto.RoleName}' không tồn tại", null, 400));

                //    await _unitOfWork.UserRoleRepository.AddAsync(new UserRole { UserId = user.Id, RoleId = role.Id });
                //    await _unitOfWork.CompleteAsync();
                //}
                // Gán nhiều roles
                if (dto.RoleName != null && dto.RoleName.Any())
                {
                    foreach (var roleName in dto.RoleName)
                    {
                        var role = await _unitOfWork.RoleRepository.FindSingleAsync(r => r.Name == roleName);
                        if (role == null)
                            return BadRequest(ApiResponse<string>.ErrorResponse($"Role '{roleName}' không tồn tại", null, 400));

                        await _unitOfWork.UserRoleRepository.AddAsync(new UserRole
                        {
                            UserId = user.Id,
                            RoleId = role.Id
                        });
                    }
                    await _unitOfWork.CompleteAsync();
                }

                return Ok(ApiResponse<object>.SuccessResponse(
                    new
                    {
                        user.Id,
                        user.Username,
                        user.Email,
                        user.FullName,
                        user.PhoneNumber,
                        user.IsActive,
                        //RoleName = dto.RoleName
                        Roles = dto.RoleName
                    },
                    "Người dùng đã được tạo thành công"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi tạo người dùng", new[] { ex.Message }, 500));
            }
        }

        // ================== UPDATE ==================
        [HttpPut("{id}")]
        [Authorize(Policy = PermissionConstants.Users.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto dto)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdWithRolesAsync(id);
                if (user == null) return NotFound(ApiResponse<string>.ErrorResponse("Người dùng không tồn tại", null, 404));

                if (dto.Id != id || dto.Username != user.Username || dto.Email != user.Email)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Không được phép thay đổi Id, Username hoặc Email", null, 400));

                user.FullName = dto.FullName;
                user.PhoneNumber = dto.PhoneNumber;
                user.IsActive = dto.IsActive;

                user.UserRoles.Clear();

                //if (!string.IsNullOrWhiteSpace(dto.RoleName))
                //{
                //    var role = await _unitOfWork.RoleRepository.FindSingleAsync(r => r.Name == dto.RoleName);
                //    if (role == null)
                //        return BadRequest(ApiResponse<string>.ErrorResponse($"Role '{dto.RoleName}' không tồn tại", null, 400));

                //    user.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = role.Id });
                //}
                // Gán lại roles mới
                if (dto.RoleName != null && dto.RoleName.Any())
                {
                    foreach (var roleName in dto.RoleName)
                    {
                        var role = await _unitOfWork.RoleRepository.FindSingleAsync(r => r.Name == roleName);
                        if (role == null)
                            return BadRequest(ApiResponse<string>.ErrorResponse($"Role '{roleName}' không tồn tại", null, 400));

                        user.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = role.Id });
                    }
                }

                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<object>.SuccessResponse(
                    new
                    {
                        user.Id,
                        user.Username,
                        user.Email,
                        user.FullName,
                        user.PhoneNumber,
                        user.IsActive,
                        //RoleName = user.UserRoles.Any()
                        //    ? string.Join(", ", user.UserRoles.Select(r => r.Role.Name))
                        //    : null
                        RoleName = user.UserRoles.Select(ur => ur.Role.Name).ToList()
                    },
                    "Người dùng đã cập nhật thành công"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi cập nhật người dùng", new[] { ex.Message }, 500));
            }
        }

        // ================== SET PASSWORD ==================
        [HttpPut("{id}/set-password")]
        [Authorize(Policy = PermissionConstants.Users.Update)]
        public async Task<IActionResult> SetPassword(int id, [FromBody] SetPasswordRequest request)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
                if (user == null) return NotFound(ApiResponse<string>.ErrorResponse("Người dùng không tồn tại", null, 404));

                if (!string.IsNullOrWhiteSpace(user.PasswordHash) && !string.IsNullOrWhiteSpace(request.CurrentPassword))
                {
                    bool isMatch = BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash);
                    if (!isMatch)
                        return BadRequest(ApiResponse<string>.ErrorResponse("Mật khẩu hiện tại không đúng", null, 400));
                }

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<object>.SuccessResponse(
                    new { user.Id, user.Username },
                    "Mật khẩu đã được thay đổi thành công"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi đặt mật khẩu", new[] { ex.Message }, 500));
            }
        }

        // ================== DELETE ==================
        [HttpPut("{id}/DeleteUser")]
        [Authorize(Policy = PermissionConstants.Users.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
                if (user == null) return NotFound(ApiResponse<string>.ErrorResponse("Người dùng không tồn tại", null, 404));

                user.IsActive = false;
                user.IsDeleted = true;
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<UserDto>.SuccessResponse(MapToDto(user), "Tài khoản đã bị xóa"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi xóa người dùng", new[] { ex.Message }, 500));
            }
        }

        // ================== ASSIGN / REMOVE ROLE ==================
        [HttpPost("{userId}/assign-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(int userId, [FromBody] AssignRoleRequest request)
        {
            try
            {
                await _unitOfWork.UserRoleRepository.AssignRoleAsync(userId, request.RoleId);
                return Ok(ApiResponse<object>.SuccessResponse(
                    new { userId, request.RoleId },
                    "Vai trò đã được chỉ định thành công"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi gán vai trò", new[] { ex.Message }, 500));
            }
        }

        [HttpDelete("{userId}/remove-role/{roleId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveRole(int userId, int roleId)
        {
            try
            {
                await _unitOfWork.UserRoleRepository.RemoveRoleAsync(userId, roleId);
                return Ok(ApiResponse<object>.SuccessResponse(
                    new { userId, roleId },
                    "Đã xóa vai trò thành công"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi xóa vai trò", new[] { ex.Message }, 500));
            }
        }

        // ================== HELPER ==================
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
                //RoleName = user.UserRoles != null && user.UserRoles.Any()
                //    ? string.Join(", ", user.UserRoles.Select(ur => ur.Role.Name))
                //    : ""
                RoleName = user.UserRoles != null && user.UserRoles.Any()
                ? user.UserRoles.Select(ur => ur.Role.Name).ToList()
                : new List<string>()
            };
        }
    }
}
