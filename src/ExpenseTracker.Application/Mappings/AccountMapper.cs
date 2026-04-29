using ExpenseTracker.Application.DTOs.Account;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Mappings;

public static class AccountMapper
{
    public static AccountDto ToAccountDto(this Account accountModel)
    {
        return new AccountDto
        {
            Id = accountModel.Id,
            UserId =  accountModel.UserId,
            Name = accountModel.Name,
            CurrencyType = accountModel.CurrencyType,
            Balance = accountModel.Balance
        };

    }

    public static Account ToAccountFromCreatDto(this CreateAccountDto accountDto)
    {
        return new Account
        {
            Name = accountDto.Name,
            Type = accountDto.AccType,
            CurrencyType = accountDto.CurrencyType,
            Balance = accountDto.Balance

        };
    }
}