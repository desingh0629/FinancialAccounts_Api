using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class VoucherDetailService : IVoucherDetailsInterface
    {
        private readonly ApplicationDbContext _context;

        public VoucherDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VoucherDetail> GetVoucherDetailAsync(Guid voucherDetailId)
        {
            return await _context.voucherDetails.FindAsync(voucherDetailId);
        }

        public async Task<IEnumerable<VoucherDetail>> GetVoucherDetailsAsync()
        {
            return await _context.voucherDetails.ToListAsync();
        }

        public async Task<VoucherDetail> CreateVoucherDetailAsync(VoucherDetail voucherDetail)
        {
            _context.voucherDetails.Add(voucherDetail);
            await _context.SaveChangesAsync();
            return voucherDetail;
        }

        public async Task UpdateVoucherDetailAsync(Guid voucherDetailId, VoucherDetail voucherDetail)
        {
            var existingVoucherDetail = await _context.voucherDetails.FindAsync(voucherDetailId);
            if (existingVoucherDetail != null)
            {
                existingVoucherDetail.DebitAmount = voucherDetail.DebitAmount;
                existingVoucherDetail.CreditAmount = voucherDetail.CreditAmount;
                existingVoucherDetail.VoucherId = voucherDetail.VoucherId;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteVoucherDetailAsync(Guid voucherDetailId)
        {
            var voucherDetail = await _context.voucherDetails.FindAsync(voucherDetailId);
            if (voucherDetail != null)
            {
                _context.voucherDetails.Remove(voucherDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
