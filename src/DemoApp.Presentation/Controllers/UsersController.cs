using DemoApp.Application.DTOs;
using DemoApp.Application.Interfaces;
using DemoApp.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                return Ok(user);
            }
            catch (InvalidUserException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            try
            {
                _userService.CreateUser(user.Name, user.Email);
                return Ok("User created successfully.");
            }
            catch (InvalidUserException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
