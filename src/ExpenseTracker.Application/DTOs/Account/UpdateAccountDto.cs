
namespace ExpenseTracker.Application.DTOs.Account;

using System.ComponentModel.DataAnnotations;

public class UpdateAccountDto
{
    [StringLength(100, MinimumLength = 2)]
    public string? Name { get; set; }

    [StringLength(3, MinimumLength = 3)]
    public string? CurrencyType { get; set; }
}
