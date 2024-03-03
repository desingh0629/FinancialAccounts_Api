using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class Role
    {
        [Key]

        public Guid RoleId { get; set; }
        public string Name { get; set; }
        // Other role attributes as needed

        // Navigation property for users (assuming a many-to-many relationship)
        public virtual ICollection<User> Users { get; set; }


        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
