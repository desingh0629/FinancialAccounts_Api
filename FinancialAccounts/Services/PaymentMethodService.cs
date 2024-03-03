using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class PaymentMethodService : IPaymentMethodInterface
    {
        private readonly ApplicationDbContext _context;

        public PaymentMethodService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentMethod> GetPaymentMethodAsync(Guid methodId)
        {
            return await _context.PaymentMethods.FindAsync(methodId);
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod> CreatePaymentMethodAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Add(paymentMethod);
            await _context.SaveChangesAsync();
            return paymentMethod;
        }

        public async Task UpdatePaymentMethodAsync(Guid methodId, PaymentMethod paymentMethod)
        {
            var existingPaymentMethod = await _context.PaymentMethods.FindAsync(methodId);
            if (existingPaymentMethod != null)
            {
                existingPaymentMethod.MethodName = paymentMethod.MethodName;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePaymentMethodAsync(Guid methodId)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(methodId);
            if (paymentMethod != null)
            {
                _context.PaymentMethods.Remove(paymentMethod);
                await _context.SaveChangesAsync();
            }
        }
    }
}
