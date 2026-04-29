namespace ExpenseTracker.Application.Interfaces.Common;

public interface ICurrentUserService
{
    Guid UserId { get; }
}