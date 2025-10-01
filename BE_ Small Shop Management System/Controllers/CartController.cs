using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Lấy giỏ hàng
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Không xác định được UserId từ token"));
                var cartItems = await _unitOfWork.CartItemRepository.GetCartByUserAsync(userId);

                var result = cartItems.Select(ci => new CartItemDto
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price,
                    ImageUrl = ci.Product.ImageUrl
                });

                return Ok(ApiResponse<IEnumerable<CartItemDto>>.SuccessResponse(result, "Lấy giỏ hàng thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }

        //Thêm vào giỏ hàng
        [HttpPost("{productId}")]
        public async Task<IActionResult> AddToCart(int productId, [FromQuery] int quantity = 1)
        {
            try
            {
                if (quantity <= 0)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Số lượng phải lớn hơn 0"));

                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Không xác định được UserId từ token"));
                await _unitOfWork.CartItemRepository.AddOrUpdateCartItemAsync(userId, productId, quantity);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<string>.SuccessResponse("Đã thêm sản phẩm vào giỏ hàng"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }

        //Xóa sản phẩm khỏi giỏ
        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Không xác định được UserId từ token"));
                var cartItem = await _unitOfWork.CartItemRepository.GetByUserAndProductAsync(userId, productId);

                if (cartItem == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm trong giỏ hàng"));

                _unitOfWork.CartItemRepository.Delete(cartItem);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<string>.SuccessResponse("Đã xóa sản phẩm khỏi giỏ hàng"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }
    }
}
