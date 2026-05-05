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

        [HttpGet]
        public string Get()
        {

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
            return m.name;
        }
    }
}
