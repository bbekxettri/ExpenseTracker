using ExpenseTracker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Application.DTOs.Account;

public class CreateAccountDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    public AccountType AccType { get; set; }

    [Range(0, 999999999)]
    public decimal Balance { get; set; }

    [Required]
    [StringLength(3, MinimumLength = 3)]
    public string CurrencyType { get; set; } = "NRP";
}
