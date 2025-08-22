using AutoMapper;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // Lấy tất cả sản phẩm (ai cũng xem được)
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        // Lấy chi tiết sản phẩm theo Id (ai cũng xem được)
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        // Tạo sản phẩm (chỉ Seller hoặc Admin)
        [HttpPost]
        [Authorize(Roles = "Seller,Admin")]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var product = _mapper.Map<Product>(productDto);
            product.SellerId = userId;
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        // Sửa sản phẩm (chỉ Seller sở hữu hoặc Admin)
        [HttpPut("{id}")]
        [Authorize(Roles = "Seller,Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userRoles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

            // Chỉ chủ sản phẩm hoặc Admin mới được sửa
            if (product.SellerId != userId && !userRoles.Contains("Admin"))
                return Forbid();

            _mapper.Map(productDto, product);
            await _unitOfWork.CompleteAsync();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        // Xóa sản phẩm (chỉ Seller sở hữu hoặc Admin)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Seller,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userRoles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

            // Chỉ chủ sản phẩm hoặc Admin mới được xóa
            if (product.SellerId != userId && !userRoles.Contains("Admin"))
                return Forbid();

            //await _unitOfWork.Products.DeleteAsync(product);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        // Lấy sản phẩm theo Seller (chỉ Seller hoặc Admin)
        [HttpGet("seller/{sellerId}")]
        [Authorize(Roles = "Seller,Admin")]
        public async Task<IActionResult> GetBySeller(int sellerId)
        {
            var products = await _unitOfWork.Products.GetBySellerIdAsync(sellerId);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }
    }
}
