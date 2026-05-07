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
            var usersDto = _mapper.Map<UserDTO>(users);
            return Ok(usersDto);
        }

    }
}