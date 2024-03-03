using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class Currency
    {
        [Key]

        public Guid CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        // Add more attributes as needed
        public string CurrencySymbol { get; set; }
        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
