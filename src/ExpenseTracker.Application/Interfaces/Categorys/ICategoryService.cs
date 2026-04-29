using ExpenseTracker.Application.DTOs.Category;

namespace ExpenseTracker.Application.Interfaces.Categorys;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesAsync(Guid userId);
    Task<CategoryDto?> GetCategoryByIdAsync(int id, Guid userId);
    Task<CategoryDto> CreateCategoryAsync(Guid userId, CreateCategoryDto dto);
    Task<CategoryDto?> UpdateCategoryAsync(int id, Guid userId, UpdateCategoryDto dto); 
    Task<bool> DeleteCategoryAsync(int id, Guid userId);
}