using ExpenseTracker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Application.DTOs.Category;

public class CreateCategoryDto
{
    [Required]
    [StringLength(80, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    public TransactionType Type { get; set; }

    public TransactionSubType? SubType { get; set; }
}
