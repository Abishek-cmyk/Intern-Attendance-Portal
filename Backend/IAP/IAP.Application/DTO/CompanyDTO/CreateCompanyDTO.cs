using System.ComponentModel.DataAnnotations;

namespace IAP.Application.DTOs.Company
{
    public class CreateCompanyDTO
    {
        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Company name must be between 3 and 30 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 255 characters.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact person is required.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Contact person must be between 3 and 150 characters.")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 20 characters.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(40, ErrorMessage = "Email must not exceed 40 characters.")]
        public string Email { get; set; } = string.Empty;
    }
}