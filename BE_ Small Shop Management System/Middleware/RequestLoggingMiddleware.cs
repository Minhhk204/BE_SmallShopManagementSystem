using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using System.Security.Claims;
using System.Text;

namespace BE__Small_Shop_Management_System.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            // Lấy thông tin cơ bản
            var ip = context.Connection.RemoteIpAddress?.ToString();
            var method = context.Request.Method;
            var path = context.Request.Path;
            var userId = GetUserIdFromToken(context);

            // Đọc request body (copy để không ảnh hưởng pipeline)
            context.Request.EnableBuffering();
            string body = "";
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                body = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }

            // Gọi middleware tiếp theo
            await _next(context);

            // Response status
            var statusCode = context.Response.StatusCode;

            // Lưu vào DB (SystemLog)
            var log = new SystemLog
            {
                UserId = userId,
                Action = $"{method} {path} ({statusCode})",
                Data = $"IP: {ip}\nBody: {body}",
                CreatedAt = DateTime.UtcNow
            };

            db.SystemLogs.Add(log);
            await db.SaveChangesAsync();
        }

        private int? GetUserIdFromToken(HttpContext context)
        {
            if (context.User.Identity is { IsAuthenticated: true })
            {
                var idClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
                if (idClaim != null && int.TryParse(idClaim.Value, out int userId))
                {
                    return userId;
                }
            }
            return null;
        }
    }

}

