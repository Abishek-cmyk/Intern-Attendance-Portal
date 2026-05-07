using IAP.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace IAP.Application.DTOs.User
{
    public class UpdateUserDTO
    {

        public int CompanyId { get; set; }


        public string? EmployeeId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        public UserRole Role { get; set; }

        public UserStatus Status { get; set; }
    }
}