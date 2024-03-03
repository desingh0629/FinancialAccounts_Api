using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using FinancialAccounts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyInterface _currencyService;

        public CurrenciesController(ICurrencyInterface currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies()
        {
            return Ok(await _currencyService.GetCurrenciesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(Guid id)
        {
            var currency = await _currencyService.GetCurrencyAsync(id);
            if (currency == null)
            {
                return NotFound();
            }
            return currency;
        }

        [HttpPost]
        public async Task<ActionResult<Currency>> CreateCurrency(Currency currency)
        {
            var createdCurrency = await _currencyService.CreateCurrencyAsync(currency);
            return CreatedAtAction(nameof(GetCurrency), new { id = createdCurrency.CurrencyId }, createdCurrency);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrency(Guid id, Currency currency)
        {
            await _currencyService.UpdateCurrencyAsync(id, currency);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(Guid id)
        {
            await _currencyService.DeleteCurrencyAsync(id);
            return NoContent();
        }
    }
}
