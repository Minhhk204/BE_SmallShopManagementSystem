using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace BE__Small_Shop_Management_System.Services
{
    public class PasswordPolicyService
    {
        private readonly AppDbContext _context;

        public PasswordPolicyService(AppDbContext context)
        {
            _context = context;
        }

        //Lấy policy hiện tại trong DB (chỉ 1 bản ghi)
        public async Task<PasswordPolicy> GetPolicyAsync()
        {
            var policy = await _context.PasswordPolicies.FirstOrDefaultAsync();
            if (policy == null)
            {
                policy = new PasswordPolicy(); // default
                _context.PasswordPolicies.Add(policy);
                await _context.SaveChangesAsync();
            }
            return policy;
        }

        //Cập nhật policy
        public async Task<PasswordPolicy> UpdatePolicyAsync(PasswordPolicyDto dto)
        {
            var policy = await _context.PasswordPolicies.FirstOrDefaultAsync();

            if (policy == null)
            {
                policy = new PasswordPolicy();
                _context.PasswordPolicies.Add(policy);
            }

            policy.RequiredLength = dto.RequiredLength;
            policy.RequireUppercase = dto.RequireUppercase;
            policy.RequireLowercase = dto.RequireLowercase;
            policy.RequireDigit = dto.RequireDigit;
            policy.RequireNonAlphanumeric = dto.RequireNonAlphanumeric;
            policy.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return policy;
        }

        //Validate mật khẩu theo policy
        public bool ValidatePassword(string password, out List<string> errors)
        {
            errors = new List<string>();
            var policy = _context.PasswordPolicies.FirstOrDefault() ?? new PasswordPolicy();

            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add("Mật khẩu không được để trống");
                return false;
            }

            if (password.Length < policy.RequiredLength)
                errors.Add($"Mật khẩu phải có ít nhất {policy.RequiredLength} ký tự");

            if (policy.RequireUppercase && !password.Any(char.IsUpper))
                errors.Add("Mật khẩu phải có ít nhất 1 chữ hoa");

            if (policy.RequireLowercase && !password.Any(char.IsLower))
                errors.Add("Mật khẩu phải có ít nhất 1 chữ thường");

            if (policy.RequireDigit && !password.Any(char.IsDigit))
                errors.Add("Mật khẩu phải có ít nhất 1 chữ số");

            if (policy.RequireNonAlphanumeric && !Regex.IsMatch(password, @"[^a-zA-Z0-9]"))
                errors.Add("Mật khẩu phải có ít nhất 1 ký tự đặc biệt");

            return !errors.Any();
        }
    }

}
