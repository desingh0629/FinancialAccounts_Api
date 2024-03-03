using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using FinancialAccounts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetInterface _budgetService;

        public BudgetsController(IBudgetInterface budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Budget>>> GetBudgets()
        {
            return Ok(await _budgetService.GetBudgetsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Budget>> GetBudget(Guid id)
        {
            var budget = await _budgetService.GetBudgetAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            return budget;
        }

        [HttpPost]
        public async Task<ActionResult<Budget>> CreateBudget(Budget budget)
        {
            var createdBudget = await _budgetService.CreateBudgetAsync(budget);
            return CreatedAtAction(nameof(GetBudget), new { id = createdBudget.BudgetId }, createdBudget);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudget(Guid id, Budget budget)
        {
            await _budgetService.UpdateBudgetAsync(id, budget);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(Guid id)
        {
            await _budgetService.DeleteBudgetAsync(id);
            return NoContent();
        }
    }
}
