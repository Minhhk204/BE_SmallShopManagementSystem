using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE__Small_Shop_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordPolicyController : ControllerBase
    {
        private readonly PasswordPolicyService _policyService;

        public PasswordPolicyController(PasswordPolicyService policyService)
        {
            _policyService = policyService;
        }

        // ✅ Lấy chính sách
        [HttpGet]
        public IActionResult GetPolicy()
        {
            try
            {
                var policy = _policyService.GetPolicy();
                var dto = new PasswordPolicyDto
                {
                    RequiredLength = policy.RequiredLength,
                    RequireUppercase = policy.RequireUppercase,
                    RequireLowercase = policy.RequireLowercase,
                    RequireDigit = policy.RequireDigit,
                    RequireNonAlphanumeric = policy.RequireNonAlphanumeric
                };

                return Ok(ApiResponse<PasswordPolicyDto>.SuccessResponse(dto, "Lấy chính sách mật khẩu thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    ApiResponse<string>.ErrorResponse("Lỗi khi lấy chính sách mật khẩu", new[] { ex.Message }, 500));
            }
        }

        // ✅ Cập nhật chính sách
        [HttpPut]
        public IActionResult UpdatePolicy([FromBody] PasswordPolicyDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Dữ liệu không hợp lệ"));

                var policy = new PasswordPolicy
                {
                    RequiredLength = dto.RequiredLength,
                    RequireUppercase = dto.RequireUppercase,
                    RequireLowercase = dto.RequireLowercase,
                    RequireDigit = dto.RequireDigit,
                    RequireNonAlphanumeric = dto.RequireNonAlphanumeric
                };

                _policyService.UpdatePolicy(policy);

                return Ok(ApiResponse<string>.SuccessResponse(null, "Cập nhật chính sách mật khẩu thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    ApiResponse<string>.ErrorResponse("Lỗi khi cập nhật chính sách mật khẩu", new[] { ex.Message }, 500));
            }
        }

        // ✅ Validate mật khẩu
        [HttpPost("validate")]
        public IActionResult ValidatePassword([FromBody] string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(password))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Mật khẩu không được để trống"));

                var isValid = _policyService.ValidatePassword(password, out var errors);

                if (!isValid)
                {
                    return BadRequest(ApiResponse<object>.ErrorResponse("Mật khẩu không hợp lệ", errors));
                }

                return Ok(ApiResponse<object>.SuccessResponse(new { IsValid = true }, "Mật khẩu hợp lệ"));
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    ApiResponse<string>.ErrorResponse("Lỗi khi kiểm tra mật khẩu", new[] { ex.Message }, 500));
            }
        }
    }

}
