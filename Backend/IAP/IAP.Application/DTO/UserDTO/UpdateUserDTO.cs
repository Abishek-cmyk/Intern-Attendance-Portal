using IAP.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace IAP.Application.DTOs.User
{
    public class UpdateUserDTO
    {
        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public UserStatus Status { get; set; }
    }
}