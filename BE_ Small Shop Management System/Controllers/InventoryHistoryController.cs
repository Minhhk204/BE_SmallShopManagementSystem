using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryHistoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryHistoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ================== GET PAGED ==================
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            var query = _unitOfWork.InventoryHistoryRepository.Query()
                .Include(h => h.Product)
                    .ThenInclude(p => p.Category)
                .Include(h => h.Product)
                    .ThenInclude(p => p.Images)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.Trim().ToLower();
                query = query.Where(h => h.Product != null && h.Product.Name.ToLower().Contains(lowerSearch));
            }

            var totalItems = await query.CountAsync();

            var items = await query
                .OrderByDescending(h => h.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // map dữ liệu dùng helper
            var itemDtos = items.Select(h => h.ToDto()).ToList();

            var result = new PagedResult<InventoryHistoryDto>
            {
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Items = itemDtos
            };

            return Ok(ApiResponse<PagedResult<InventoryHistoryDto>>.SuccessResponse(result, "Lấy lịch sử kho hàng thành công"));
        }

        // ================== GET BY PRODUCT ==================
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var histories = await _unitOfWork.InventoryHistoryRepository.Query()
                .Include(h => h.Product)
                    .ThenInclude(p => p.Category)
                .Include(h => h.Product)
                    .ThenInclude(p => p.Images)
                .Where(h => h.ProductId == productId)
                .OrderByDescending(h => h.CreatedAt)
                .ToListAsync();

            var itemDtos = histories.Select(h => h.ToDto()).ToList();

            return Ok(ApiResponse<IEnumerable<InventoryHistoryDto>>.SuccessResponse(itemDtos, "Lấy lịch sử sản phẩm thành công"));
        }

        // ================== IMPORT ==================
        [HttpPost("import")]
        public async Task<IActionResult> Import([FromBody] InventoryHistoryCreateDto dto)
        {
            if (dto == null || dto.QuantityChanged <= 0)
                return BadRequest(ApiResponse<string>.ErrorResponse("Dữ liệu không hợp lệ"));

            Product? product;

            if (dto.ProductId > 0)
            {
                product = await _unitOfWork.ProductRepository.Query()
                    .Include(p => p.Category)
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.Id == dto.ProductId);

                if (product == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

                product.Stock += dto.QuantityChanged;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(dto.ProductName) || dto.Price == null || dto.CategoryId == 0)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Thiếu thông tin sản phẩm mới"));

                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(dto.CategoryId);
                if (category == null)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Danh mục không tồn tại"));

                product = new Product
                {
                    Name = dto.ProductName!,
                    Description = dto.Description ?? string.Empty,
                    Price = dto.Price ?? 0,
                    Stock = dto.QuantityChanged,
                    CategoryId = dto.CategoryId,
                    IsActive = true,
                };

                await _unitOfWork.ProductRepository.AddAsync(product);
            }

            var history = new InventoryHistory
            {
                ProductId = product.Id,
                QuantityChanged = dto.QuantityChanged,
                Action = dto.Action ?? "Import",
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.InventoryHistoryRepository.AddAsync(history);
            await _unitOfWork.CompleteAsync();

            // trả về dùng ToDto helper
            var resultDto = history.ToDto();

            return Ok(ApiResponse<InventoryHistoryDto>.SuccessResponse(resultDto, "Nhập hàng thành công"));
        }
    }

    // ================== Helper extension ==================
    public static class InventoryHistoryExtensions
    {
        public static InventoryHistoryDto ToDto(this InventoryHistory history)
        {
            if (history == null) return null!;

            return new InventoryHistoryDto
            {
                Id = history.Id,
                ProductId = history.ProductId,
                QuantityChanged = history.QuantityChanged,
                Action = history.Action,
                CreatedAt = history.CreatedAt,
                Product = history.Product != null
                    ? new ProductDto
                    {
                        Id = history.Product.Id,
                        Name = history.Product.Name ?? string.Empty,
                        Description = history.Product.Description ?? string.Empty,
                        Price = history.Product.Price,
                        Stock = history.Product.Stock,
                        CategoryName = history.Product.Category != null ? history.Product.Category.Name : string.Empty,
                        IsActive = history.Product.IsActive,
                        IsFeatured = history.Product.IsFeatured,
                        ImageUrls = history.Product.Images != null
                            ? history.Product.Images.Select(img => img.ImageUrl).ToList()
                            : new List<string>()
                    }
                    : null
            };
        }
    }
}
