using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class Budget
    {
        [Key]

        public Guid BudgetId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Guid CostCenterId { get; set; }
        public virtual CostCenter CostCenter { get; set; }

        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
