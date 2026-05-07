using AutoMapper;
using IAP.Application.DTOs.User;
using IAP.Application.Services;
using IAP.Domain.Data;
using IAP.Domain.Entity;
using IAP.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intern_Attendance_Portal.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, UserService UserService)
        {
            _userService = UserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var usersDto = _mapper.Map<List<UserDTO>>(users);
            return Ok(usersDto);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);

        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserDTO NewUser)
        {
            User user = _mapper.Map<User>(NewUser);
            bool isCreated = await _userService.CreateUserAsync(user);
            if (isCreated == false)
                return Conflict("User email already exists!");
            return Ok("User created successfully...");
        }

        //[HttpPut]
        //public async Task<ActionResult> UpdateUser()




    }
}