using AutoMapper;
using MAEntities.DTO;
using MAEntities.Entities;
using MBLL.Interface;
using MDAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(_mapper.Map<List<UserDto>>(users));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            try
            {
                await _userService.CreateUser(userDto);
                return Ok("User is successfully added"); 
            }
            catch (Exception)
            {
                return BadRequest("Failed to create user."); 
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UserDto userDto)
        {
            try
            {
                await _userService.UpdateUser(userId, userDto);
                return Ok("Update is successful");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                await _userService.DeleteUser(userId);
                return Ok("User is deleted");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
