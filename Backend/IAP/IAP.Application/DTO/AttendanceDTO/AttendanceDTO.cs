using IAP.Domain.Entity;

namespace IAP.Application.DTOs.Attendance
{
    public class AttendanceDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateOnly AttendanceDate { get; set; }

        public CheckStatus CheckStatus { get; set; }

        public AttendanceStatus AttendanceStatus { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public decimal? CheckInLatitude { get; set; }

        public decimal? CheckInLongitude { get; set; }

        public decimal? CheckOutLatitude { get; set; }

        public decimal? CheckOutLongitude { get; set; }

        public string? CheckInIp { get; set; }

        public string? CheckOutIp { get; set; }

        public string? DeviceFingerprint { get; set; }

        public DeviceStatus? DeviceStatus { get; set; }

        public GpsStatus? GpsStatus { get; set; }

        public string? CheckInSelfieUrl { get; set; }

        public string? CheckOutSelfieUrl { get; set; }

        public bool Permission { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}