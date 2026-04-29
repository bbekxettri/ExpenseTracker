using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Interfaces.Common;

public interface IJwtService
{
    string GenerateToken(User user);
}
