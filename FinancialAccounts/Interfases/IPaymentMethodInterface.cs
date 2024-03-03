using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IPaymentMethodInterface
    {
        Task<PaymentMethod> GetPaymentMethodAsync(Guid methodId);
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();
        Task<PaymentMethod> CreatePaymentMethodAsync(PaymentMethod paymentMethod);
        Task UpdatePaymentMethodAsync(Guid methodId, PaymentMethod paymentMethod);
        Task DeletePaymentMethodAsync(Guid methodId);
    }
}
