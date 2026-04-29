using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Application.DTOs.Account;

public class CreateAccountDto
{
    public string Name { get; set; } = string.Empty;
    public AccountType AccType { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyType { get; set; } = "NRP";
}