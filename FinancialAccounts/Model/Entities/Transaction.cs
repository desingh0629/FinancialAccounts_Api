using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class Transaction
    {
        [Key]

        public Guid TransactionId { get; set; }
        public Guid BankAccountId { get; set; } // Foreign key reference to BankAccount
        public virtual BankAccount BankAccount { get; set; }
        public Guid CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }


        public Guid AccountId { get; set; }
        public virtual ChartOfAccount Account { get; set; }

        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Guid? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public Guid? CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; }



        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
