using AutoMapper;
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
    [Authorize] // bắt buộc đăng nhập mới thao tác được
    public class FavoriteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FavoriteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Lấy danh sách yêu thích
        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Không xác định được UserId từ token"));

                var favorites = await _unitOfWork.FavoriteRepository.GetFavoritesByUserAsync(userId);

                var favoriteDtos = favorites.Select(f => new FavoriteDto
                {
                    ProductId = f.ProductId,
                    ProductName = f.Product.Name,
                    ImageUrl = f.Product.ImageUrl,
                    CreatedAt = f.CreatedAt
                });

                return Ok(ApiResponse<IEnumerable<FavoriteDto>>.SuccessResponse(favoriteDtos, "Lấy danh sách yêu thích thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }

        //Thêm sản phẩm vào yêu thích
        [HttpPost("{productId}")]
        public async Task<IActionResult> AddFavorite(int productId)
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Không xác định được UserId từ token"));

                var exists = await _unitOfWork.FavoriteRepository.GetByUserAndProductAsync(userId, productId);
                if (exists != null)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Sản phẩm đã có trong danh sách yêu thích"));

                var favorite = new Favorite
                {
                    UserId = userId,
                    ProductId = productId,
                    CreatedAt = DateTime.Now
                };

                await _unitOfWork.FavoriteRepository.AddAsync(favorite);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<string>.SuccessResponse("Đã thêm sản phẩm vào yêu thích"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }

        //Xóa sản phẩm khỏi yêu thích
        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFavorite(int productId)
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(ApiResponse<string>.ErrorResponse("Không xác định được UserId từ token"));

                var favorite = await _unitOfWork.FavoriteRepository.GetByUserAndProductAsync(userId, productId);
                if (favorite == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm trong danh sách yêu thích"));

                _unitOfWork.FavoriteRepository.Delete(favorite);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<string>.SuccessResponse("Đã xóa sản phẩm khỏi yêu thích"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}", statusCode: 500));
            }
        }

    }
}

