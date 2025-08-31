using Microsoft.AspNetCore.Authorization;

namespace BE__Small_Shop_Management_System.Middleware
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission) => Policy = permission;
    }
}
