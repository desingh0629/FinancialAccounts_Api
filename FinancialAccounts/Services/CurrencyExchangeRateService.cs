using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class CurrencyExchangeRateService : ICurrencyExchangeRateInterface
    {
        private readonly ApplicationDbContext _context;

        public CurrencyExchangeRateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CurrencyExchangeRate> GetExchangeRateAsync(Guid exchangeRateId)
        {
            return await _context.CurrencyExchangeRates.FindAsync(exchangeRateId);
        }

        public async Task<IEnumerable<CurrencyExchangeRate>> GetExchangeRatesAsync()
        {
            return await _context.CurrencyExchangeRates.ToListAsync();
        }

        public async Task<CurrencyExchangeRate> CreateExchangeRateAsync(CurrencyExchangeRate exchangeRate)
        {
            _context.CurrencyExchangeRates.Add(exchangeRate);
            await _context.SaveChangesAsync();
            return exchangeRate;
        }

        public async Task UpdateExchangeRateAsync(Guid exchangeRateId, CurrencyExchangeRate exchangeRate)
        {
            var existingExchangeRate = await _context.CurrencyExchangeRates.FindAsync(exchangeRateId);
            if (existingExchangeRate != null)
            {
                existingExchangeRate.FromCurrency = exchangeRate.FromCurrency;
                existingExchangeRate.Rate = exchangeRate.Rate;
                existingExchangeRate.ToCurrencyId = exchangeRate.ToCurrencyId;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteExchangeRateAsync(Guid exchangeRateId)
        {
            var exchangeRate = await _context.CurrencyExchangeRates.FindAsync(exchangeRateId);
            if (exchangeRate != null)
            {
                _context.CurrencyExchangeRates.Remove(exchangeRate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
