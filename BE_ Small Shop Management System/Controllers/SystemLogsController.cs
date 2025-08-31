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
    public class SystemLogsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemLogsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<SystemLogDto>>> GetAll()
        {
            var logs = await _unitOfWork.SystemLogRepository.GetAllAsync();

            var result = logs.Select(l => new SystemLogDto
            {
                Id = l.Id,
                UserId = l.UserId,
                UserName = l.User?.Username,
                Action = l.Action,
                CreatedAt = l.CreatedAt,
                Data = l.Data
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<SystemLogDto>> GetById(int id)
        {
            var log = await _unitOfWork.SystemLogRepository.GetByIdAsync(id);
            if (log == null)
                return NotFound();

            var dto = new SystemLogDto
            {
                Id = log.Id,
                UserId = log.UserId,
                UserName = log.User?.Username,
                Action = log.Action,
                CreatedAt = log.CreatedAt,
                Data = log.Data
            };

            return Ok(dto);
        }
    }
}
