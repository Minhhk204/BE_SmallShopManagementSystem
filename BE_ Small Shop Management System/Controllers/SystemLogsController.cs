using BE__Small_Shop_Management_System.Constants;
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


        //[HttpGet("{id}")]
        //[Authorize(Policy = PermissionConstants.SystemLogs.View)]
        //public async Task<ActionResult<SystemLogDto>> GetById(int id)
        //{
        //    var log = await _unitOfWork.SystemLogRepository.GetByIdAsync(id);
        //    if (log == null)
        //        return NotFound();

        //    var dto = new SystemLogDto
        //    {
        //        Id = log.Id,
        //        UserName = log.User?.Username,
        //        Method = log.Method,
        //        Path = log.Path,
        //        StatusCode = log.StatusCode,
        //        Action = log.Action,
        //        CreatedAt = log.CreatedAt,
        //        Duration = log.Duration,
        //        ApplicationName = log.ApplicationName,
        //        Data = log.Data
        //    };

        //    return Ok(dto);
        //}

        [HttpGet("paged")]
        [Authorize(Policy = PermissionConstants.SystemLogs.View)]
        public async Task<IActionResult> GetPaged(
         [FromQuery] SystemLogFilterRequest filter,
         [FromQuery] int pageNumber = 1,
         [FromQuery] int pageSize = 10)
        {
            
            var query = _unitOfWork.SystemLogRepository.Query().AsNoTracking();

            
            if (!string.IsNullOrEmpty(filter.UserName))
                query = query.Where(l => l.UserName != null && l.UserName.Contains(filter.UserName));

          
            if (!string.IsNullOrEmpty(filter.Method))
                query = query.Where(l => l.Method == filter.Method);

           
            if (filter.StatusCode.HasValue)
                query = query.Where(l => l.StatusCode == filter.StatusCode.Value);

          
            if (filter.FromDate.HasValue)
                query = query.Where(l => l.CreatedAt >= filter.FromDate.Value);

            if (filter.ToDate.HasValue)
                query = query.Where(l => l.CreatedAt <= filter.ToDate.Value);

           
            if (filter.MinDuration.HasValue)
                query = query.Where(l => l.Duration >= filter.MinDuration.Value);

            if (filter.MaxDuration.HasValue)
                query = query.Where(l => l.Duration <= filter.MaxDuration.Value);

            
            var totalCount = await query.CountAsync();


            var logs = await query
            .OrderByDescending(l => l.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(l => new SystemLogDto
            {
                Id = l.Id,
                UserName = l.UserName,
                Method = l.Method,
                Path = l.Path,
                StatusCode = l.StatusCode,
                CreatedAt = l.CreatedAt,
                Duration = l.Duration,
                ApplicationName = l.ApplicationName,
                Data = l.Data,
            })
            .ToListAsync();



            var result = new PagedResult<SystemLogDto>
            {
                Items = logs,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(result);
        }




    }
}
