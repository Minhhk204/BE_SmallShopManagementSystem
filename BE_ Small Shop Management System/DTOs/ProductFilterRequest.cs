namespace BE__Small_Shop_Management_System.DTOs
{
    public class ProductFilterRequest
    {
        public string? Keyword { get; set; } // tìm theo tên/ mô tả
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? SellerId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
