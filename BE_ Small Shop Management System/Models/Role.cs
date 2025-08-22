namespace BE__Small_Shop_Management_System.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;  // Admin, Seller, Customer
        public string? Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
