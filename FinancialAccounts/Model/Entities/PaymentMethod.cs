using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class PaymentMethod
    {
        [Key]

        public Guid MethodId { get; set; }
        public string MethodName { get; set; }

        public ICollection<Transaction> Transactions { get; set; }


        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
