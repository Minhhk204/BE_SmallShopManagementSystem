using System.Reflection;

namespace BE__Small_Shop_Management_System.Middleware
{
    public static class DependencyInjectionMiddleware
    {
        public static IServiceCollection AddRepositoriesAndServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Đăng ký tất cả Repository (interface bắt đầu bằng "I" và kết thúc bằng "Repository")
            var repoTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"));

            foreach (var implType in repoTypes)
            {
                var interfaceType = implType.GetInterfaces()
                    .FirstOrDefault(i => i.Name == "I" + implType.Name);

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, implType);
                }
            }

            // Đăng ký tất cả Service (class kết thúc bằng "Service")
            var serviceTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"));

            foreach (var implType in serviceTypes)
            {
                services.AddScoped(implType);
            }

            return services;
        }
    }
}
