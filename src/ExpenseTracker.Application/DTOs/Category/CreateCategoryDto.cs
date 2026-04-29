using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Application.DTOs.Category;

public class CreateCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public TransactionSubType? SubType { get; set; }
}