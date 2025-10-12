using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        //  Tạo đơn hàng (checkout)
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

                // Kiểm tra tồn kho và trừ số lượng
                foreach (var item in cartItems)
                {
                    var product = item.Product;
                    if (product.Stock < item.Quantity)
                        return BadRequest(ApiResponse<string>.ErrorResponse($"Sản phẩm '{product.Name}' không đủ hàng trong kho"));

                    product.Stock -= item.Quantity;
                    _unitOfWork.ProductRepository.Update(product);
                }

                // Tạo đơn hàng với trạng thái 'Paid'
                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    Status = "Paid", // Đã thanh toán
                    TotalAmount = cartItems.Sum(c => c.Quantity * c.Product.Price),
                    OrderItems = cartItems.Select(ci => new OrderItem
                    {
                        ProductId = ci.ProductId,
                        Quantity = ci.Quantity,
                        Price = ci.Product.Price
                    }).ToList()
                };

                await _unitOfWork.OrderRepository.AddAsync(order);

                // Xóa giỏ hàng sau khi thanh toán
                _unitOfWork.CartItemRepository.DeleteRange(cartItems);

                // Lưu thay đổi (đơn hàng + trừ stock + xóa giỏ)
                await _unitOfWork.CompleteAsync();

                // Lấy thông tin đơn hàng vừa thanh toán
                var orderDto = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(order.Id);

                return Ok(ApiResponse<OrderDto>.SuccessResponse(orderDto, "Thanh toán thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }



        //  Lấy danh sách đơn hàng user

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

       
        // cập nhật trạng thái đơn hàng
       
        [HttpPut("{orderId}/status")]
     
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] UpdateOrderStatusDto dto)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId);
                if (order == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy đơn hàng"));

                // Kiểm tra trạng thái hợp lệ
                var validStatuses = new[] {  "Paid", "Completed" }; 
                if (!validStatuses.Contains(dto.Status))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Trạng thái không hợp lệ"));

                order.Status = dto.Status;
                _unitOfWork.OrderRepository.Update(order);
                await _unitOfWork.CompleteAsync();

                var updatedDto = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(order.Id);
                return Ok(ApiResponse<OrderDto>.SuccessResponse(updatedDto, $"Cập nhật trạng thái thành công: {dto.Status}"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }
    }
}
