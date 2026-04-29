using ExpenseTracker.Application.DTOs.Category;
using ExpenseTracker.Application.Interfaces.Categorys;
using ExpenseTracker.Application.Interfaces.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService, ICurrentUserService currentUser) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var categories = await categoryService.GetAllCategoriesAsync(currentUser.UserId);

        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {

        var category = await categoryService.GetCategoryByIdAsync(id, currentUser.UserId);

        if (category is null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
    {

        var created = await categoryService.CreateCategoryAsync(currentUser.UserId, dto);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto dto)
    {

        var updated = await categoryService.UpdateCategoryAsync(id, currentUser.UserId, dto);

        if (updated is null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {

        var deleted = await categoryService.DeleteCategoryAsync(id, currentUser.UserId);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
