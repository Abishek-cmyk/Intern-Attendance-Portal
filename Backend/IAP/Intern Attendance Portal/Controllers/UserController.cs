using AutoMapper;
using IAP.Application.DTOs.User;
using IAP.Domain.Data;
using IAP.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intern_Attendance_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserDTO userDto)
        {
            var NewUser = _mapper.Map<User>(userDto);
            await _dbcontext.Users.AddAsync(NewUser);
            await _dbcontext.SaveChangesAsync();
            return Ok("User Created Successfully...");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var Users = await _dbcontext.Users.ToListAsync();
            var UserDTO = _mapper.Map<IEnumerable<UserDTO>>(Users);
            return Ok(UserDTO);

        }



    }
}
