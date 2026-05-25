using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Application.DTOs.Category;

public class CategoryDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public TransactionSubType? SubType { get; set; }
}