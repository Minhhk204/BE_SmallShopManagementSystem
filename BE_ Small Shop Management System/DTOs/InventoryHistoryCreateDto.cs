namespace BE__Small_Shop_Management_System.DTOs
{
    public class InventoryHistoryCreateDto
    {
        // Nếu ProductId > 0 → update stock
        // Nếu ProductId = 0 → thêm sản phẩm mới theo thông tin dưới
        public int ProductId { get; set; }

        // Dữ liệu sản phẩm mới (nếu cần)
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int CategoryId { get; set; }

        // Số lượng nhập
        public int QuantityChanged { get; set; }

        // Hành động: "Import", "Adjust"...
        public string Action { get; set; } = "Import";
    }
}
