
namespace ExpenseTracker.Application.DTOs.Category;

using System.ComponentModel.DataAnnotations;

public class UpdateCategoryDto
{
    [StringLength(80, MinimumLength = 2)]
    public string? Name { get; set; }
}
