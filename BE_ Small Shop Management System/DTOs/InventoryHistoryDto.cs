using System;

namespace BE__Small_Shop_Management_System.DTOs
{
    public class InventoryHistoryDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityChanged { get; set; }
        public string Action { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        // Thông tin sản phẩm liên quan
        public ProductDto? Product { get; set; }
    }
}
