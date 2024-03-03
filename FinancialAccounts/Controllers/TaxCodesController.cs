using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using FinancialAccounts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCodesController : ControllerBase
    {
        private readonly ITaxCodeInterface _taxCodeService;

        public TaxCodesController(ITaxCodeInterface taxCodeService)
        {
            _taxCodeService = taxCodeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<taxCode>>> GetTaxCodes()
        {
            return Ok(await _taxCodeService.GetTaxCodesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<taxCode>> GetTaxCode(Guid id)
        {
            var taxCode = await _taxCodeService.GetTaxCodeAsync(id);
            if (taxCode == null)
            {
                return NotFound();
            }
            return taxCode;
        }

        [HttpPost]
        public async Task<ActionResult<taxCode>> CreateTaxCode(taxCode taxCode)
        {
            var createdTaxCode = await _taxCodeService.CreateTaxCodeAsync(taxCode);
            return CreatedAtAction(nameof(GetTaxCode), new { id = createdTaxCode.TaxCodeId }, createdTaxCode);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaxCode(Guid id, taxCode taxCode)
        {
            await _taxCodeService.UpdateTaxCodeAsync(id, taxCode);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxCode(Guid id)
        {
            await _taxCodeService.DeleteTaxCodeAsync(id);
            return NoContent();
        }
    }
}
