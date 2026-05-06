using System.ComponentModel.DataAnnotations;

namespace IAP.Application.DTOs.SystemSetting
{
    public class CreateSystemSettingDTO
    {
        [Required(ErrorMessage = "Company Id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Company Id.")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Check-in start time is required.")]
        public TimeSpan CheckInStartTime { get; set; }

        [Required(ErrorMessage = "Check-in end time is required.")]
        public TimeSpan CheckInEndTime { get; set; }

        [Required(ErrorMessage = "Check-out start time is required.")]
        public TimeSpan CheckOutStartTime { get; set; }

        [Required(ErrorMessage = "Latitude is required.")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "Radius is required.")]
        [Range(1, 30, ErrorMessage = "Radius must be between 1 and 30 meters.")]
        public int RadiusInMeters { get; set; }
    }
}