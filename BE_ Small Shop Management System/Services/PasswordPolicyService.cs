using BE__Small_Shop_Management_System.Models;

namespace BE__Small_Shop_Management_System.Services
{
    public class PasswordPolicyService
    {
        private PasswordPolicy _policy;

        public PasswordPolicyService()
        {
            _policy = new PasswordPolicy(); // mặc định
        }

        public PasswordPolicy GetPolicy()
        {
            return _policy;
        }

        public void UpdatePolicy(PasswordPolicy newPolicy)
        {
            _policy = newPolicy;
        }

        public bool ValidatePassword(string password, out List<string> errors)
        {
            errors = new List<string>();

            if (password.Length < _policy.RequiredLength)
                errors.Add($"Mật khẩu phải có ít nhất {_policy.RequiredLength} ký tự.");

            if (_policy.RequireUppercase && !password.Any(char.IsUpper))
                errors.Add("Mật khẩu phải chứa ít nhất một chữ in hoa.");

            if (_policy.RequireLowercase && !password.Any(char.IsLower))
                errors.Add("Mật khẩu phải chứa ít nhất một chữ thường.");

            if (_policy.RequireDigit && !password.Any(char.IsDigit))
                errors.Add("Mật khẩu phải chứa ít nhất một chữ số.");

            if (_policy.RequireNonAlphanumeric && password.All(char.IsLetterOrDigit))
                errors.Add("Mật khẩu phải chứa ít nhất một ký tự đặc biệt.");

            return !errors.Any();
        }
    }

}
