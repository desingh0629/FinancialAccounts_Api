using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartOfAccountsController : ControllerBase
    {
        private readonly IChatOfAccountInterface _chartOfAccountService;

        public ChartOfAccountsController(IChatOfAccountInterface chartOfAccountService)
        {
            _chartOfAccountService = chartOfAccountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChartOfAccount>>> GetChartOfAccounts()
        {
            return Ok(await _chartOfAccountService.GetChartOfAccountsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChartOfAccount>> GetChartOfAccount(Guid id)
        {
            var chartOfAccount = await _chartOfAccountService.GetChartOfAccountAsync(id);
            if (chartOfAccount == null)
            {
                return NotFound();
            }
            return chartOfAccount;
        }

        [HttpPost]
        public async Task<ActionResult<ChartOfAccount>> CreateChartOfAccount(ChartOfAccount chartOfAccount)
        {
            var createdChartOfAccount = await _chartOfAccountService.CreateChartOfAccountAsync(chartOfAccount);
            return CreatedAtAction(nameof(GetChartOfAccount), new { id = createdChartOfAccount.AccountId }, createdChartOfAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChartOfAccount(Guid id, ChartOfAccount chartOfAccount)
        {
            await _chartOfAccountService.UpdateChartOfAccountAsync(id, chartOfAccount);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChartOfAccount(Guid id)
        {
            await _chartOfAccountService.DeleteChartOfAccountAsync(id);
            return NoContent();
        }
    }
}
