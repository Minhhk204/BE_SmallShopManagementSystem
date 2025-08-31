using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
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
            if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
            {
                var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out var id))
                {
                    var user = await db.Users.FindAsync(id);

                    if (user == null)
                    {
                        // User không tồn tại → 401
                        await LogSystem(db, id, null, context, "Unauthorized - User not found");
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Người dùng không tồn tại.");
                        return;
                    }

                    if (!user.IsActive)
                    {
                        // User bị khóa → 403
                        await LogSystem(db, id, user.Username, context, "Forbidden - User is deactivated");
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        await context.Response.WriteAsync("Tài khoản đã bị khóa, vui lòng liên hệ Admin.");
                        return;
                    }
                }
            }

            await _next(context);
        }

        private async Task LogSystem(AppDbContext db, int? userId, string? userName, HttpContext context, string reason)
        {
            var log = new SystemLog
            {
                UserId = userId,
                UserName = userName,
                Action = $"{context.Request.Method} {context.Request.Path} ({context.Response?.StatusCode})",
                Data = $"IP: {context.Connection.RemoteIpAddress}\nReason: {reason}",
                CreatedAt = DateTime.UtcNow
            };

            db.SystemLogs.Add(log);
            await db.SaveChangesAsync();
        }
    }

}
