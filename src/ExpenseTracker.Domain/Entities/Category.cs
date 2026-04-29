using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public TransactionSubType? SubType { get; set; }
    
    // nav
    public User User { get; set; } = null!;
    public List<Transaction> Transactions { get; set; } = new();
}