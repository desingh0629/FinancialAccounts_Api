using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface ICurrencyInterface
    {
        Task<Currency> GetCurrencyAsync(Guid currencyId);
        Task<IEnumerable<Currency>> GetCurrenciesAsync();
        Task<Currency> CreateCurrencyAsync(Currency currency);
        Task UpdateCurrencyAsync(Guid currencyId, Currency currency);
        Task DeleteCurrencyAsync(Guid currencyId);
    }
}
