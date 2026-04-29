using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Application.DTOs.Transaction;

public class TransactionDto
{
    public int Id { get; set; }

    public Guid UserId { get; set; }
    public int AccountId { get; set; }
    public int? CategoryId { get; set; }

    public TransactionType Type { get; set; }
    public TransactionSubType? SubType { get; set; }

    public decimal Amount { get; set; }
    public string? Note { get; set; }

    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}