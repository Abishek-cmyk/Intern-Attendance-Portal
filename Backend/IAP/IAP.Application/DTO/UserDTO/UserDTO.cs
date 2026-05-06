using IAP.Domain.Entity;

namespace IAP.Application.DTOs.User
{
    public class UserDTO
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public UserRole Role { get; set; }

        public UserStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}