using IAP.Domain.Entity;
using IAP.Domain.Helper;

namespace IAP.Application.DTOs.User
{
    public class UserDTO
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public string EmployeeId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public UserRole Role { get; set; }

        public string RoleName => Role.ToString();

        public UserStatus Status { get; set; }

        public string StatusName => Status.ToString();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}