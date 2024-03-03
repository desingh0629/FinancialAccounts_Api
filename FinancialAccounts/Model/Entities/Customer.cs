using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class Customer
    {
        [Key]

        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string BillingAddress { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
