using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class BankAccount
    {
        [Key]

        public Guid AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public decimal Balance { get; set; }


        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
