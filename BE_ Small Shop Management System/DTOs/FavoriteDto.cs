namespace BE__Small_Shop_Management_System.DTOs
{
    public class FavoriteDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
