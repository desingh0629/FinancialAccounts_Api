using FinancialAccounts.DTOs;
using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IBankInterface
    {
        Task<BankAccount> GetAccountAsync(Guid accountId);
        Task<IEnumerable<BankAccount>> GetAccountsAsync();
        Task<ServiceResponse> CreateAccountAsync(BankAccount account);
        Task<ServiceResponse> UpdateAccountAsync(Guid accountId, BankAccount account);
        Task<ServiceResponse> DeleteAccountAsync(Guid accountId);
    }
}
