using BE__Small_Shop_Management_System.Constants;
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
        [Authorize(Policy = PermissionConstants.Orders.Create)]
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
        [Authorize(Policy = PermissionConstants.Orders.View)]
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
        [Authorize(Policy = PermissionConstants.Orders.View)]
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

        // Cập nhật trạng thái đơn hàng 
        [HttpPut("{orderId}/status")]
        [Authorize(Policy = PermissionConstants.Orders.Update)]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] string newStatus)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository
                    .GetAsync(o => o.Id == orderId, includeProperties: "User,OrderItems");

                if (order == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy đơn hàng."));

                // Danh sách trạng thái hợp lệ
                var validStatuses = new[] { "Pending", "Processing", "Completed", "Cancelled" };
                if (!validStatuses.Contains(newStatus))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Trạng thái không hợp lệ."));

                // Quy tắc chuyển trạng thái
                bool canChange = (order.Status, newStatus) switch
                {
                    ("Pending", "Processing") => true,
                    ("Processing", "Completed") => true,
                    ("Pending", "Cancelled") => true,
                    ("Processing", "Cancelled") => true,
                    _ => false
                };

                if (!canChange)
                    return BadRequest(ApiResponse<string>.ErrorResponse($"Không thể chuyển từ {order.Status} sang {newStatus}."));

                // Cập nhật trạng thái
                order.Status = newStatus;
                await _unitOfWork.CompleteAsync();

                var orderDto = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(order.Id);

                return Ok(ApiResponse<OrderDto>.SuccessResponse(orderDto, $"Cập nhật trạng thái đơn hàng #{order.Id} thành công."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }

    }
}
