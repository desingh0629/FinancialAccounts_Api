using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class taxCode
    {
        [Key]

        public Guid TaxCodeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }

        public ICollection<Transaction> TransactionItems { get; set; }

        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
