using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Tạo đơn hàng từ giỏ
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Không xác định được UserId từ token"));

                var cartItems = await _unitOfWork.CartItemRepository.GetCartByUserAsync(userId);
                if (!cartItems.Any())
                    return BadRequest(ApiResponse<string>.ErrorResponse("Giỏ hàng trống"));

                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    Status = "Pending",
                    TotalAmount = cartItems.Sum(c => c.Quantity * c.Product.Price),
                    OrderItems = cartItems.Select(ci => new OrderItem
                    {
                        ProductId = ci.ProductId,
                        Quantity = ci.Quantity,
                        Price = ci.Product.Price
                    }).ToList()
                };

                await _unitOfWork.OrderRepository.AddAsync(order);
                _unitOfWork.CartItemRepository.DeleteRange(cartItems);
                await _unitOfWork.CompleteAsync();

                //Gọi lại DTO sau khi lưu xong
                var orderDto = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(order.Id);

                return Ok(ApiResponse<OrderDto>.SuccessResponse(orderDto, "Đặt hàng thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }

        //Lấy danh sách đơn hàng của user
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Không xác định được UserId từ token"));

                var orders = await _unitOfWork.OrderRepository.GetOrdersByUserAsync(userId);

                return Ok(ApiResponse<IEnumerable<OrderDto>>.SuccessResponse(orders, "Lấy danh sách đơn hàng thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }
        //Lịch sử mua hàng của user
        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetOrderHistory(int userId)
        {
            try
            {
                if (userId <= 0)
                    return BadRequest(ApiResponse<string>.ErrorResponse("UserId không hợp lệ"));

                var history = await _unitOfWork.OrderRepository.GetOrderHistoryByUserAsync(userId);

                if (!history.Any())
                    return NotFound(ApiResponse<string>.ErrorResponse("Không có đơn hàng nào"));

                return Ok(ApiResponse<IEnumerable<OrderHistoryDto>>.SuccessResponse(history, "Lấy lịch sử đơn hàng thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi server", new[] { ex.Message }, 500));
            }
        }
    }
}
