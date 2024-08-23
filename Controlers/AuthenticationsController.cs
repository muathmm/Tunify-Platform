using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthentication userService;

        public AuthenticationsController(IAuthentication context)
        {
            userService = context;
        }




        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerdUserDto)
        {


            var user = await userService.Register(registerdUserDto);


            if (ModelState.IsValid)
            {
                return user;
            }


            if (user == null)
            {
                return Unauthorized();
            }

            return BadRequest();
        }


        // login 
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userService.UserAuthentication(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return Ok("User logged out successfully.");
        }
    }
}
