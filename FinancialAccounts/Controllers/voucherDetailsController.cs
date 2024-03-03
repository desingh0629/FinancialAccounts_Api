using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using FinancialAccounts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class voucherDetailsController : ControllerBase
    {
        private readonly IVoucherDetailsInterface _voucherDetailService;

        public voucherDetailsController(IVoucherDetailsInterface voucherDetailService)
        {
            _voucherDetailService = voucherDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoucherDetail>>> GetVoucherDetails()
        {
            return Ok(await _voucherDetailService.GetVoucherDetailsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherDetail>> GetVoucherDetail(Guid id)
        {
            var voucherDetail = await _voucherDetailService.GetVoucherDetailAsync(id);
            if (voucherDetail == null)
            {
                return NotFound();
            }
            return voucherDetail;
        }

        [HttpPost]
        public async Task<ActionResult<VoucherDetail>> CreateVoucherDetail(VoucherDetail voucherDetail)
        {
            var createdVoucherDetail = await _voucherDetailService.CreateVoucherDetailAsync(voucherDetail);
            return CreatedAtAction(nameof(GetVoucherDetail), new { id = createdVoucherDetail.VoucherDetailId }, createdVoucherDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVoucherDetail(Guid id, VoucherDetail voucherDetail)
        {
            await _voucherDetailService.UpdateVoucherDetailAsync(id, voucherDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucherDetail(Guid id)
        {
            await _voucherDetailService.DeleteVoucherDetailAsync(id);
            return NoContent();
        }
    }
}
