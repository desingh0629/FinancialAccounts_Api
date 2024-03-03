using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface ISupplierInterface
    {
        Task<Supplier> GetSupplierAsync(Guid supplierId);
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(Guid supplierId, Supplier supplier);
        Task DeleteSupplierAsync(Guid supplierId);
    }
}
