namespace ExpenseTracker.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public List<Account> Accounts { get; set; } = new();
    public List<Transaction> Transactions { get; set; } = new();
    public List<Category> Categories { get; set; } = new();

}