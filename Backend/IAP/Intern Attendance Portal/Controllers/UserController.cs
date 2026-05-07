using AutoMapper;
using IAP.Application.DTOs.User;
using IAP.Domain.Data;
using IAP.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailExists = await _dbcontext.Users
                .AnyAsync(x => x.Email == userDto.Email);

            if (emailExists)
            {
                return BadRequest("Email already exists.");
            }

            var newUser = _mapper.Map<User>(userDto);

            await _dbcontext.Users.AddAsync(newUser);
            await _dbcontext.SaveChangesAsync();

            return Ok("User Created Successfully...");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var users = await _dbcontext.Users.ToListAsync();

            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(userDTOs);
        }
    }
}