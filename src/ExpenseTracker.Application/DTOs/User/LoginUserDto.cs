namespace ExpenseTracker.Application.DTOs.User;

using System.ComponentModel.DataAnnotations;

public class LoginUserDto
{
    [Required]
    [EmailAddress]
    [StringLength(254)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
