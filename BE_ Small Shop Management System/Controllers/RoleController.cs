using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE__Small_Shop_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            var roles = await _unitOfWork.Roles.GetAllAsync();
            var roleDtos = roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();

            return Ok(roleDtos);
        }

        // GET: api/role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRole(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            return Ok(new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            });
        }

        // POST: api/role
        [HttpPost]
        public async Task<ActionResult<RoleDto>> CreateRole([FromBody] RoleDto roleDto)
        {
            var role = new Role
            {
                Name = roleDto.Name,
                Description = roleDto.Description
            };

            await _unitOfWork.Roles.AddAsync(role);
            await _unitOfWork.CompleteAsync();

            roleDto.Id = role.Id;

            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, roleDto);
        }

        // PUT: api/role/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleDto roleDto)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            role.Name = roleDto.Name;
            role.Description = roleDto.Description;

            _unitOfWork.Roles.Update(role);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        // DELETE: api/role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            _unitOfWork.Roles.Delete(role);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
