using ExpenseTracker.Application.DTOs.Category;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Mappings;

public static class CategoryMapper
{
    public static CategoryDto ToCategoryDto(this Category categoryModel)
    {
        return new CategoryDto
        {
            Id = categoryModel.Id,
            UserId =  categoryModel.UserId,
            Name = categoryModel.Name,
            Type = categoryModel.Type,
            SubType = categoryModel.SubType

        };
    } 
    public static Category ToCategoryFromCreatDto(this CreateCategoryDto createCategoryDto)
    {
        return new Category
        {
            Name = createCategoryDto.Name,
            Type = createCategoryDto.Type,
            SubType = createCategoryDto.SubType
        };
    }
    
}