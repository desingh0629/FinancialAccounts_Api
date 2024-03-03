using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IVoucherDetailsInterface
    {
        Task<VoucherDetail> GetVoucherDetailAsync(Guid voucherDetailId);
        Task<IEnumerable<VoucherDetail>> GetVoucherDetailsAsync();
        Task<VoucherDetail> CreateVoucherDetailAsync(VoucherDetail voucherDetail);
        Task UpdateVoucherDetailAsync(Guid voucherDetailId, VoucherDetail voucherDetail);
        Task DeleteVoucherDetailAsync(Guid voucherDetailId);
    }
}
