using FinancialAccounts.DTOs;
using FinancialAccounts.Model;
using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IUsersInterface
    {
        Task<User> GetUserAsync(Guid userId);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<ServiceResponse> CreateUserAsync(User user);
        Task UpdateUserAsync(Guid userId, User user);
        Task DeleteUserAsync(Guid userId);
        Task<ServiceResponse> GetUserLogin(LoginViewModel user);
    }
}
