using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface ICurrencyExchangeRateInterface
    {
        Task<CurrencyExchangeRate> GetExchangeRateAsync(Guid exchangeRateId);
        Task<IEnumerable<CurrencyExchangeRate>> GetExchangeRatesAsync();
        Task<CurrencyExchangeRate> CreateExchangeRateAsync(CurrencyExchangeRate exchangeRate);
        Task UpdateExchangeRateAsync(Guid exchangeRateId, CurrencyExchangeRate exchangeRate);
        Task DeleteExchangeRateAsync(Guid exchangeRateId);
    }
}
