using Inlamming3BidSite_Backend.Core.Interfaces;
using Inlamming3BidSite_Backend.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlamming3BidSite_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            userService = _userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDTO dto)
        {
            var result = _userService.Register(dto);

            if (result == null)
            {
                return BadRequest("Failed to register");
            }
            return Ok(result);

        }



        [HttpPost("Login")]

        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var token = _userService.Login(dto);

            if (token == null)
                return Unauthorized("Invalid email or password");

            return Ok(new { token = token });
        }

    }
}
