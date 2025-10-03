using AutoMapper;
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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Lấy tất cả sản phẩm
        [HttpGet]
        [Authorize(Policy = PermissionConstants.Products.View)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _unitOfWork.ProductRepository
                .Query()
                .Include(p => p.Category)
                .ToListAsync();

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(ApiResponse<IEnumerable<ProductDto>>.SuccessResponse(productDtos, "Lấy danh sách sản phẩm thành công"));
        }


        // Lấy chi tiết sản phẩm
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionConstants.Products.View)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _unitOfWork.ProductRepository
                .Query()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

            return Ok(ApiResponse<ProductDto>.SuccessResponse(_mapper.Map<ProductDto>(product), "Lấy chi tiết sản phẩm thành công"));
        }



        // ================== PAGING ==================
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
             [FromQuery] decimal? minPrice,
             [FromQuery] decimal? maxPrice,
             [FromQuery] int pageNumber = 1,
             [FromQuery] int pageSize = 10)
        {
            try
            {
                var query = _unitOfWork.ProductRepository.GetProductsWithCategory();

                if (minPrice.HasValue)
                    query = query.Where(p => p.Price >= minPrice.Value);

                if (maxPrice.HasValue)
                    query = query.Where(p => p.Price <= maxPrice.Value);

                var totalItems = await query.CountAsync();

                var items = await query
                    .OrderBy(p => p.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Stock = p.Stock,
                        ImageUrl = !string.IsNullOrEmpty(p.ImageUrl)
                        ? $"{Request.Scheme}://{Request.Host}/images/{Path.GetFileName(p.ImageUrl)}"
                        : null,
                        CategoryName = p.Category != null ? p.Category.Name : ""
                    })
                    .ToListAsync();

                var result = new PagedResult<ProductDto>
                {
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Items = items
                };

                return Ok(ApiResponse<PagedResult<ProductDto>>.SuccessResponse(result, "Lấy danh sách sản phẩm phân trang thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi phân trang sản phẩm", new[] { ex.Message }, 500));
            }
        }


        // ================== SEARCH ==================

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string keyword,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Từ khóa là bắt buộc", null, 400));

                var query = _unitOfWork.ProductRepository
                    .Query()
                    .Include(p => p.Category)
                    .Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

                var totalItems = await query.CountAsync();

                if (totalItems == 0)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm nào khớp với từ khóa", null, 404));

                var items = await query
                    .OrderBy(p => p.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Stock = p.Stock,
                        ImageUrl = p.ImageUrl,
                        CategoryName = p.Category != null ? p.Category.Name : ""
                    })
                    .ToListAsync();

                var result = new PagedResult<ProductDto>
                {
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Items = items
                };

                return Ok(ApiResponse<PagedResult<ProductDto>>.SuccessResponse(result, "Tìm kiếm sản phẩm thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi tìm kiếm sản phẩm", new[] { ex.Message }, 500));
            }
        }


        // Tạo sản phẩm
        [HttpPost]
        [Authorize(Policy = PermissionConstants.Products.Create)]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<string>.ErrorResponse("Dữ liệu không hợp lệ"));

            // Tìm category theo CategoryName
            var category = await _unitOfWork.CategoryRepository
                .Query()
                .FirstOrDefaultAsync(c => c.Name == productDto.CategoryName);

            if (category == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Danh mục không tồn tại"));

            var product = _mapper.Map<Product>(productDto);
            product.CategoryId = category.Id;

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<ProductDto>.SuccessResponse(_mapper.Map<ProductDto>(product), "Tạo sản phẩm thành công"));
        }


        // Sửa sản phẩm
        [HttpPut("{id}")]
        [Authorize(Policy = PermissionConstants.Products.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

            var category = await _unitOfWork.CategoryRepository
                .Query()
                .FirstOrDefaultAsync(c => c.Name == productDto.CategoryName);

            if (category == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Danh mục không tồn tại"));

            _mapper.Map(productDto, product);
            product.CategoryId = category.Id;

            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<ProductDto>.SuccessResponse(_mapper.Map<ProductDto>(product), "Cập nhật sản phẩm thành công"));
        }

        // Xóa sản phẩm
        [HttpDelete("{id}")]
        [Authorize(Policy = PermissionConstants.Products.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<string>.SuccessResponse("Xóa sản phẩm thành công"));
        }

    }
}
