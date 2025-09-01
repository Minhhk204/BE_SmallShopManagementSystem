using BE__Small_Shop_Management_System.Constants;
using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.Mappings;
using BE__Small_Shop_Management_System.Middleware;
using BE__Small_Shop_Management_System.Repositories;
using BE__Small_Shop_Management_System.Services;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BE__Small_Shop_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Web API", Version = "v1" });

                // Định nghĩa cấu hình bảo mật cho Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                // Áp dụng cấu hình bảo mật cho tất cả các API
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });


            // Đăng ký DbContext với DI, lấy connection string từ appsettings.json
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // JWT configuration
            var jwtSettings = builder.Configuration.GetSection("Jwt");
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
                };
            });


            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IUnitOfWork, BE__Small_Shop_Management_System.UnitOfWork.UnitOfWork>();
            builder.Services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
            builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            builder.Services.AddScoped<ISystemLogRepository, SystemLogRepository>();

            // Services
            builder.Services.AddScoped<RolePermissionService>();
            builder.Services.AddScoped<UserPermissionService>();
            builder.Services.AddScoped<JwtService>();

            builder.Services.AddAuthorization(options =>
            {
                foreach (var perm in PermissionConstants.All())
                {
                    // mỗi policy yêu cầu claim "permission" tương ứng
                    options.AddPolicy(perm, policy => policy.RequireClaim("permission", perm));
                }
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularClient", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // Angular dev server
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddSwaggerGen();
            var app = builder.Build();

           

            // Middleware log request/response
            app.UseRequestLogging();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Bật CORS trước khi MapControllers
            app.UseCors("AllowAngularClient");
            app.UseAuthentication();
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseMiddleware<ActiveUserMiddleware>(); // check IsActive

            app.UseAuthorization();

           
            app.MapControllers();

            app.Run();
        }
    }
}
