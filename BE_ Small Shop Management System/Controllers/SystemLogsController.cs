using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Repositories;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
                UserName = l.User?.Username,
                Method = l.Method,
                Path = l.Path,
                StatusCode = l.StatusCode,
                Action = l.Action,
                CreatedAt = l.CreatedAt,
                Duration = l.Duration,
                ApplicationName = l.ApplicationName,
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
                UserName = log.User?.Username,
                Method = log.Method,
                Path = log.Path,
                StatusCode = log.StatusCode,
                Action = log.Action,
                CreatedAt = log.CreatedAt,
                Duration = log.Duration,
                ApplicationName = log.ApplicationName,
                Data = log.Data
            };

            return Ok(dto);
        }

        [HttpGet("paged")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPaged([FromQuery] SystemLogFilterRequest filter,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = _unitOfWork.SystemLogRepository.Query();

            //Lọc UserName
            if (!string.IsNullOrEmpty(filter.UserName))
                query = query.Where(l => l.User != null && l.User.Username.Contains(filter.UserName));

            //Lọc Action
            if (!string.IsNullOrEmpty(filter.Action))
                query = query.Where(l => l.Action.Contains(filter.Action));

            //Lọc Method
            if (!string.IsNullOrEmpty(filter.Method))
                query = query.Where(l => l.Method == filter.Method);

            //Lọc StatusCode
            if (filter.StatusCode.HasValue)
                query = query.Where(l => l.StatusCode == filter.StatusCode.Value);
            //Lọc khoảng thời gian
            if (filter.FromDate.HasValue)
                query = query.Where(l => l.CreatedAt >= filter.FromDate.Value);

            if (filter.ToDate.HasValue)
                query = query.Where(l => l.CreatedAt <= filter.ToDate.Value);

            //Lọc Duration
            if (filter.MinDuration.HasValue)
                query = query.Where(l => l.Duration >= filter.MinDuration.Value);

            if (filter.MaxDuration.HasValue)
                query = query.Where(l => l.Duration <= filter.MaxDuration.Value);

            var totalCount = await query.CountAsync();

            var logs = await query
                .OrderByDescending(l => l.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = new PagedResult<SystemLogDto>
            {
                Items = logs.Select(l => new SystemLogDto
                {
                    Id = l.Id,
                    UserName = l.User?.Username,
                    Method = l.Method,
                    Path = l.Path,
                    StatusCode = l.StatusCode,
                    Action = l.Action,
                    CreatedAt = l.CreatedAt,
                    Duration = l.Duration,
                    ApplicationName = l.ApplicationName,
                    Data = l.Data
                }),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(result);
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
