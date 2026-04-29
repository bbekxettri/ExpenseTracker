using ExpenseTracker.Domain.Enums;
namespace ExpenseTracker.Domain.Entities;

public class Transaction
{
    public int Id { get; set; }

    public Guid UserId { get; set; }
    public int AccountId { get; set; }
    public int? CategoryId { get; set; }

    public TransactionType Type { get; set; }
    public TransactionSubType? SubType { get; set; }

    public decimal Amount { get; set; }
    public int? TransferToAccountId { get; set; }
    public int? TransferFromAccountId { get; set; }
    public string? Note { get; set; }

    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public User User { get; set; } = null!;
    public Account Account { get; set; } = null!;
    public Category? Category { get; set; }
}