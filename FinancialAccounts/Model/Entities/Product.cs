using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class Product
    {
        [Key]

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
        public ICollection<Transaction> TransactionItems { get; set; }

        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
