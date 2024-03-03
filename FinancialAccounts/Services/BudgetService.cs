using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class BudgetService : IBudgetInterface
    {
        private readonly ApplicationDbContext _context;

        public BudgetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Budget> GetBudgetAsync(Guid budgetId)
        {
            return await _context.Budgets.FindAsync(budgetId);
        }

        public async Task<IEnumerable<Budget>> GetBudgetsAsync()
        {
            return await _context.Budgets.ToListAsync();
        }

        public async Task<Budget> CreateBudgetAsync(Budget budget)
        {
            _context.Budgets.Add(budget);
            await _context.SaveChangesAsync();
            return budget;
        }

        public async Task UpdateBudgetAsync(Guid budgetId, Budget budget)
        {
            var existingBudget = await _context.Budgets.FindAsync(budgetId);
            if (existingBudget != null)
            {
                existingBudget.Name = budget.Name;
                existingBudget.Amount = budget.Amount;
                existingBudget.CostCenterId = budget.CostCenterId;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBudgetAsync(Guid budgetId)
        {
            var budget = await _context.Budgets.FindAsync(budgetId);
            if (budget != null)
            {
                _context.Budgets.Remove(budget);
                await _context.SaveChangesAsync();
            }
        }
    }
}
