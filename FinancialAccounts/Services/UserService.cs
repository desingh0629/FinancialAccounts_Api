using FinancialAccounts.DTOs;
using FinancialAccounts.Interfases;
using FinancialAccounts.Model;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class UserService : IUsersInterface
    {

        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(Guid userId) => await _context.Users.FindAsync(userId);

        public async Task<IEnumerable<User>> GetUsersAsync() => await _context.Users.ToListAsync();

        public async Task<ServiceResponse> CreateUserAsync(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "User Created Successfully.");
        }

        public async Task UpdateUserAsync(Guid userId, User user)
        {
            var existingUser = await _context.Users.FindAsync(userId);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = user.PasswordHash;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ServiceResponse> GetUserLogin(LoginViewModel user)
        {
            var getuser = await _context.Users.AnyAsync(s => s.Username.Contains(user.UserName) && s.PasswordHash.Contains(user.Password));
            if (!getuser)
            {
                return new ServiceResponse(false, "Login failed.");
            }
            return new ServiceResponse(true, "Login successfully.");
        }



        public void res()
        {
            List<User> users = new List<User>
        {
            new User { BusinessUnitId = Guid.NewGuid(), CreatedDate = DateTime.Now },
            new User { BusinessUnitId = Guid.NewGuid(), CreatedDate = DateTime.Now }
        };

            for(int i =1; users.Count > 0; i++)
            {
                var user = users[i].Username;
            }
        }
    }
}
