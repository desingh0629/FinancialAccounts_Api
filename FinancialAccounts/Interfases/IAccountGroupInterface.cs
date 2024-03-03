using FinancialAccounts.DTOs;
using FinancialAccounts.Model.Entities;
using System.Text.RegularExpressions;

namespace FinancialAccounts.Interfases
{
    public interface IAccountGroupInterface
    {
        Task<AccountGroup> GetGroupAsync(Guid groupId);
        Task<IEnumerable<AccountGroup>> GetGroupsAsync();
        Task<ServiceResponse> CreateGroupAsync(AccountGroup group);
        Task<ServiceResponse> UpdateGroupAsync(Guid groupId, AccountGroup group);
        Task<ServiceResponse> DeleteGroupAsync(Guid groupId);
    }
}
