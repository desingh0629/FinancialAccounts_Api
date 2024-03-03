using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeRatesController : ControllerBase
    {
        private readonly ICurrencyExchangeRateInterface _exchangeRateService;

        public CurrencyExchangeRatesController(ICurrencyExchangeRateInterface exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyExchangeRate>>> GetExchangeRates()
        {
            return Ok(await _exchangeRateService.GetExchangeRatesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyExchangeRate>> GetExchangeRate(Guid id)
        {
            var exchangeRate = await _exchangeRateService.GetExchangeRateAsync(id);
            if (exchangeRate == null)
            {
                return NotFound();
            }
            return exchangeRate;
        }

        [HttpPost]
        public async Task<ActionResult<CurrencyExchangeRate>> CreateExchangeRate(CurrencyExchangeRate exchangeRate)
        {
            var createdExchangeRate = await _exchangeRateService.CreateExchangeRateAsync(exchangeRate);
            return CreatedAtAction(nameof(GetExchangeRate), new { id = createdExchangeRate.ExchangeRateId }, createdExchangeRate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExchangeRate(Guid id, CurrencyExchangeRate exchangeRate)
        {
            await _exchangeRateService.UpdateExchangeRateAsync(id, exchangeRate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExchangeRate(Guid id)
        {
            await _exchangeRateService.DeleteExchangeRateAsync(id);
            return NoContent();
        }
    }
}
