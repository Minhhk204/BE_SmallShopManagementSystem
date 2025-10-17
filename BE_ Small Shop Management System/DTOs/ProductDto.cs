namespace BE__Small_Shop_Management_System.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public string? CategoryName { get; set; }
        public bool IsActive { get; set; } = true;
        public string Image { get; set; } 
        public List<string> ImageUrls { get; set; } = new();
    }

    // Tạo / cập nhật product
    public class ProductCreateUpdateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public string? CategoryName { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public bool IsFeatured { get; set; } = false;


        // upload nhiều file
        public List<IFormFile>? Files { get; set; }

        // khi update → cho phép client gửi danh sách id ảnh cần xóa
        public List<int>? DeletedImageIds { get; set; }
    }
}
