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
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDTO NewUser)
        {
            User user = _mapper.Map<User>(NewUser);
            bool isCreated = await _userService.CreateUserAsync(user);
            if (isCreated == false)
                return Conflict("User email already exists!");
            return Ok("User created successfully...");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO updateUserDto)
        {
            User user = _mapper.Map<User>(updateUserDto);
            bool isUpdated = await _userService.UpdateUserAsync(id, user);
            if (isUpdated == false)
                return Conflict("Unable to update the user! check the user id");
            return Ok("User updated successfully...");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            bool isDeleted = await _userService.DeleteUserAsync(id);
            if (isDeleted == false)
                return NotFound("User not found...");
            return Ok("User Deleted");
        }

        //public async Task<ActionResult> UpdateUser(int id)
        //{

        //}


    }
}