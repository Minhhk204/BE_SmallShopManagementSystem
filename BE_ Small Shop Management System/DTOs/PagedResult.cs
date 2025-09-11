namespace BE__Small_Shop_Management_System.DTOs
{
    
        public class PagedResult<T>
        {
            public int TotalItems { get; set; }
            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public IEnumerable<T> Items { get; set; } = new List<T>();
        }

    
}
