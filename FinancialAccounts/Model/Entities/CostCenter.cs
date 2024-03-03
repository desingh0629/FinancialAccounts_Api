using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class CostCenter
    {
        [Key]

        public Guid CenterId { get; set; }
        public string Name { get; set; }

        public Guid ChartOfAccountId { get; set; }
        public virtual ChartOfAccount ChartOfAccount { get; set; }

        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
