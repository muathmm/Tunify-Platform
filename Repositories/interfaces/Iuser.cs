using Tunify_Platform.Models;

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
