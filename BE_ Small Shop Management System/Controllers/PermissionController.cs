using AutoMapper;
using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Repositories;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BE__Small_Shop_Management_System.Helper;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        /// Lấy toàn bộ permissions
        [HttpGet]
        [Authorize(Policy = PermissionConstants.Permissions.View)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var permissions = await _unitOfWork.PermissionRepository.GetAllPermissionsAsync();
                var result = permissions.Select(p => new PermissionDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Module = p.Module,
                    Description = p.Description ?? string.Empty
                });

                return Ok(ApiResponse<IEnumerable<PermissionDto>>.SuccessResponse(result, "Danh sách quyền"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi khi lấy danh sách quyền: {ex.Message}", statusCode: 500));
            }
        }


        /// Lấy chi tiết permission theo id
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionConstants.Permissions.View)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(id);
                if (permission == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy quyền", statusCode: 404));

                var dto = new PermissionDto
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Module = permission.Module,
                    Description = permission.Description ?? string.Empty
                };

                return Ok(ApiResponse<PermissionDto>.SuccessResponse(dto, "Chi tiết quyền"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi khi lấy quyền: {ex.Message}", statusCode: 500));
            }
        }

        /// Tìm kiếm permission theo keyword
        [HttpGet("search")]
        [Authorize(Policy = PermissionConstants.Permissions.View)]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Keyword là bắt buộc", statusCode: 400));

                var permissions = await _unitOfWork.PermissionRepository.FindAsync(p =>
                    p.Name.ToLower().Contains(keyword.ToLower()) ||
                    p.Module.ToLower().Contains(keyword.ToLower()) ||
                    (p.Description != null && p.Description.ToLower().Contains(keyword.ToLower()))
                );

                if (!permissions.Any())
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy quyền nào phù hợp", statusCode: 404));

                var result = permissions.Select(p => new PermissionDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Module = p.Module,
                    Description = p.Description ?? string.Empty
                });

                return Ok(ApiResponse<IEnumerable<PermissionDto>>.SuccessResponse(result, "Kết quả tìm kiếm quyền"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi khi tìm kiếm quyền: {ex.Message}", statusCode: 500));
            }
        }
    }
}
