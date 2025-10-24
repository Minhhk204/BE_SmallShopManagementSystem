using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.UnitOfWork;
using BE__Small_Shop_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Lấy tất cả category kèm product
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAllWithProductsAsync();

                if (!categories.Any())
                    return NotFound(ApiResponse<IEnumerable<CategoryDto>>.ErrorResponse("Không có danh mục nào"));

                return Ok(ApiResponse<IEnumerable<CategoryDto>>.SuccessResponse(categories, "Lấy danh mục thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    ApiResponse<string>.ErrorResponse("Lỗi server", new[] { ex.Message }, 500));
            }
        }

        //Lấy chi tiết 1 category theo id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Id không hợp lệ"));

                var category = await _unitOfWork.CategoryRepository.GetByIdWithProductsAsync(id);

                if (category == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy danh mục"));

                return Ok(ApiResponse<CategoryDto>.SuccessResponse(category, "Lấy chi tiết danh mục thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    ApiResponse<string>.ErrorResponse("Lỗi server", new[] { ex.Message }, 500));
            }
        }

        //Tạo mới category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(createDto.Name))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Tên danh mục không được để trống"));

                var category = new Category
                {
                    Name = createDto.Name
                };

                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                var result = new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Products = new List<ProductDto>() // mới tạo nên chưa có sản phẩm
                };

                return Ok(ApiResponse<CategoryDto>.SuccessResponse(result, "Tạo danh mục thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    ApiResponse<string>.ErrorResponse("Lỗi server", new[] { ex.Message }, 500));
            }
        }


        //Cập nhật category
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateDto)
        {
            try
            {
                if (id <= 0 || id != updateDto.Id)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Id không hợp lệ"));

                var existingCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
                if (existingCategory == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy danh mục"));

                existingCategory.Name = updateDto.Name;

                _unitOfWork.CategoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                var result = new CategoryDto
                {
                    Id = existingCategory.Id,
                    Name = existingCategory.Name,
                    Products = existingCategory.Products.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Stock = p.Stock,
                        ImageUrls = p.Images?.Select(i => $"{Request.Scheme}://{Request.Host}{i.ImageUrl}").ToList() ?? new List<string>()
                    }).ToList()
                };

                return Ok(ApiResponse<CategoryDto>.SuccessResponse(result, "Cập nhật danh mục thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    ApiResponse<string>.ErrorResponse("Lỗi server", new[] { ex.Message }, 500));
            }
        }

        [HttpGet("{id}/check-products")]
        public async Task<IActionResult> CheckProducts(int id)
        {
            if (id <= 0)
                return BadRequest(ApiResponse<string>.ErrorResponse("Id không hợp lệ"));

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy danh mục"));

            var products = await _unitOfWork.ProductRepository.FindAsync(p => p.CategoryId == id);
            bool hasProducts = products.Any();
            return Ok(ApiResponse<object>.SuccessResponse(new { hasProducts, productCount = products.Count() }));
        }

        [HttpPost("move-products")]
        public async Task<IActionResult> MoveProducts([FromBody] MoveProductsDto dto)
        {
            if (dto.FromCategoryId <= 0 || dto.ToCategoryId <= 0)
                return BadRequest(ApiResponse<string>.ErrorResponse("CategoryId không hợp lệ"));

            var fromCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(dto.FromCategoryId);
            var toCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(dto.ToCategoryId);

            if (fromCategory == null || toCategory == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy category"));

            var products = await _unitOfWork.ProductRepository.FindAsync(p => p.CategoryId == dto.FromCategoryId);
            foreach (var p in products)
            {
                p.CategoryId = dto.ToCategoryId;
                _unitOfWork.ProductRepository.Update(p);
            }
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<string>.SuccessResponse("Chuyển sản phẩm thành công", "OK"));
        }

        public class MoveProductsDto
        {
            public int FromCategoryId { get; set; }
            public int ToCategoryId { get; set; }
        }


        //Xóa category
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id <= 0)
                return BadRequest(ApiResponse<string>.ErrorResponse("Id không hợp lệ"));

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy danh mục"));

            var products = await _unitOfWork.ProductRepository.FindAsync(p => p.CategoryId == id);
            if (products.Any())
                return BadRequest(ApiResponse<string>.ErrorResponse("Danh mục này vẫn còn sản phẩm. Vui lòng chuyển sản phẩm sang danh mục khác trước khi xóa."));

            _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<string>.SuccessResponse("Xóa danh mục thành công", "OK"));
        }


    }


}
