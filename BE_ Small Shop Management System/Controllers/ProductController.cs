using AutoMapper;
using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        // ================== GET ALL ==================
        //[HttpGet]
        //[Authorize(Policy = PermissionConstants.Products.View)]
        //public async Task<IActionResult> GetAll()
        //{
        //    var products = await _unitOfWork.ProductRepository
        //        .Query()
        //        .Include(p => p.Category)
        //        .Include(p => p.Images)
        //        .ToListAsync();

        //    var dtos = products.Select(p => new ProductDto
        //    {
        //        Id = p.Id,
        //        Name = p.Name,
        //        Description = p.Description,
        //        Price = p.Price,
        //        Stock = p.Stock ,
        //        CategoryName = p.Category?.Name ?? string.Empty,
        //        ImageUrls = p.Images?.Select(i => $"{Request.Scheme}://{Request.Host}{i.ImageUrl}").ToList() ?? new List<string>()
        //    });

        //    return Ok(ApiResponse<IEnumerable<ProductDto>>.SuccessResponse(dtos, "Lấy danh sách sản phẩm thành công"));
        //}

        // ================== GET BY ID ==================
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionConstants.Products.View)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _unitOfWork.ProductRepository
                .Query()
                .Include(p => p.Category)
                .Include(p => p.Images)
                 .Where(p => p.IsActive)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

            var dto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock ,
                CategoryName = product.Category?.Name ?? string.Empty,
                ImageUrls = product.Images?.Select(i => $"{Request.Scheme}://{Request.Host}{i.ImageUrl}").ToList() ?? new List<string>()
            };

            return Ok(ApiResponse<ProductDto>.SuccessResponse(dto, "Lấy chi tiết sản phẩm thành công"));
        }

        // ================== PAGED ==================
        [HttpGet("paged")]
        //[Authorize(Policy = PermissionConstants.Products.View)]
        public async Task<IActionResult> GetPaged(
             [FromQuery] decimal? minPrice,
             [FromQuery] decimal? maxPrice,
             [FromQuery] int pageNumber = 1,
             [FromQuery] int pageSize = 10)
        {
            try
            {
                var query = _unitOfWork.ProductRepository
                    .Query()
                    .Include(p => p.Category)
                    .Include(p => p.Images)
                    .Where(p => p.IsActive)
                    .AsQueryable();

                if (minPrice.HasValue) query = query.Where(p => p.Price >= minPrice.Value);
                if (maxPrice.HasValue) query = query.Where(p => p.Price <= maxPrice.Value);

                var totalItems = await query.CountAsync();

                var items = await query
                    .OrderBy(p => p.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var itemDtos = items.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    IsActive = p.IsActive,
                    CategoryName = p.Category?.Name ?? string.Empty,
                    ImageUrls = p.Images?.Select(i => $"{Request.Scheme}://{Request.Host}{i.ImageUrl}").ToList() ?? new List<string>()
                }).ToList();

                var result = new PagedResult<ProductDto>
                {
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Items = itemDtos
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
        [Authorize(Policy = PermissionConstants.Products.View)]
        public async Task<IActionResult> Search(
            [FromQuery] string keyword,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return BadRequest(ApiResponse<string>.ErrorResponse("Từ khóa là bắt buộc", null, 400));

                var lower = keyword.Trim().ToLower();

                var query = _unitOfWork.ProductRepository
                    .Query()
                    .Include(p => p.Category)
                    .Include(p => p.Images)

                    .Where(p =>
                        p.Name.ToLower().Contains(lower) ||
                        (p.Description != null && p.Description.ToLower().Contains(lower)) ||
                        (p.Category != null && p.Category.Name.ToLower().Contains(lower))
                    );

                var totalItems = await query.CountAsync();

                if (totalItems == 0)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm nào khớp với từ khóa", null, 404));

                var items = await query
                    .OrderBy(p => p.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var itemDtos = items.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock ,
                    CategoryName = p.Category?.Name ?? string.Empty,
                    ImageUrls = p.Images?.Select(i => $"{Request.Scheme}://{Request.Host}{i.ImageUrl}").ToList() ?? new List<string>()
                }).ToList();

                var result = new PagedResult<ProductDto>
                {
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Items = itemDtos
                };

                return Ok(ApiResponse<PagedResult<ProductDto>>.SuccessResponse(result, "Tìm kiếm sản phẩm thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi tìm kiếm sản phẩm", new[] { ex.Message }, 500));
            }
        }

        // ================== CREATE ==================
        [HttpPost]
        [Authorize(Policy = PermissionConstants.Products.Create)]
        public async Task<IActionResult> Create([FromForm] ProductCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<string>.ErrorResponse("Dữ liệu không hợp lệ"));

            var category = await _unitOfWork.CategoryRepository
                .Query()
                .FirstOrDefaultAsync(c => c.Name == dto.CategoryName);

            if (category == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Danh mục không tồn tại"));

            var product = _mapper.Map<Product>(dto);
            product.CategoryId = category.Id;
            product.Images = new List<ProductImage>();

            // upload files nếu có
            if (dto.Files != null && dto.Files.Any())
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images", "products");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                foreach (var file in dto.Files)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var savePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    product.Images.Add(new ProductImage { ImageUrl = $"/images/products/{fileName}" });
                }
            }

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            var resultDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryName = category.Name,
                ImageUrls = product.Images?.Select(i => $"{Request.Scheme}://{Request.Host}{i.ImageUrl}").ToList() ?? new List<string>()
            };

            return Ok(ApiResponse<ProductDto>.SuccessResponse(resultDto, "Tạo sản phẩm thành công"));
        }

        // ================== UPDATE ==================
        [HttpPut("{id}")]
        [Authorize(Policy = PermissionConstants.Products.Update)]
        public async Task<IActionResult> Update(int id, [FromForm] ProductCreateUpdateDto dto)
        {
            // Lấy sản phẩm kèm ảnh + category
            var product = await _unitOfWork.ProductRepository
                .Query()
                .Include(p => p.Images)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

            // Kiểm tra danh mục
            var category = await _unitOfWork.CategoryRepository
                .Query()
                .FirstOrDefaultAsync(c => c.Name == dto.CategoryName);

            if (category == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Danh mục không tồn tại"));

            // Cập nhật các trường cơ bản
            _mapper.Map(dto, product);
            product.CategoryId = category.Id;

            // Thư mục lưu ảnh
            var uploadsFolder = Path.Combine(_env.WebRootPath, "images", "products");
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            // ================== XÓA ẢNH CŨ ==================
            if (dto.DeletedImageIds != null && dto.DeletedImageIds.Any())
            {
                var toDelete = product.Images
                    .Where(i => dto.DeletedImageIds.Contains(i.Id))
                    .ToList();

                foreach (var img in toDelete)
                {
                    var oldPath = Path.Combine(_env.WebRootPath, img.ImageUrl.TrimStart('/')
                        .Replace("/", Path.DirectorySeparatorChar.ToString()));

                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);

                    product.Images.Remove(img);
                }
            }

            // ================== THÊM ẢNH MỚI ==================
            if (dto.Files != null && dto.Files.Any())
            {
                foreach (var file in dto.Files)
                {
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var savePath = Path.Combine(uploadsFolder, fileName);

                    using var stream = new FileStream(savePath, FileMode.Create);
                    await file.CopyToAsync(stream);

                    product.Images.Add(new ProductImage
                    {
                        ImageUrl = $"/images/products/{fileName}"
                    });
                }
            }

            await _unitOfWork.CompleteAsync();

            // Trả về DTO kết quả
            var resultDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryName = category.Name,
                IsActive = product.IsActive,
                ImageUrls = product.Images?.Select(i =>
                    $"{Request.Scheme}://{Request.Host}{i.ImageUrl}").ToList() ?? new List<string>()
            };

            return Ok(ApiResponse<ProductDto>.SuccessResponse(resultDto, "Cập nhật sản phẩm thành công"));
        }
        // ================== GET FEATURED PRODUCTS ==================
        [HttpGet("featured")]
        //[Authorize(Policy = PermissionConstants.Products.View)] //
        public async Task<IActionResult> GetFeaturedProducts()
        {
            try
            {
                var featuredProducts = await _unitOfWork.ProductRepository
                    .Query()
                    .Include(p => p.Category)
                    .Include(p => p.Images)
                    .Where(p => p.IsActive && p.IsFeatured) // chỉ lấy sản phẩm đang hoạt động & nổi bật
                    .OrderByDescending(p => p.Id)
                    .Take(8) 
                    .ToListAsync();

                if (!featuredProducts.Any())
                    return NotFound(ApiResponse<string>.ErrorResponse("Không có sản phẩm nổi bật nào."));

                var dtos = featuredProducts.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryName = p.Category?.Name ?? string.Empty,
                    ImageUrls = p.Images?.Select(i => $"{Request.Scheme}://{Request.Host}{i.ImageUrl}").ToList() ?? new List<string>()
                });

                return Ok(ApiResponse<IEnumerable<ProductDto>>.SuccessResponse(dtos, "Lấy danh sách sản phẩm nổi bật thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi lấy sản phẩm nổi bật", new[] { ex.Message }, 500));
            }
        }


        // ================== DELETE ==================
        //[HttpDelete("{id}")]
        //[Authorize(Policy = PermissionConstants.Products.Delete)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var product = await _unitOfWork.ProductRepository
        //        .Query()
        //        .Include(p => p.Images)
        //        .FirstOrDefaultAsync(p => p.Id == id);

        //    if (product == null)
        //        return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

        //    // xóa file vật lý
        //    foreach (var img in product.Images)
        //    {
        //        var path = Path.Combine(_env.WebRootPath, img.ImageUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));
        //        if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
        //    }

        //    _unitOfWork.ProductRepository.Delete(product);
        //    await _unitOfWork.CompleteAsync();

        //    return Ok(ApiResponse<string>.SuccessResponse("Xóa sản phẩm thành công"));  

        //}
        // ================== DEACTIVATE PRODUCT ==================
        [HttpPut("{id}/deactivate")]
        [Authorize(Policy = PermissionConstants.Products.Update)]
        public async Task<IActionResult> DeactivateProduct(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

            if (!product.IsActive)
                return BadRequest(ApiResponse<string>.ErrorResponse("Sản phẩm đã ngừng hoạt động"));

            product.IsActive = false;
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<string>.SuccessResponse("Ngừng hoạt động sản phẩm thành công"));
        }

        // ================== ACTIVATE PRODUCT ==================
        [HttpPut("{id}/activate")]
        [Authorize(Policy = PermissionConstants.Products.Update)]
        public async Task<IActionResult> ActivateProduct(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

            if (product.IsActive)
                return BadRequest(ApiResponse<string>.ErrorResponse("Sản phẩm đã đang hoạt động"));

            product.IsActive = true;
            await _unitOfWork.CompleteAsync();

            return Ok(ApiResponse<string>.SuccessResponse("Kích hoạt sản phẩm thành công"));
        }
        // ================== GET ALL LOCKED PRODUCTS ==================
        [HttpGet("locked")]
        [Authorize(Policy = PermissionConstants.Products.View)]
        public async Task<IActionResult> GetLockedProducts(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var query = _unitOfWork.ProductRepository
                    .Query()
                    .Include(p => p.Category)
                    .Include(p => p.Images)
                    .Where(p => !p.IsActive); //  chỉ lấy product đang bị khóa

                var totalItems = await query.CountAsync();

                var items = await query
                    .OrderByDescending(p => p.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var itemDtos = items.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryName = p.Category?.Name ?? string.Empty,
                    ImageUrls = p.Images?.Select(i => $"{Request.Scheme}://{Request.Host}{i.ImageUrl}").ToList() ?? new List<string>()
                }).ToList();

                var result = new PagedResult<ProductDto>
                {
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Items = itemDtos
                };

                return Ok(ApiResponse<PagedResult<ProductDto>>.SuccessResponse(result, "Lấy danh sách sản phẩm bị khóa thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse("Lỗi khi lấy sản phẩm bị khóa", new[] { ex.Message }, 500));
            }
        }

    }


}
