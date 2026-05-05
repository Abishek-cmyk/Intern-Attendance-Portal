using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAP.Domain.Entity
{
    [Table("attendance")]
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("attendance_date")]
        public DateOnly AttendanceDate { get; set; }

        [Required]
        [Column("check_status")]
        public CheckStatus CheckStatus { get; set; } = CheckStatus.NotChecked;

        [Required]
        [Column("attendance_status")]
        public AttendanceStatus AttendanceStatus { get; set; } = AttendanceStatus.Absent;

        [Column("check_in_time")]
        public DateTime? CheckInTime { get; set; }

        [Column("check_out_time")]
        public DateTime? CheckOutTime { get; set; }

        [Column("check_in_latitude", TypeName = "decimal(10,7)")]
        [Range(-90, 90)]
        public decimal? CheckInLatitude { get; set; }

        [Column("check_in_longitude", TypeName = "decimal(10,7)")]
        [Range(-180, 180)]
        public decimal? CheckInLongitude { get; set; }

        [Column("check_out_latitude", TypeName = "decimal(10,7)")]
        [Range(-90, 90)]
        public decimal? CheckOutLatitude { get; set; }

        [Column("check_out_longitude", TypeName = "decimal(10,7)")]
        [Range(-180, 180)]
        public decimal? CheckOutLongitude { get; set; }

        [Column("check_in_ip")]
        [MaxLength(45)]
        public string? CheckInIp { get; set; }

        [Column("check_out_ip")]
        [MaxLength(45)]
        public string? CheckOutIp { get; set; }

        [Column("device_fingerprint")]
        [MaxLength(255)]
        public string? DeviceFingerprint { get; set; }

        [Column("device_status")]
        public DeviceStatus? DeviceStatus { get; set; }

        [Column("gps_status")]
        public GpsStatus? GpsStatus { get; set; }

        [Column("check_in_selfie_url")]
        [MaxLength(500)]
        public string? CheckInSelfieUrl { get; set; }

        [Column("check_out_selfie_url")]
        [MaxLength(500)]
        public string? CheckOutSelfieUrl { get; set; }

        [Required]
        [Column("permission")]
        public bool Permission { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = default!;
    }
}