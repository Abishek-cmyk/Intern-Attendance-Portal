using IAP.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace IAP.Application.DTOs.Attendance
{
    public class UpdateAttendanceDTO
    {
        [Required(ErrorMessage = "User Id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid User Id.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Attendance date is required.")]
        public DateOnly AttendanceDate { get; set; }

        [Required(ErrorMessage = "Check status is required.")]
        public CheckStatus CheckStatus { get; set; }

        [Required(ErrorMessage = "Attendance status is required.")]
        public AttendanceStatus AttendanceStatus { get; set; }

        [Range(-90, 90, ErrorMessage = "Check-in latitude must be between -90 and 90.")]
        public decimal? CheckInLatitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Check-in longitude must be between -180 and 180.")]
        public decimal? CheckInLongitude { get; set; }

        [Range(-90, 90, ErrorMessage = "Check-out latitude must be between -90 and 90.")]
        public decimal? CheckOutLatitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Check-out longitude must be between -180 and 180.")]
        public decimal? CheckOutLongitude { get; set; }

        [StringLength(45, ErrorMessage = "Check-in IP must not exceed 45 characters.")]
        public string? CheckInIp { get; set; }

        [StringLength(45, ErrorMessage = "Check-out IP must not exceed 45 characters.")]
        public string? CheckOutIp { get; set; }

        [StringLength(255, ErrorMessage = "Device fingerprint must not exceed 255 characters.")]
        public string? DeviceFingerprint { get; set; }

        public DeviceStatus? DeviceStatus { get; set; }

        public GpsStatus? GpsStatus { get; set; }

        [StringLength(500, ErrorMessage = "Check-in selfie URL must not exceed 500 characters.")]
        public string? CheckInSelfieUrl { get; set; }

        [StringLength(500, ErrorMessage = "Check-out selfie URL must not exceed 500 characters.")]
        public string? CheckOutSelfieUrl { get; set; }

        [Required(ErrorMessage = "Permission status is required.")]
        public bool Permission { get; set; }
    }
}