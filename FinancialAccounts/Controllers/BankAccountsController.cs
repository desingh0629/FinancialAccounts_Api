using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankInterface _accountService;

        public BankAccountsController(IBankInterface accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetAccounts()
        {
            return Ok(await _accountService.GetAccountsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetAccount(Guid id)
        {
            var account = await _accountService.GetAccountAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        [HttpPost]
        public async Task<ActionResult<BankAccount>> CreateAccount(BankAccount account)
        {
            var createdAccount = await _accountService.CreateAccountAsync(account);
            //return CreatedAtAction(nameof(GetAccount), new { id = createdAccount.AccountId }, createdAccount);
            return Ok(createdAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(Guid id, BankAccount account)
        {
            await _accountService.UpdateAccountAsync(id, account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            await _accountService.DeleteAccountAsync(id);
            return NoContent();
        }
    }
}
