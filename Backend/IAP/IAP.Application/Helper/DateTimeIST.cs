using System;
using System.Collections.Generic;
using System.Text;

namespace IAP.Application.Helper
{
    public class DateTimeIST
    {
        public static DateTime IstNow()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")
            );
        }
    }
}
