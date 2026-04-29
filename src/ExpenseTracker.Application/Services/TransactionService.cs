using ExpenseTracker.Application.DTOs.Transaction;
using ExpenseTracker.Application.Interfaces.Transactions;
using ExpenseTracker.Application.Mappings;

namespace ExpenseTracker.Application.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    public async Task<List<TransactionDto>> GetAllTransactionsAsync(Guid userId)
    {
        var transactions = await transactionRepository.GetAllTransactionsAsync(userId);
        return transactions.Select(t => t.ToTransactionDto()).ToList();
    }

    public async Task<TransactionDto?> GetTransactionByIdAsync(int id, Guid userId)
    {
        var transaction = await transactionRepository.GetTransactionByIdAsync(id, userId);
        return transaction?.ToTransactionDto();
    }

    public async Task<TransactionDto> CreateTransactionAsync(Guid userId, CreateTransactionDto dto)
    {
        var transaction = dto.ToTransactionFromCreateDto();
        transaction.UserId = userId;
        var created = await transactionRepository.CreateTransactionAsync(transaction);
        return created.ToTransactionDto();
    }

    public async Task<TransactionDto?> UpdateTransactionAsync(int id, Guid userId, UpdateTransactionDto dto)
    {
        var transaction = await transactionRepository.GetTransactionByIdAsync(id, userId);
        if (transaction is null) return null;

        if (dto.AccountId is not null)
            transaction.AccountId = dto.AccountId.Value;
        if (dto.CategoryId is not null)
            transaction.CategoryId = dto.CategoryId.Value;
        if (dto.Type is not null)
            transaction.Type = dto.Type.Value;
        if (dto.SubType is not null)
            transaction.SubType = dto.SubType.Value;
        if (dto.Amount is not null)
            transaction.Amount = dto.Amount.Value;
        if (dto.TransferToAccountId is not null)
            transaction.TransferToAccountId = dto.TransferToAccountId.Value;
        if (dto.TransferFromAccountId is not null)
            transaction.TransferFromAccountId = dto.TransferFromAccountId.Value;
        if (dto.Note is not null)
            transaction.Note = dto.Note;
        if (dto.Date is not null)
            transaction.Date = dto.Date.Value;
        var updated = await transactionRepository.UpdateTransactionAsync(transaction);
        return updated.ToTransactionDto();
    }

    public async Task<bool> DeleteTransactionAsync(int id, Guid userId)
    {
        return await transactionRepository.DeleteTransactionAsync(id, userId);
    }
}
