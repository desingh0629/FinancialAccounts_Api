using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class TaxCodeService : ITaxCodeInterface
    {
        private readonly ApplicationDbContext _context;

        public TaxCodeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<taxCode> GetTaxCodeAsync(Guid taxCodeId)
        {
            return await _context.TaxCodes.FindAsync(taxCodeId);
        }

        public async Task<IEnumerable<taxCode>> GetTaxCodesAsync()
        {
            return await _context.TaxCodes.ToListAsync();
        }

        public async Task<taxCode> CreateTaxCodeAsync(taxCode taxCode)
        {
            _context.TaxCodes.Add(taxCode);
            await _context.SaveChangesAsync();
            return taxCode;
        }

        public async Task UpdateTaxCodeAsync(Guid taxCodeId, taxCode taxCode)
        {
            var existingTaxCode = await _context.TaxCodes.FindAsync(taxCodeId);
            if (existingTaxCode != null)
            {
                existingTaxCode.Code = taxCode.Code;
                existingTaxCode.Description = taxCode.Description;
                existingTaxCode.Rate = taxCode.Rate;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTaxCodeAsync(Guid taxCodeId)
        {
            var taxCode = await _context.TaxCodes.FindAsync(taxCodeId);
            if (taxCode != null)
            {
                _context.TaxCodes.Remove(taxCode);
                await _context.SaveChangesAsync();
            }
        }
    }
}
