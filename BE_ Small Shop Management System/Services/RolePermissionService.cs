using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.UnitOfWork;

namespace BE__Small_Shop_Management_System.Services
{
    public class RolePermissionService
    {
        private readonly IUnitOfWork _uow;
        public RolePermissionService(IUnitOfWork uow) { _uow = uow; }

        public async Task<List<PermissionResponseDto>> GetPermissionMapAsync(int roleId)
        {
            var all = (await _uow.PermissionRepository.GetAllPermissionsAsync()).ToList();
            var rolePerms = await _uow.RolePermissionRepository.GetPermissionsByRoleIdAsync(roleId);
            var roleIds = rolePerms.Select(p => p.Id).ToHashSet();

            return all.Select(p => new PermissionResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Module = p.Module,
                Description = p.Description ?? "",
                Granted = roleIds.Contains(p.Id)
            }).OrderBy(x => x.Module).ThenBy(x => x.Name).ToList();
        }

        public async Task<List<PermissionResponseDto>> AssignAsync(int roleId, IEnumerable<int> permissionIds)
        {
            await _uow.RolePermissionRepository.AssignAsync(roleId, permissionIds);
            await _uow.CompleteAsync();
            return await GetPermissionMapAsync(roleId);
        }
    }

}
