using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace FinancialAccounts.Model.Entities
{
    public class Voucher
    {
        [Key]

        public Guid VoucherId { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime Date { get; set; }

        public Guid AccountId { get; set; }
        public virtual AccountGroup Account { get; set; }



        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}
