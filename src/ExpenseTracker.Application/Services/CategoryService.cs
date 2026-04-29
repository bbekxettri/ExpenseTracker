using ExpenseTracker.Application.DTOs.Category;
using ExpenseTracker.Application.Interfaces.Categorys;
using ExpenseTracker.Application.Mappings;

namespace ExpenseTracker.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<List<CategoryDto>> GetAllCategoriesAsync(Guid userId)
    {
        var categories = await categoryRepository.GetAllCategoriesAsync(userId);
        return categories.Select(c => c.ToCategoryDto()).ToList();
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int id, Guid userId)
    {
        var category = await categoryRepository.GetCategoryByIdAsync(id, userId);
        return category?.ToCategoryDto();
    }

    public async Task<CategoryDto> CreateCategoryAsync(Guid userId, CreateCategoryDto dto)
    {
        var category = dto.ToCategoryFromCreatDto();
        category.UserId = userId;
        var created = await categoryRepository.CreateCategoryAsync(category);
        return created.ToCategoryDto();
    }

    public async Task<CategoryDto?> UpdateCategoryAsync(int id, Guid userId, UpdateCategoryDto dto)
    {
        var account = await categoryRepository.GetCategoryByIdAsync(id, userId);
        if (account is null)
            return null;
        if (dto.Name is not null)
            account.Name = dto.Name;

        var updated = await categoryRepository.UpdateCategoryAsync(account);
        return updated.ToCategoryDto();
    }

    public async Task<bool> DeleteCategoryAsync(int id, Guid userId)
    {
        return await categoryRepository.DeleteCategoryAsync(id, userId);
    }
}