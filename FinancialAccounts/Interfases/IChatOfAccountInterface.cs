using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IChatOfAccountInterface
    {
        Task<ChartOfAccount> GetChartOfAccountAsync(Guid accountId);
        Task<IEnumerable<ChartOfAccount>> GetChartOfAccountsAsync();
        Task<ChartOfAccount> CreateChartOfAccountAsync(ChartOfAccount chartOfAccount);
        Task UpdateChartOfAccountAsync(Guid accountId, ChartOfAccount chartOfAccount);
        Task DeleteChartOfAccountAsync(Guid accountId);
    }
}
