using ExpenseTracker.Application.DTOs.Account;
using ExpenseTracker.Application.Interfaces.Accounts;
using ExpenseTracker.Application.Mappings;

namespace ExpenseTracker.Application.Services;

public class AccountService(IAccountRepository accountRepository) : IAccountService
{
    public async Task<List<AccountDto>> GetAllAccountsAsync(Guid userId)
    {
        var accounts = await accountRepository.GetAllAccountsAsync(userId);
        return accounts.Select(a => a.ToAccountDto()).ToList();
    }

    public async Task<AccountDto?> GetAccountByIdAsync(int id, Guid userId)
    {
        var account = await accountRepository.GetAccountByIdAsync(id, userId);
        return account?.ToAccountDto();
    }

    public async Task<AccountDto> CreateAccountAsync(Guid userId, CreateAccountDto dto)
    {
        var account = dto.ToAccountFromCreatDto();
        account.UserId = userId;
        var created = await accountRepository.CreateAccountAsync(account);
        return created.ToAccountDto();
    }

    public async Task<AccountDto?> UpdateAccountAsync(int id, Guid userId, UpdateAccountDto dto)
    {
        var account = await accountRepository.GetAccountByIdAsync(id, userId);
        if (account is null)
            return null;

        if (dto.AccountName is not null)
            account.AccountName = dto.AccountName;
        if (dto.CurrencyType is not null)
            account.CurrencyType = dto.CurrencyType;

        var updated = await accountRepository.UpdateAccountAsync(account);
        return updated.ToAccountDto();
    }

    public async Task<bool> DeleteAccountAsync(int id, Guid userId)
    {
        return await accountRepository.DeleteAccountAsync(id, userId);
    }
}