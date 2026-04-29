using ExpenseTracker.Application.DTOs.Transaction;

namespace ExpenseTracker.Application.Interfaces.Transactions;

public interface ITransactionService
{
     Task<List<TransactionDto>> GetAllTransactionsAsync(Guid userId);
     Task<TransactionDto?> GetTransactionByIdAsync(int id, Guid userId);
     Task<TransactionDto> CreateTransactionAsync(Guid userId, CreateTransactionDto dto);
     Task<TransactionDto?> UpdateTransactionAsync(int id, Guid userId, UpdateTransactionDto dto); 
     Task<bool> DeleteTransactionAsync(int id, Guid userId);
}