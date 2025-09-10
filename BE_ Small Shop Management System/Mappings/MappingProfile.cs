using AutoMapper;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BE__Small_Shop_Management_System.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
               
            CreateMap<User, UserDto>()  // User mapping
           .ForMember(dest => dest.RoleName,
               opt => opt.MapFrom(src =>
                src.UserRoles != null && src.UserRoles.Any()
                ? string.Join(", ", src.UserRoles.Select(ur => ur.Role.Name))
                : ""
                 ))
               .ReverseMap(); // Entity → DTO

            CreateMap<UserRegisterDto, User>();   // Register DTO → Entity
            CreateMap<UserLoginDto, User>();      // Login DTO → Entity

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<SystemLog, SystemLogDto>().ReverseMap();

            // Product mapping
            CreateMap<Product, ProductDto>().ReverseMap();

            // Order mapping
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
