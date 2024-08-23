using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface Iuser
    {
        Task<User> CreateUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userId);

        Task<User> UpdateUser(int id, User user);

        Task DeleteUser(int id);

       
    }

}
