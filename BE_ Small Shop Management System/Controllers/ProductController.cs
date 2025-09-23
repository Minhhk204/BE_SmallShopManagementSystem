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
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync();
                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
                return Ok(ApiResponse<IEnumerable<ProductDto>>.SuccessResponse(productDtos, "Lấy danh sách sản phẩm thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse($"Lỗi: {ex.Message}"));
            }
        }

        // Lấy chi tiết sản phẩm
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionConstants.Products.View)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                if (product == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

                var productDto = _mapper.Map<ProductDto>(product);
                return Ok(ApiResponse<ProductDto>.SuccessResponse(productDto, "Lấy chi tiết sản phẩm thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse($"Lỗi: {ex.Message}"));
            }
        }

        // Tìm kiếm + phân trang
        [HttpGet("search")]
        [Authorize(Policy = PermissionConstants.Products.View)]
        public async Task<IActionResult> Search([FromQuery] ProductFilterRequest filter)
        {
            try
            {
                var query = _unitOfWork.ProductRepository.Query();

                if (!string.IsNullOrWhiteSpace(filter.Keyword))
                    query = query.Where(p => p.Name.Contains(filter.Keyword) ||
                                             (p.Description != null && p.Description.Contains(filter.Keyword)));

                if (filter.MinPrice.HasValue)
                    query = query.Where(p => p.Price >= filter.MinPrice.Value);

                if (filter.MaxPrice.HasValue)
                    query = query.Where(p => p.Price <= filter.MaxPrice.Value);

                var totalItems = await query.CountAsync();

                var products = await query
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync();

                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

                var result = new PagedResult<ProductDto>
                {
                    Items = productDtos,
                    TotalItems = totalItems,
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize
                };

                return Ok(ApiResponse<PagedResult<ProductDto>>.SuccessResponse(result, "Lấy danh sách sản phẩm thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.ErrorResponse($"Lỗi server: {ex.Message}"));
            }
        }

        // Tạo sản phẩm
        [HttpPost]
        [Authorize(Policy = PermissionConstants.Products.Create)]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponse<string>.ErrorResponse("Dữ liệu không hợp lệ"));

                var product = _mapper.Map<Product>(productDto);

                await _unitOfWork.ProductRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<ProductDto>.SuccessResponse(_mapper.Map<ProductDto>(product), "Tạo sản phẩm thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse($"Lỗi: {ex.Message}"));
            }
        }

        // Sửa sản phẩm
        [HttpPut("{id}")]
        [Authorize(Policy = PermissionConstants.Products.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                if (product == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

                _mapper.Map(productDto, product);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<ProductDto>.SuccessResponse(_mapper.Map<ProductDto>(product), "Cập nhật sản phẩm thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse($"Lỗi: {ex.Message}"));
            }
        }

        // Xóa sản phẩm
        [HttpDelete("{id}")]
        [Authorize(Policy = PermissionConstants.Products.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                if (product == null)
                    return NotFound(ApiResponse<string>.ErrorResponse("Không tìm thấy sản phẩm"));

                _unitOfWork.ProductRepository.Delete(product);
                await _unitOfWork.CompleteAsync();

                return Ok(ApiResponse<string>.SuccessResponse("Xóa sản phẩm thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.ErrorResponse($"Lỗi: {ex.Message}"));
            }
        }
    }
}
