using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface ITransactionInterface
    {
        Task<Transaction> GetTransactionAsync(Guid transactionId);
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(Guid transactionId, Transaction transaction);
        Task DeleteTransactionAsync(Guid transactionId);
    }
}
