using GymTrackerAPI.Contracts;
using GymTrackerAPI.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AccountController(IAuthManager authManager) => _authManager = authManager;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            var errors = await _authManager.Register(userRegisterDto);

            if (errors.Any())
            {
                return BadRequest(errors);
            }

            return Ok("Rejestracja zakończona sukcesem");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var authResponse = await _authManager.Login(userLoginDto);

            if (authResponse == null)
            {
                return Unauthorized(); 
            }

            return Ok(authResponse); 
        }
    }
}
