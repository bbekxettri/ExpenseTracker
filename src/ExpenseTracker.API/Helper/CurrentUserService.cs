using System.Security.Claims;
using ExpenseTracker.Application.Interfaces.Common;

namespace ExpenseTracker.API.Helper;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public Guid UserId
    {
        get
        {
            var claim = httpContextAccessor.HttpContext?
                .User.FindFirst(ClaimTypes.NameIdentifier);

            return claim == null ? throw new UnauthorizedAccessException("User not authenticated") : Guid.Parse(claim.Value);
        }
    }
}