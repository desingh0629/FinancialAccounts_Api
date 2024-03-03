using FinancialAccounts.DTOs;
using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class BankService : IBankInterface
    {
        private readonly ApplicationDbContext _context;
        public BankService(ApplicationDbContext context) => _context = context;
        public async Task<BankAccount> GetAccountAsync(Guid accountId) => await _context.BankAccounts.FindAsync(accountId);
        public async Task<IEnumerable<BankAccount>> GetAccountsAsync() => await _context.BankAccounts.ToListAsync();
        public async Task<ServiceResponse> CreateAccountAsync(BankAccount account)
        {
            _context.BankAccounts.Add(account);
            await _context.SaveChangesAsync();
            return new ServiceResponse(false, "Bank Created Successfully.");
        }
        public async Task<ServiceResponse> UpdateAccountAsync(Guid accountId, BankAccount account)
        {
            var existingAccount = await _context.BankAccounts.FindAsync(accountId);
            if (existingAccount != null)
            {
                existingAccount.AccountNumber = account.AccountNumber;
                existingAccount.BankName = account.BankName;
                existingAccount.Branch = account.Branch;
                existingAccount.Balance = account.Balance;
                await _context.SaveChangesAsync();
                return new ServiceResponse(true, "Bank Updated Successfully.");
            }
            return new ServiceResponse(false, "Error Occured.");
        }
        public async Task<ServiceResponse> DeleteAccountAsync(Guid accountId)
        {
            var account = await _context.BankAccounts.FindAsync(accountId);
            if (account != null)
            {
                _context.BankAccounts.Remove(account);
                await _context.SaveChangesAsync();
                return new ServiceResponse(true, "Bank Deleted Successfully.");
            }
            return new ServiceResponse(false, "Error Occured.");
        }
    }
}
