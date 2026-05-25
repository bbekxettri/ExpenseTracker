using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Application.DTOs.Account;

public class AccountDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public AccountType Type { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyType { get; set; } = "NRP";
    public DateTime CreatedAt { get; set; }
}