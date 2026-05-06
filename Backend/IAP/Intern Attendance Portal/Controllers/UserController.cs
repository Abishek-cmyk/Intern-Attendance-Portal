using IAP.Domain.Data;
using IAP.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intern_Attendance_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;

        }
        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {

        }
    }
}
