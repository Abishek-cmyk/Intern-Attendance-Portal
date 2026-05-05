using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IAP.Domain.Entity
{
    public class Company
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [Column("contact_person")]
        public string? ContactPerson { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Phone { get; set; }

        [Required]
        [MaxLength(40)]
        [EmailAddress]
        public string? Email { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
