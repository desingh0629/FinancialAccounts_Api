using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class SupplierService : ISupplierInterface
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> GetSupplierAsync(Guid supplierId)
        {
            var data = await _context.Suppliers.FindAsync(supplierId);
            return data;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task UpdateSupplierAsync(Guid supplierId, Supplier supplier)
        {
            var existingSupplier = await _context.Suppliers.FindAsync(supplierId);
            if (existingSupplier != null)
            {
                existingSupplier.Name = supplier.Name;
                existingSupplier.ContactNumber = supplier.ContactNumber;
                existingSupplier.Email = supplier.Email;
                existingSupplier.BillingAddress = supplier.BillingAddress;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSupplierAsync(Guid supplierId)
        {
            var supplier = await _context.Suppliers.FindAsync(supplierId);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }
    }
}
