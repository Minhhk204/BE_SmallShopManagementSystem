using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Models;
using System.IdentityModel.Tokens.Jwt;
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
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault()
                     ?? context.Connection.RemoteIpAddress?.ToString();

            var method = context.Request.Method;
            var path = context.Request.Path + context.Request.QueryString;
            var (userId, userName) = GetUserInfoFromContext(context);

            context.Request.EnableBuffering();
            string body = "";
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                body = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }

            var headers = string.Join("\n", context.Request.Headers.Select(h => $"{h.Key}: {h.Value}"));

            await _next(context);

            stopwatch.Stop();
            var statusCode = context.Response.StatusCode;

            var log = new SystemLog
            {
                UserId = userId,
                UserName = userName,
                User = userId.HasValue ? await db.Users.FindAsync(userId) : null,
                Action = $"{method} {path} ({statusCode})",
                Data = $"IP: {ip}\nHeaders:\n{headers}\nBody: {body}",
                CreatedAt = DateTime.UtcNow,
                Duration = (int)stopwatch.ElapsedMilliseconds, // thời gian thực thi
                ApplicationName = "Small Shop System"
            };

            db.SystemLogs.Add(log);
            await db.SaveChangesAsync();
        }


        private (int? userId, string? userName) GetUserInfoFromContext(HttpContext context)
        {
            // Nếu đã authenticate => lấy từ Claims
            if (context.User.Identity is { IsAuthenticated: true })
            {
                var idClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
                var nameClaim = context.User.FindFirst(ClaimTypes.Name);

                int? userId = null;
                if (idClaim != null && int.TryParse(idClaim.Value, out int parsedId))
                    userId = parsedId;

                return (userId, nameClaim?.Value);
            }

            // Nếu chưa có => thử lấy trực tiếp từ JWT
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var idClaim = jwtToken.Claims.FirstOrDefault(c =>
                    c.Type == ClaimTypes.NameIdentifier || c.Type == "sub" || c.Type == "id");

                var nameClaim = jwtToken.Claims.FirstOrDefault(c =>
                    c.Type == ClaimTypes.Name || c.Type == "username" || c.Type == "unique_name");

                int? userId = null;
                if (idClaim != null && int.TryParse(idClaim.Value, out int parsedId))
                    userId = parsedId;

                return (userId, nameClaim?.Value);
            }

            return (null, null);
        }
    }


}

