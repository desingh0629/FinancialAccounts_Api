using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class AccountGroup
    {
        [Key]
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public Guid? ParentGroupId { get; set; } // For hierarchical grouping
                                                // Add more attributes as needed



        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
