using ExpenseTracker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Application.DTOs.Transaction;

public class CreateTransactionDto
{
    [Range(1, int.MaxValue)]
    public int AccountId { get; set; }

    [Range(1, int.MaxValue)]
    public int? CategoryId { get; set; }

    public TransactionType Type { get; set; }

    public TransactionSubType? SubType { get; set; }

    [Range(typeof(decimal), "0.01", "999999999")]
    public decimal Amount { get; set; }

    [Range(1, int.MaxValue)]
    public int? TransferToAccountId { get; set; }

    [Range(1, int.MaxValue)]
    public int? TransferFromAccountId { get; set; }

    [StringLength(500)]
    public string? Note { get; set; }

    public DateTime Date { get; set; }
}
