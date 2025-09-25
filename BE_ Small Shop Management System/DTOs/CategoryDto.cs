using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
    }
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

}
