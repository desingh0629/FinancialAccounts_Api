using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class TransactionService : ITransactionInterface
    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetTransactionAsync(Guid transactionId)
        {
            return await _context.Transactions.FindAsync(transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task UpdateTransactionAsync(Guid transactionId, Transaction transaction)
        {
            var existingTransaction = await _context.Transactions.FindAsync(transactionId);
            if (existingTransaction != null)
            {
                existingTransaction.BankAccountId = transaction.BankAccountId;
                existingTransaction.CurrencyId = transaction.CurrencyId;
                existingTransaction.AccountId = transaction.AccountId;
                existingTransaction.CustomerId = transaction.CustomerId;
                existingTransaction.SupplierId = transaction.SupplierId;
                existingTransaction.CostCenterId = transaction.CostCenterId;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTransactionAsync(Guid transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
