using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using FinancialAccounts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly IVoucherInterface _voucherService;

        public VouchersController(IVoucherInterface voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVouchers()
        {
            return Ok(await _voucherService.GetVouchersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Voucher>> GetVoucher(Guid id)
        {
            var voucher = await _voucherService.GetVoucherAsync(id);
            if (voucher == null)
            {
                return NotFound();
            }
            return voucher;
        }

        [HttpPost]
        public async Task<ActionResult<Voucher>> CreateVoucher(Voucher voucher)
        {
            var createdVoucher = await _voucherService.CreateVoucherAsync(voucher);
            return CreatedAtAction(nameof(GetVoucher), new { id = createdVoucher.VoucherId }, createdVoucher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVoucher(Guid id, Voucher voucher)
        {
            await _voucherService.UpdateVoucherAsync(id, voucher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(Guid id)
        {
            await _voucherService.DeleteVoucherAsync(id);
            return NoContent();
        }
    }
}
