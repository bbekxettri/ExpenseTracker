using ExpenseTracker.Application.Interfaces.Accounts;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class AccountRepository(AppDbContext context) : IAccountRepository
{
    public async Task<List<Account>> GetAllAccountsAsync(Guid userId)
    {
        return await context.Accounts
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }

    public async Task<Account?> GetAccountByIdAsync(int id, Guid userId)
    {
        return await context.Accounts
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);
    }

    public async Task<Account> CreateAccountAsync(Account account)
    {
        context.Accounts.Add(account);
        await context.SaveChangesAsync();
        return account;
    }

    public async Task<Account> UpdateAccountAsync(Account account)
    {
        context.Accounts.Update(account);
        await context.SaveChangesAsync();
        return account;
    }

    public async Task<bool> DeleteAccountAsync(int id, Guid userId)
    {
        var account = await context.Accounts
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);
        if (account is null)
            return  false;
        context.Accounts.Remove(account);
        await  context.SaveChangesAsync();
        return true;



    }
}