using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IVoucherInterface
    {
        Task<Voucher> GetVoucherAsync(Guid voucherId);
        Task<IEnumerable<Voucher>> GetVouchersAsync();
        Task<Voucher> CreateVoucherAsync(Voucher voucher);
        Task UpdateVoucherAsync(Guid voucherId, Voucher voucher);
        Task DeleteVoucherAsync(Guid voucherId);
    }
}
