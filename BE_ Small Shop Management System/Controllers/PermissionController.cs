using AutoMapper;
using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Repositories;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermissionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Lấy toàn bộ permissions trong hệ thống
        /// </summary>
        [HttpGet]
        [Authorize(Policy = PermissionConstants.Permissions.View)]
        public async Task<IActionResult> GetAll()
        {
            var permissions = await _unitOfWork.PermissionRepository.GetAllPermissionsAsync();
            var result = permissions.Select(p => new PermissionDto
            {
                Id = p.Id,
                Name = p.Name,
                Module = p.Module,
                Description = p.Description ?? string.Empty
            });
            return Ok(result);
        }

        /// <summary>
        /// Lấy chi tiết permission theo id
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionConstants.Permissions.View)]
        public async Task<IActionResult> GetById(int id)
        {
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(id);
            if (permission == null) return NotFound();

            return Ok(new PermissionDto
            {
                Id = permission.Id,
                Name = permission.Name,
                Module = permission.Module,
                Description = permission.Description ?? string.Empty
            });
        }

        /// <summary>
        /// Tạo permission mới
        /// </summary>
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] PermissionDto dto)
        //{
        //    var permission = new Permission
        //    {
        //        Name = dto.Name,
        //        Module = dto.Module,
        //        Description = dto.Description
        //    };

        //    await _unitOfWork.PermissionRepository.AddAsync(permission);
        //    await _unitOfWork.CompleteAsync();

        //    dto.Id = permission.Id;
        //    return CreatedAtAction(nameof(GetById), new { id = permission.Id }, dto);
        //}

        /// <summary>
        /// Cập nhật permission
        /// </summary>
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] PermissionDto dto)
        //{
        //    var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(id);
        //    if (permission == null) return NotFound();

        //    permission.Name = dto.Name;
        //    permission.Module = dto.Module;
        //    permission.Description = dto.Description;

        //    _unitOfWork.PermissionRepository.Update(permission);
        //    await _unitOfWork.CompleteAsync();

        //    return Ok(dto);
        //}

        /// <summary>
        /// Xóa permission
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Policy = PermissionConstants.Permissions.Delete)] 
        public async Task<IActionResult> Delete(int id)
        {
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(id);
            if (permission == null) return NotFound();

            _unitOfWork.PermissionRepository.Delete(permission);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
