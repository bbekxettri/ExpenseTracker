using ExpenseTracker.Domain.Enums;
namespace ExpenseTracker.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public AccountType Type { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyType { get; set; } = "NRP";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // nav
    public User User { get; set; } = null!;
    public List<Transaction> Transactions { get; set; } = new();
}