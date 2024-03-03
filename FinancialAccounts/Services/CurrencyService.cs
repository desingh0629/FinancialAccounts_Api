using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class CurrencyService : ICurrencyInterface
    {
        private readonly ApplicationDbContext _context;

        public CurrencyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Currency> GetCurrencyAsync(Guid currencyId)
        {
            return await _context.Currencies.FindAsync(currencyId);
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency> CreateCurrencyAsync(Currency currency)
        {
            _context.Currencies.Add(currency);
            await _context.SaveChangesAsync();
            return currency;
        }

        public async Task UpdateCurrencyAsync(Guid currencyId, Currency currency)
        {
            var existingCurrency = await _context.Currencies.FindAsync(currencyId);
            if (existingCurrency != null)
            {
                existingCurrency.CurrencyCode = currency.CurrencyCode;
                existingCurrency.CurrencyName = currency.CurrencyName;
                existingCurrency.CurrencySymbol = currency.CurrencySymbol;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCurrencyAsync(Guid currencyId)
        {
            var currency = await _context.Currencies.FindAsync(currencyId);
            if (currency != null)
            {
                _context.Currencies.Remove(currency);
                await _context.SaveChangesAsync();
            }
        }
    }
}
