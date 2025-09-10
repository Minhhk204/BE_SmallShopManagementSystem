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
        [HttpDelete("xóa 1 hoặc nhiều theo id")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRange([FromBody] List<int> ids)
        {
            var logs = await _unitOfWork.SystemLogRepository.FindAsync(l => ids.Contains(l.Id));
            if (!logs.Any())
                return NotFound("Không tìm thấy log nào để xóa");

            _unitOfWork.SystemLogRepository.DeleteRange(logs);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = $"Đã xóa {logs.Count()} log" });
        }



        [HttpDelete("clear-all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ClearAll()
        {
            var logs = await _unitOfWork.SystemLogRepository.GetAllAsync();
            _unitOfWork.SystemLogRepository.DeleteRange(logs);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Đã xóa toàn bộ logs" });
        }


        [HttpDelete("clear-old")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ClearOldLogs([FromQuery] int days = 30)
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-days);

            var oldLogs = await _unitOfWork.SystemLogRepository.FindAsync(l => l.CreatedAt < cutoffDate);
            if (!oldLogs.Any())
                return NotFound($"Không có log nào cũ hơn {days} ngày để xóa");

            _unitOfWork.SystemLogRepository.DeleteRange(oldLogs);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = $"Đã xóa {oldLogs.Count()} log cũ hơn {days} ngày" });
        }

    }
}
