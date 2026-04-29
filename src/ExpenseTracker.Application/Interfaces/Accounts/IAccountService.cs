using ExpenseTracker.Application.DTOs.Account;

namespace ExpenseTracker.Application.Interfaces.Accounts;

public interface IAccountService
{
    Task<List<AccountDto>> GetAllAccountsAsync(Guid userId);
    Task<AccountDto?> GetAccountByIdAsync(int id, Guid userId);
    Task<AccountDto> CreateAccountAsync(Guid userId, CreateAccountDto dto);
    Task<AccountDto?> UpdateAccountAsync(int id, Guid userId, UpdateAccountDto dto);
    Task<bool> DeleteAccountAsync(int id, Guid userId);
}