using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using BE__Small_Shop_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Chỉ Admin mới lấy được danh sách user
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return Ok(users);
        }

        // Chỉ Admin mới tạo user
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return Ok(user);
        }

        // Lấy thông tin cá nhân (user tự xem)
        [HttpGet("Customer")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var user = await _unitOfWork.Users.GetByIdAsync(int.Parse(userId));
            if (user == null) return NotFound();
            return Ok(user);
        }

        // Lấy user theo username (Admin hoặc Seller)
        [HttpGet("{username}")]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(username);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
