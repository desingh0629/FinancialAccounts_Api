using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class VoucherDetail
    {
        [Key]

        public Guid VoucherDetailId { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
    
        public Guid VoucherId { get; set; }
        public virtual Voucher Voucher { get; set; }



        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}
