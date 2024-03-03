using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using FinancialAccounts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodInterface _paymentMethodService;

        public PaymentMethodsController(IPaymentMethodInterface paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPaymentMethods()
        {
            return Ok(await _paymentMethodService.GetPaymentMethodsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethod>> GetPaymentMethod(Guid id)
        {
            var paymentMethod = await _paymentMethodService.GetPaymentMethodAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return paymentMethod;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            var createdPaymentMethod = await _paymentMethodService.CreatePaymentMethodAsync(paymentMethod);
            return CreatedAtAction(nameof(GetPaymentMethod), new { id = createdPaymentMethod.MethodId }, createdPaymentMethod);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentMethod(Guid id, PaymentMethod paymentMethod)
        {
            await _paymentMethodService.UpdatePaymentMethodAsync(id, paymentMethod);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(Guid id)
        {
            await _paymentMethodService.DeletePaymentMethodAsync(id);
            return NoContent();
        }
    }
}
