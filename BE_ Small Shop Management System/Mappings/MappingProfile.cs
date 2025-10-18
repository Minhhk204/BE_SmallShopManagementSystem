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
                ? src.UserRoles.Select(ur => ur.Role.Name).ToList()
                : new List<string>()
                 ))
           .ReverseMap(); // Entity → DTO
                 // Product mapping
            CreateMap<Product, ProductDto>()
                 .ForMember(dest => dest.CategoryName,
                            opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
                 .ForMember(dest => dest.ImageUrls,
                            opt => opt.MapFrom(src => src.Images.Select(i => i.ImageUrl).ToList()));

            CreateMap<ProductCreateUpdateDto, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore());

            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore()); 

            CreateMap<UserRegisterDto, User>();  
            CreateMap<UserLoginDto, User>();   

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<SystemLog, SystemLogDto>().ReverseMap();




           
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));

           
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src =>
                    src.Product.Images != null && src.Product.Images.Any()
                        ? src.Product.Images.First().ImageUrl
                        : null));



            CreateMap<Category, CategoryDto>();
            CreateMap<CartItem, CartItemDto>();
            CreateMap<Favorite, FavoriteDto>();
        }
    }
}
