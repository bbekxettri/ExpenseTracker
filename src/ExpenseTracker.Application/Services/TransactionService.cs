using ExpenseTracker.Application.DTOs.Transaction;
using ExpenseTracker.Application.Interfaces.Accounts;
using ExpenseTracker.Application.Interfaces.Transactions;
using ExpenseTracker.Application.Mappings;
using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;

    public TransactionService(
        ITransactionRepository transactionRepository,
        IAccountRepository accountRepository)
    {
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
    }
    public async Task<List<TransactionDto>> GetAllTransactionsAsync(Guid userId)
    {
        var transactions = await _transactionRepository.GetAllTransactionsAsync(userId);
        return transactions.Select(t => t.ToTransactionDto()).ToList();
    }

    public async Task<TransactionDto?> GetTransactionByIdAsync(int id, Guid userId)
    {
        var transaction = await _transactionRepository.GetTransactionByIdAsync(id, userId);
        return transaction?.ToTransactionDto();
    }

    public async Task<TransactionDto> CreateTransactionAsync(Guid userId, CreateTransactionDto dto)
    {
        var transaction = dto.ToTransactionFromCreateDto();
        transaction.UserId = userId;
        
        var account = await _accountRepository.GetAccountByIdAsync(dto.AccountId, userId);
        if (account is null) throw new Exception("Account not found");

        switch (dto.Type)
        {
            case TransactionType.Income:
                account.Balance += dto.Amount;
                break;
            case TransactionType.Expense:
                account.Balance -= dto.Amount;
                break;
            case TransactionType.Transfer:
            {
                var from = await _accountRepository.GetAccountByIdAsync(dto.TransferFromAccountId!.Value, userId);
                var to = await _accountRepository.GetAccountByIdAsync(dto.TransferToAccountId!.Value, userId);

                if (from is null || to is null) throw new Exception("Invalid transfer accounts");

                from.Balance -= dto.Amount;
                to.Balance += dto.Amount;

                break;
            }
        }

        var created = await _transactionRepository.CreateTransactionAsync(transaction);
        await _accountRepository.UpdateAccountAsync(account);
        return created.ToTransactionDto();
    }

    public async Task<TransactionDto?> UpdateTransactionAsync(int id, Guid userId, UpdateTransactionDto dto)
    {
        var transaction = await _transactionRepository.GetTransactionByIdAsync(id, userId);
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
        var updated = await _transactionRepository.UpdateTransactionAsync(transaction);
        return updated.ToTransactionDto();
    }

    public async Task<bool> DeleteTransactionAsync(int id, Guid userId)
    {
        var transaction = await _transactionRepository.GetTransactionByIdAsync(id, userId);
        if (transaction is null) throw new Exception("Transaction not found");
        
        var account =  await _accountRepository.GetAccountByIdAsync(transaction.AccountId, userId);
        if (account is null) throw new Exception("Account not found");

        switch (transaction.Type)
        {
            case TransactionType.Income:
                account.Balance -= transaction.Amount;
                break;
            
            case TransactionType.Expense:
                account.Balance += transaction.Amount;
                break;

            case TransactionType.Transfer:
            {
                var from = await _accountRepository.GetAccountByIdAsync(transaction.TransferFromAccountId!.Value, userId);
                var to = await _accountRepository.GetAccountByIdAsync(transaction.TransferToAccountId!.Value, userId);
                if (from is null || to is null)
                    throw new Exception("Invalid transfer accounts");
                from.Balance += transaction.Amount;
                to.Balance -= transaction.Amount;
                break;
            }
        }

        var result = await _transactionRepository.DeleteTransactionAsync(id, userId);
        await _accountRepository.UpdateAccountAsync(account);
        return result;

    }
}
