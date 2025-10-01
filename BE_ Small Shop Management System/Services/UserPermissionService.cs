using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.UnitOfWork;

namespace BE__Small_Shop_Management_System.Services
{
    public class UserPermissionService
    {
        private readonly IUnitOfWork _uow;
        public UserPermissionService(IUnitOfWork uow) { _uow = uow; }

        // includeRolePermissions: true => tick cả quyền có được từ Role
        public async Task<List<PermissionResponseDto>> GetPermissionMapAsync(int userId, bool includeRolePermissions = true)
        {
            var all = (await _uow.PermissionRepository.GetAllPermissionsAsync()).ToList();

            // trực tiếp
            var direct = await _uow.UserPermissionRepository.GetPermissionsByUserIdAsync(userId);
            var directIds = direct.Select(p => p.Id).ToHashSet();

            HashSet<int> effectiveIds = new(directIds);

            if (includeRolePermissions)
            {
                // lấy role của user -> quyền từ role
                var roles = await _uow.UserRepository.GetRolesAsync(userId);
                var roleIds = roles.Select(r => r.Id).ToList();

                var rolePerms = new List<Permission>();
                foreach (var rid in roleIds)
                    rolePerms.AddRange(await _uow.RolePermissionRepository.GetPermissionsByRoleIdAsync(rid));

                foreach (var p in rolePerms)
                    effectiveIds.Add(p.Id);
            }

            return all.Select(p => new PermissionResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Module = p.Module,
                Description = p.Description ?? "",
                Granted = effectiveIds.Contains(p.Id)
            }).OrderBy(x => x.Module).ThenBy(x => x.Name).ToList();
        }

        // Gán quyền trực tiếp cho user (replace all)
        public async Task<List<PermissionResponseDto>> AssignAsync(int userId, IEnumerable<int> permissionIds)
        {
            await _uow.UserPermissionRepository.AssignAsync(userId, permissionIds);
            await _uow.CompleteAsync();
            return await GetPermissionMapAsync(userId, includeRolePermissions: true);
        }
    }

}
