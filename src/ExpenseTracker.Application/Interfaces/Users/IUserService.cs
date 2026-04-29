using ExpenseTracker.Application.DTOs.User;

namespace ExpenseTracker.Application.Interfaces.Users;

public interface IUserService
{
    Task<UserDto> RegisterAsync(RegisterUserDto dto);
    Task<AuthResponseDto> LoginAsync(LoginUserDto dto);
}