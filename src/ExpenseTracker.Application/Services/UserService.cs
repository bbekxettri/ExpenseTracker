using BCrypt.Net;
using ExpenseTracker.Application.Exceptions;
using ExpenseTracker.Application.DTOs.User;
using ExpenseTracker.Application.Interfaces.Common;
using ExpenseTracker.Application.Interfaces.Users;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Services;

public class UserService(IUserRepository userRepository, IJwtService jwtService) : IUserService
{
    public async Task<UserDto> RegisterAsync(RegisterUserDto dto)
    {
        var existing = await userRepository.GetByEmailAsync(dto.Email);
        if (existing != null)
            throw new ConflictException("Email already in use.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow
        };

        await userRepository.AddAsync(user);

        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginUserDto dto)
    {
        var user = await userRepository.GetByEmailAsync(dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid email or password.");

        var token = jwtService.GenerateToken(user);

        return new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            FullName = user.FullName,
            ExpiresAt = DateTime.UtcNow.AddHours(24)
        };
    }
}
