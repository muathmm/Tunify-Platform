using Microsoft.AspNetCore.Identity;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager; 

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserDto> Register(RegisterDto registerdUserDto)
        {
            var user = new ApplicationUser()
            {
                UserName = registerdUserDto.UserName,
                Email = registerdUserDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerdUserDto.Password);

            if (result.Succeeded)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            return null;
        }

        public async Task<UserDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            return null;
        }
    }
}
