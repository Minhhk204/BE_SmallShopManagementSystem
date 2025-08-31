namespace BE__Small_Shop_Management_System.Constants
{
    public static class PermissionConstants
    {
        public static class Users
        {
            public const string View = "Users.View";
            public const string Create = "Users.Create";
            public const string Update = "Users.Update";
            //public const string Delete = "Users.Delete";
            public const string Lock = "Users.Lock";
            public const string Unlock = "Users.Unlock";
            public static readonly string Module = "Users";
        }

        public static class Roles
        {
            public const string View = "Roles.View";
            public const string Create = "Roles.Create";
            public const string Update = "Roles.Update";
            public const string Delete = "Roles.Delete";
           
            public static readonly string Module = "Roles";
        }

        public static class Permissions
        {
            public const string View = "Permissions.View";
            public const string Delete = "Permissions.Delete";
            public static readonly string Module = "Permissions";
        }

        public static class Products
        {
            public const string View = "Products.View";
            public const string Create = "Products.Create";
            public const string Update = "Products.Update";
            public const string Delete = "Products.Delete";
            public static readonly string Module = "Products";
        }

        public static class Orders
        {
            public const string View = "Orders.View";
            public const string Create = "Orders.Create";
            public const string Update = "Orders.Update";
            public const string Delete = "Orders.Delete";
            public const string Process = "Orders.Process";
            public static readonly string Module = "Orders";
        }

        public static class Inventory
        {
            public const string View = "Inventory.View";
            public const string Import = "Inventory.Import";
            public static readonly string Module = "Inventory";
        }

        public static class Reports
        {
            public const string ViewDashboard = "Reports.ViewDashboard";
            public static readonly string Module = "Reports";
        }

        // Lấy toàn bộ permission key (tự đăng ký policy/seed DB)
        public static IEnumerable<string> All()
        {
            var t = typeof(PermissionConstants);
            foreach (var nested in t.GetNestedTypes())
            {
                foreach (var f in nested.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
                {
                    if (f.FieldType == typeof(string) && f.Name != "Module")
                        yield return (string)f.GetValue(null)!;
                }
            }
        }
    }

}
