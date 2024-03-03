using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface ITaxCodeInterface
    {
        Task<taxCode> GetTaxCodeAsync(Guid taxCodeId);
        Task<IEnumerable<taxCode>> GetTaxCodesAsync();
        Task<taxCode> CreateTaxCodeAsync(taxCode taxCode);
        Task UpdateTaxCodeAsync(Guid taxCodeId, taxCode taxCode);
        Task DeleteTaxCodeAsync(Guid taxCodeId);
    }
}
