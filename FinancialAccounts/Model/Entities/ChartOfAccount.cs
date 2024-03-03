using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialAccounts.Model.Entities
{
    public class ChartOfAccount
    {
        [Key]
        public Guid AccountId { get; set; }

        [Column(TypeName ="nvarchar(225)")]
        public string AccountName { get; set; }
        public AccountType Type { get; set; }
        public decimal OpeningBalance { get; set; }

        public Guid? AccountGroupId { get; set; }
        public virtual AccountGroup AccountGroup { get; set; }


        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }


    }


    public enum AccountType
    {
        Asset,
        Liability,
        Equity,
        Income,
        Expense
    }
}
