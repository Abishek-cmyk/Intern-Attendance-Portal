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
    public class Attendance : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IMapper _mapper;

        public Attendance(IMapper mapper, IAttendanceService AttendanceService)
        {
            _attendanceService = AttendanceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _attendanceService.GetAllUsers();
            var usersDto = _mapper.Map<List<UserDTO>>(users);
            return Ok(usersDto);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _attendanceService.GetUserById(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);

        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDTO NewUser)
        {
            User user = _mapper.Map<User>(NewUser);
            bool isCreated = await _attendanceService.CreateUserAsync(user);
            if (isCreated == false)
                return Conflict("User email already exists!");
            return Ok("User created successfully...");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO updateUserDto)
        {
            User user = _mapper.Map<User>(updateUserDto);
            bool isUpdated = await _attendanceService.UpdateUserAsync(id, user);
            if (isUpdated == false)
                return Conflict("Unable to update the user! check the user id");
            return Ok("User updated successfully...");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            bool isDeleted = await _attendanceService.DeleteUserAsync(id);
            if (isDeleted == false)
                return NotFound("User not found...");
            return Ok("User Deleted");
        }


    }
}