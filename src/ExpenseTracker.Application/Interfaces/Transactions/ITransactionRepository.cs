using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Interfaces.Transactions;
public interface ITransactionRepository
{
    Task<List<Transaction>> GetAllTransactionsAsync(Guid userId);
    Task<Transaction?> GetTransactionByIdAsync(int id, Guid userId);
    Task<Transaction> CreateTransactionAsync(Transaction transaction);
    Task<Transaction> UpdateTransactionAsync(Transaction transaction);
    Task<bool> DeleteTransactionAsync(int id, Guid userId);
}