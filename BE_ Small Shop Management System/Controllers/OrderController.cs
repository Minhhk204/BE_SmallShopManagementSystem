using AutoMapper;
using BE__Small_Shop_Management_System.Constants;
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
        private readonly IUnitOfWork _unitOfWork ;
        private readonly IMapper _mapper ;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //  Tạo đơn hàng 
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
                var selectedItems = cartItems.Where(c => c.IsSelected==true).ToList();

                if (!selectedItems.Any())
                    return BadRequest(ApiResponse<string>.ErrorResponse("Vui lòng chọn ít nhất một sản phẩm để thanh toán"));

                foreach (var item in selectedItems)
                {
                    if (item.Product.Stock < item.Quantity)
                        return BadRequest(ApiResponse<string>.ErrorResponse($"Sản phẩm '{item.Product.Name}' không đủ hàng"));

                    item.Product.Stock -= item.Quantity;
                    _unitOfWork.ProductRepository.Update(item.Product);
                }

                
                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    Status = "Paid",
                    TotalAmount = selectedItems.Sum(i => i.Quantity * i.Product.Price),
                    OrderItems = selectedItems.Select(i => new OrderItem
                    {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        Price = i.Product.Price
                    }).ToList()
                };

                await _unitOfWork.OrderRepository.AddAsync(order);

                
                _unitOfWork.CartItemRepository.DeleteRange(selectedItems);

                await _unitOfWork.CompleteAsync();

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
        // cập nhật trạng thái đơn hàng
        //[HttpPut("{orderId}/status")]
        //[Authorize(Policy = PermissionConstants.Orders.Update)]
        //public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] UpdateOrderStatusDto dto)
        //{
        //    try
        //    {
        //        var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId);
        //        if (order == null)
        //            return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy đơn hàng"));

        //        // Kiểm tra trạng thái hợp lệ
        //        var validStatuses = new[] { "Pending", "Paid", "Shipping","Completed" }; 
        //        if (!validStatuses.Contains(dto.Status))
        //            return BadRequest(ApiResponse<string>.ErrorResponse("Trạng thái không hợp lệ"));
        //        order.Status = dto.Status;
        //        _unitOfWork.OrderRepository.Update(order);
        //        await _unitOfWork.CompleteAsync();

        //        var updatedDto = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(order.Id);
        //        return Ok(ApiResponse<OrderDto>.SuccessResponse(updatedDto, $"Cập nhật trạng thái thành công: {dto.Status}"));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
        //    }
        //}
    }
}
