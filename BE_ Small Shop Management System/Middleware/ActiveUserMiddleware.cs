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
            if (context.User.Identity is { IsAuthenticated: true })
            {
                var userIdClaim = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(userIdClaim) && int.TryParse(userIdClaim, out var userId))
                {
                    var user = await db.Users.FindAsync(userId);

                    if (user == null)
                    {
                        //User không tồn tại → 401
                        await LogSystem(db, userId, null, context, "Unauthorized - User not found", StatusCodes.Status401Unauthorized);

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Người dùng không tồn tại.");
                        return;
                    }

                    if (!user.IsActive)
                    {
                        //User bị khóa → 403
                        await LogSystem(db, user.Id, user.Username, context, "Forbidden - User is deactivated", StatusCodes.Status403Forbidden);

                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        await context.Response.WriteAsync("Tài khoản đã bị khóa, vui lòng liên hệ Admin.");
                        return;
                    }
                }
            }

            await _next(context);
        }


        private async Task LogSystem(AppDbContext db, int? userId, string? userName, HttpContext context, string reason, int statusCode)
        {
            var log = new SystemLog
            {
                UserId = userId,
                UserName = userName,

                Method = context.Request.Method,
                Path = context.Request.Path,
                StatusCode = statusCode,
                Action = $"{context.Request.Method} {context.Request.Path} ({statusCode})", // vẫn giữ chuỗi gọn để search nhanh

                Data = $"IP: {context.Connection.RemoteIpAddress}\nReason: {reason}",
                CreatedAt = DateTime.UtcNow,
                ApplicationName = "Small Shop System"
            };

            db.SystemLogs.Add(log);
            await db.SaveChangesAsync();
        }

    }

}
