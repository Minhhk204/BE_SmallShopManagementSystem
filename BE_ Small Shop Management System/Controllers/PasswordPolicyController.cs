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
        private readonly PasswordPolicyService _service;

        public PasswordPolicyController(PasswordPolicyService service)
        {
            _service = service;
        }

        // GET: api/PasswordPolicy
        [HttpGet]
        public async Task<IActionResult> GetPolicy()
        {
            try
            {
                var policy = await _service.GetPolicyAsync();
                return Ok(ApiResponse<PasswordPolicy>.SuccessResponse(policy, "Lấy password policy thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi lấy policy", new[] { ex.Message }, 500));
            }
        }

        // PUT: api/PasswordPolicy
        [HttpPut]
        public async Task<IActionResult> UpdatePolicy([FromBody] PasswordPolicyDto dto)
        {
            try
            {
                var policy = await _service.UpdatePolicyAsync(dto);
                return Ok(ApiResponse<PasswordPolicy>.SuccessResponse(policy, "Cập nhật password policy thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi cập nhật policy", new[] { ex.Message }, 500));
            }
        }

        // POST: api/PasswordPolicy/validate
        [HttpPost("validate")]
        public IActionResult ValidatePassword([FromBody] string password)
        {
            try
            {
                var isValid = _service.ValidatePassword(password, out var errors);

                if (!isValid)
                    return BadRequest(ApiResponse<object>.ErrorResponse("Mật khẩu không hợp lệ", errors, 400));

                return Ok(ApiResponse<object>.SuccessResponse(null, "Mật khẩu hợp lệ"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi validate mật khẩu", new[] { ex.Message }, 500));
            }
        }
    }

}
