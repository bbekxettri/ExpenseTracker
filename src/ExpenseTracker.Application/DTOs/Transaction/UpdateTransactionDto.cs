namespace ExpenseTracker.Application.DTOs.Transaction;

public class UpdateTransactionDto
{
    public string? Note { get; set; }
    public DateTime? Date { get; set; }
}