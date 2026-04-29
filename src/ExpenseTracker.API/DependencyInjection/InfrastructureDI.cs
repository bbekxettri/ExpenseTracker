using ExpenseTracker.API.Helper;
using ExpenseTracker.Infrastructure.Repositories;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Application.Interfaces.Accounts;
using ExpenseTracker.Application.Interfaces.Categorys;
using ExpenseTracker.Application.Interfaces.Common;
using ExpenseTracker.Application.Interfaces.Transactions;
using ExpenseTracker.Application.Interfaces.Users;

namespace ExpenseTracker.Api.DependencyInjection;

public static class InfrastructureDi
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IAccountRepository, AccountRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<ITransactionRepository, TransactionRepository>()
            .AddScoped<IJwtService, JwtService>()
            .AddScoped<ICurrentUserService, CurrentUserService>();
    }
}