namespace BE__Small_Shop_Management_System.Constants
{
    public static class PermissionConstants
    {
        // ===== USERS =====
        public static class Users
        {
            public const string View = "Users.View";
            public const string Create = "Users.Create";
            public const string Update = "Users.Update";
            public const string Delete = "Users.Delete";
            public const string Lock = "Users.Lock";
            public const string Unlock = "Users.Unlock";
            public const string ResetPassword = "Users.ResetPassword";
            public static readonly string Module = "Users";
        }

        // ===== ROLES =====
        public static class Roles
        {
            public const string View = "Roles.View";
            public const string Create = "Roles.Create";
            public const string Update = "Roles.Update";
            public const string Delete = "Roles.Delete";
            public static readonly string Module = "Roles";
        }

        // ===== PERMISSIONS =====
        public static class Permissions
        {
            public const string View = "Permissions.View";
            public const string Create = "Permissions.Create";
            public const string Update = "Permissions.Update";
            public const string Delete = "Permissions.Delete";
            public static readonly string Module = "Permissions";
        }

        // ===== PRODUCTS =====
        public static class Products
        {
            public const string View = "Products.View";
            public const string Create = "Products.Create";
            public const string Update = "Products.Update";
            public const string Delete = "Products.Delete";
            public const string Import = "Products.Import";
            public const string Export = "Products.Export";
            public static readonly string Module = "Products";
        }

        // ===== ORDERS =====
        public static class Orders
        {
            public const string View = "Orders.View";
            public const string Create = "Orders.Create";
            public const string Update = "Orders.Update";
            public const string Delete = "Orders.Delete";
            public const string Process = "Orders.Process";
            public const string Cancel = "Orders.Cancel";
            public static readonly string Module = "Orders";
        }

        // ===== INVENTORY =====
        public static class Inventory
        {
            public const string View = "Inventory.View";
            public const string Import = "Inventory.Import";
            public const string Export = "Inventory.Export";
            public const string Update = "Inventory.Update";
            public static readonly string Module = "Inventory";
        }

        // ===== REPORTS =====
        public static class Reports
        {
            public const string View = "Reports.View";
            public const string Generate = "Reports.Generate";
            public const string Export = "Reports.Export";
            public static readonly string Module = "Reports";
        }

        // ===== CATEGORIES =====
        public static class Categories
        {
            public const string View = "Categories.View";
            public const string Create = "Categories.Create";
            public const string Update = "Categories.Update";
            public const string Delete = "Categories.Delete";
            public static readonly string Module = "Categories";
        }

        // ===== SYSTEM LOGS =====
        public static class SystemLogs
        {
            public const string View = "SystemLogs.View";
            public const string Delete = "SystemLogs.Delete";
            public static readonly string Module = "SystemLogs";
        }

        // ===== DASHBOARD =====
        public static class Dashboard
        {
            public const string View = "Dashboard.View";
            public const string Analyze = "Dashboard.Analyze";
            public static readonly string Module = "Dashboard";
        }

        // ===== PASSWORD POLICY =====
        public static class PasswordPolicy
        {
            public const string View = "PasswordPolicy.View";
            public const string Update = "PasswordPolicy.Update";
            public static readonly string Module = "PasswordPolicy";
        }

        // ===== CART =====
        public static class Cart
        {
            public const string View = "Cart.View";
            public const string Add = "Cart.Add";
            public const string Update = "Cart.Update";
            public const string Delete = "Cart.Delete";
            public static readonly string Module = "Cart";
        }

        // ===== FAVORITES =====
        public static class Favorites
        {
            public const string View = "Favorites.View";
            public const string Add = "Favorites.Add";
            public const string Delete = "Favorites.Delete";
            public static readonly string Module = "Favorites";
        }

        // ===== ORDER ITEMS =====
        public static class OrderItems
        {
            public const string View = "OrderItems.View";
            public static readonly string Module = "OrderItems";
        }

        // ===== INVENTORY HISTORY =====
        public static class InventoryHistory
        {
            public const string View = "InventoryHistory.View";
            public const string Import = "InventoryHistory.Import";
            public const string Export = "InventoryHistory.Export";
            public static readonly string Module = "InventoryHistory";
        }

        // ===== Utility: Lấy toàn bộ quyền =====
        public static IEnumerable<string> All()
        {
            var type = typeof(PermissionConstants);
            foreach (var nested in type.GetNestedTypes())
            {
                foreach (var field in nested.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
                {
                    if (field.FieldType == typeof(string) && field.Name != "Module")
                        yield return (string)field.GetValue(null)!;
                }
            }
        }
    }
}
