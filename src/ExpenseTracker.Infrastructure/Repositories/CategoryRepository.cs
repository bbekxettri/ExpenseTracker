using ExpenseTracker.Application.Interfaces.Categorys;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task<List<Category>> GetAllCategoriesAsync(Guid userId)
    {
        return await context.Categories
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id, Guid userId)
    {
        return await context.Categories
            .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        context.Categories.Update(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> DeleteCategoryAsync(int id, Guid userId)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
        if (category is null)
            return false;
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        return true;
    }
}