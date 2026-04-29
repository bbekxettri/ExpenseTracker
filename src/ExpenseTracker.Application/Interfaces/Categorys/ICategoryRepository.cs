using ExpenseTracker.Domain.Entities;
namespace ExpenseTracker.Application.Interfaces.Categorys;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategoriesAsync(Guid userId);
    Task<Category?> GetCategoryByIdAsync(int id, Guid userId);
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category); 
    Task<bool> DeleteCategoryAsync(int id, Guid userId);
}