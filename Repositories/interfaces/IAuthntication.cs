using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface IAuthentication
    {
        // Add register
        public Task<UserDto> Register(RegisterDto registerdUserDto);


        // Add login 
        public Task<UserDto> UserAuthentication(string username, string password);
        Task Logout();
    }
}
