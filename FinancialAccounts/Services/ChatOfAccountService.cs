using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class ChatOfAccountService : IChatOfAccountInterface
    {
        private readonly ApplicationDbContext _context;

        public ChatOfAccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChartOfAccount> GetChartOfAccountAsync(Guid accountId)
        {
            return await _context.ChartOfAccounts.FindAsync(accountId);
        }

        public async Task<IEnumerable<ChartOfAccount>> GetChartOfAccountsAsync()
        {
            return await _context.ChartOfAccounts.ToListAsync();
        }

        public async Task<ChartOfAccount> CreateChartOfAccountAsync(ChartOfAccount chartOfAccount)
        {
            _context.ChartOfAccounts.Add(chartOfAccount);
            await _context.SaveChangesAsync();
            return chartOfAccount;
        }

        public async Task UpdateChartOfAccountAsync(Guid accountId, ChartOfAccount chartOfAccount)
        {
            var existingChartOfAccount = await _context.ChartOfAccounts.FindAsync(accountId);
            if (existingChartOfAccount != null)
            {
                existingChartOfAccount.AccountName = chartOfAccount.AccountName;
                existingChartOfAccount.Type = chartOfAccount.Type;
                existingChartOfAccount.OpeningBalance = chartOfAccount.OpeningBalance;
                existingChartOfAccount.AccountGroupId = chartOfAccount.AccountGroupId;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteChartOfAccountAsync(Guid accountId)
        {
            var chartOfAccount = await _context.ChartOfAccounts.FindAsync(accountId);
            if (chartOfAccount != null)
            {
                _context.ChartOfAccounts.Remove(chartOfAccount);
                await _context.SaveChangesAsync();
            }
        }
    }
}
