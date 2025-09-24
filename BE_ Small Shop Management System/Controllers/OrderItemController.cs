using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // 📌 Lấy chi tiết item theo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var orderItem = await _unitOfWork.OrderItemRepository.GetByIdAsync(id);
                if (orderItem == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy OrderItem"));

                return Ok(ApiResponse<OrderItem>.SuccessResponse(orderItem, "Lấy chi tiết OrderItem thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }
    }
}
