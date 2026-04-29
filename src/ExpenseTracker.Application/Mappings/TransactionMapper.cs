using ExpenseTracker.Application.DTOs.Transaction;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Mappings;

public static class TransactionMapper
{
    public static TransactionDto ToTransactionDto(this Transaction transactionModel)
    {
        return new TransactionDto
        {
            Id = transactionModel.Id,
            UserId = transactionModel.UserId,
            AccountId = transactionModel.AccountId,
            CategoryId =  transactionModel.CategoryId,
            Type =  transactionModel.Type,
            SubType = transactionModel.SubType,
            Amount = transactionModel.Amount,
            Note =  transactionModel.Note,
            Date = transactionModel.Date
        };
    }
    
    public static Transaction ToTransactionFromCreateDto(this CreateTransactionDto dto)
    {
        return new Transaction
        {
            AccountId = dto.AccountId,
            CategoryId = dto.CategoryId,
            Type = dto.Type,
            SubType = dto.SubType,
            Amount = dto.Amount,
            TransferFromAccountId = dto.TransferFromAccountId,
            TransferToAccountId = dto.TransferToAccountId,
            Note = dto.Note,
            Date = dto.Date
        };
    }
}