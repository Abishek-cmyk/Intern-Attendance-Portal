namespace IAP.Application.DTOs.SystemSetting
{
    public class SystemSettingDTO
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public TimeSpan CheckInStartTime { get; set; }

        public TimeSpan CheckInEndTime { get; set; }

        public TimeSpan CheckOutStartTime { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int RadiusInMeters { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}