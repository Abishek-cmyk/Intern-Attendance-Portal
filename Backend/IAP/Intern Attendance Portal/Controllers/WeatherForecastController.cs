using IAP.Application;
using Microsoft.AspNetCore.Mvc;

namespace Intern_Attendance_Portal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController(Class1 m) : ControllerBase
    {


        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

    }
}
