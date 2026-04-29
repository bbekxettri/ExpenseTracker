namespace ExpenseTracker.Application.Interfaces.Accounts;

public interface IAccountRepository
{
    Task<List<Domain.Entities.Account>> GetAllAccountsAsync(Guid userId);
    Task<Domain.Entities.Account?> GetAccountByIdAsync(int id, Guid userId);
    Task<Domain.Entities.Account> CreateAccountAsync(Domain.Entities.Account account);
    Task<Domain.Entities.Account> UpdateAccountAsync(Domain.Entities.Account account); 
    Task<bool> DeleteAccountAsync(int id, Guid userId);
}