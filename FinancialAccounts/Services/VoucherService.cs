using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class VoucherService : IVoucherInterface
    {
        private readonly ApplicationDbContext _context;

        public VoucherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Voucher> GetVoucherAsync(Guid voucherId)
        {
            return await _context.Vouchers.FindAsync(voucherId);
        }

        public async Task<IEnumerable<Voucher>> GetVouchersAsync()
        {
            return await _context.Vouchers.ToListAsync();
        }

        public async Task<Voucher> CreateVoucherAsync(Voucher voucher)
        {
            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();
            return voucher;
        }

        public async Task UpdateVoucherAsync(Guid voucherId, Voucher voucher)
        {
            var existingVoucher = await _context.Vouchers.FindAsync(voucherId);
            if (existingVoucher != null)
            {
                existingVoucher.VoucherNumber = voucher.VoucherNumber;
                existingVoucher.Date = voucher.Date;
                existingVoucher.AccountId = voucher.AccountId;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteVoucherAsync(Guid voucherId)
        {
            var voucher = await _context.Vouchers.FindAsync(voucherId);
            if (voucher != null)
            {
                _context.Vouchers.Remove(voucher);
                await _context.SaveChangesAsync();
            }
        }
    }
}
