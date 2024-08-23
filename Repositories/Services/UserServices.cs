using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class UserServices : Iuser
    {

        private readonly TunifyDbContext _context;

        public UserServices(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<User>  CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(int id)
        {
            var getUser = await GetUserById(id);
            _context.Entry(getUser).State = EntityState.Deleted;
            //_context.employees.Remove(getEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await _context.Users.ToListAsync();
            return allUsers;
        }

        public async Task<User> GetUserById(int userId)
        {
            //var emplyee = _context.employees.Where(x => x.Equals(employeeId));
            var User = await _context.Users.FindAsync(userId);
            return User;
        }

      

        public async Task<User> UpdateUser(int id, User  updateuser)
        {
            var upuser = await _context.Users.FindAsync(id);
            upuser = updateuser;

            await _context.SaveChangesAsync();
        
            return updateuser;

        }

    }
}
