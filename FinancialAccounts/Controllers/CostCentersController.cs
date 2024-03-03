using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using FinancialAccounts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCentersController : ControllerBase
    {
        private readonly ICostCenterInterface _costCenterService;

        public CostCentersController(ICostCenterInterface costCenterService)
        {
            _costCenterService = costCenterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CostCenter>>> GetCostCenters()
        {
            return Ok(await _costCenterService.GetCostCentersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CostCenter>> GetCostCenter(Guid id)
        {
            var costCenter = await _costCenterService.GetCostCenterAsync(id);
            if (costCenter == null)
            {
                return NotFound();
            }
            return costCenter;
        }

        [HttpPost]
        public async Task<ActionResult<CostCenter>> CreateCostCenter(CostCenter costCenter)
        {
            var createdCostCenter = await _costCenterService.CreateCostCenterAsync(costCenter);
            return CreatedAtAction(nameof(GetCostCenter), new { id = createdCostCenter.CenterId }, createdCostCenter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCostCenter(Guid id, CostCenter costCenter)
        {
            await _costCenterService.UpdateCostCenterAsync(id, costCenter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCostCenter(Guid id)
        {
            await _costCenterService.DeleteCostCenterAsync(id);
            return NoContent();
        }
    }
}
