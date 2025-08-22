using BE__Small_Shop_Management_System.DataContext;
using System.Security.Claims;

namespace BE__Small_Shop_Management_System.Middleware
{
    public class ActiveUserMiddleware
    {
        private readonly RequestDelegate _next;

        public ActiveUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            // Chỉ check nếu user đã login (có JWT token)
            if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
            {
                var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(userId))
                {
                    var user = await db.Users.FindAsync(int.Parse(userId));
                    if (user != null && !user.IsActive)
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        await context.Response.WriteAsync("Tài khoản đã bị khóa, vui lòng liên hệ Admin.");
                        return; // dừng ở đây, không cho request tiếp
                    }
                }
            }

            // Nếu active thì cho đi tiếp
            await _next(context);
        }
    }
}
