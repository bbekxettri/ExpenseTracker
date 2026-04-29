using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Application.DTOs.Transaction;

public class CreateTransactionDto
{

    public int AccountId { get; set; }
    public int? CategoryId { get; set; }
    public TransactionType Type { get; set; }
    public TransactionSubType? SubType { get; set; }
    public decimal Amount { get; set; }
    public int? TransferToAccountId { get; set; }
    public int? TransferFromAccountId { get; set; }
    public string? Note { get; set; }
    public DateTime Date { get; set; }
}