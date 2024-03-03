using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IBudgetInterface
    {
        Task<Budget> GetBudgetAsync(Guid budgetId);
        Task<IEnumerable<Budget>> GetBudgetsAsync();
        Task<Budget> CreateBudgetAsync(Budget budget);
        Task UpdateBudgetAsync(Guid budgetId, Budget budget);
        Task DeleteBudgetAsync(Guid budgetId);
    }
}
