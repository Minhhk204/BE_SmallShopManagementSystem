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
            // User mapping
            CreateMap<User, UserDto>();           // Entity → DTO
            CreateMap<UserRegisterDto, User>();   // Register DTO → Entity
            CreateMap<UserLoginDto, User>();      // Login DTO → Entity

            // Product mapping
            CreateMap<Product, ProductDto>();

            // Order mapping
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
