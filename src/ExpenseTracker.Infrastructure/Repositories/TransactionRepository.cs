using ExpenseTracker.Application.Interfaces.Transactions;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class TransactionRepository(AppDbContext context) : ITransactionRepository
{
    public async Task<List<Transaction>> GetAllTransactionsAsync(Guid userId)
    {
        return await context.Transactions
            .Where(t => t.UserId == userId)
            .Include(t => t.Account)
            .Include(t => t.Category)
            .ToListAsync();
    }

    public async Task<Transaction?> GetTransactionByIdAsync(int id, Guid userId)
    {
        return await context.Transactions
            .Include(t => t.Account)
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
    }

    public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
    { 
        context.Transactions.Add(transaction);
        await  context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction> UpdateTransactionAsync(Transaction transaction)
    {
        context.Transactions.Update(transaction);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task<bool> DeleteTransactionAsync(int id, Guid userId)
    {
        var transaction = await context.Transactions.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        if (transaction is null)
            return false;
        
        context.Transactions.Remove(transaction);
        await context.SaveChangesAsync();
        return true;
    }
}