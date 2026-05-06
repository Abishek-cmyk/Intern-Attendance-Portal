using IAP.Domain.Helper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAP.Domain.Entity
{
    [Table("system_setting")]
    public class SystemSetting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("company_id")]
        public int CompanyId { get; set; }

        [Required]
        [Column("check_in_start_time")]
        public TimeSpan CheckInStartTime { get; set; }

        [Required]
        [Column("check_in_end_time")]
        public TimeSpan CheckInEndTime { get; set; }

        [Required]
        [Column("check_out_start_time")]
        public TimeSpan CheckOutStartTime { get; set; }

        [Required]
        [Column("latitude", TypeName = "decimal(10,7)")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public decimal Latitude { get; set; }

        [Required]
        [Column("longitude", TypeName = "decimal(10,7)")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public decimal Longitude { get; set; }

        [Required]
        [Column("radius_in_meters")]
        [Range(1, 30, ErrorMessage = "Radius must be between 1 and 30 meters.")]
        public int RadiusInMeters { get; set; } = 10;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}