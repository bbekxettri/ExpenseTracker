using ExpenseTracker.Application.Interfaces.Accounts;
using ExpenseTracker.Application.Interfaces.Categorys;
using ExpenseTracker.Application.Interfaces.Transactions;
using ExpenseTracker.Application.Interfaces.Users;
using ExpenseTracker.Application.Services;

namespace ExpenseTracker.Api.DependencyInjection;

public static class ApplicationDi
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<ITransactionService, TransactionService>();
    }
}