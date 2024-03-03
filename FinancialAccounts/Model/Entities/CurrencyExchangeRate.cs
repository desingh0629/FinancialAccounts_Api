using System.ComponentModel.DataAnnotations;

namespace FinancialAccounts.Model.Entities
{
    public class CurrencyExchangeRate
    {
        [Key]

        public Guid ExchangeRateId { get; set; }
        public string FromCurrency { get; set; }
        public decimal Rate { get; set; }

        public Guid ToCurrencyId { get; set; }
        public virtual Currency ToCurrency { get; set; }



        public Guid BusinessUnitId { get; set; }
        public Guid CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
