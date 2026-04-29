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
    // 🔹 GET: api/categories
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var categories = await categoryService.GetAllCategoriesAsync(currentUser.UserId);

        return Ok(categories);
    }

    // 🔹 GET: api/categories/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {

        var category = await categoryService.GetCategoryByIdAsync(id, currentUser.UserId);

        if (category is null)
            return NotFound();

        return Ok(category);
    }

    // 🔹 POST: api/categories
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
    {

        var created = await categoryService.CreateCategoryAsync(currentUser.UserId, dto);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // 🔹 PUT: api/categories/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto dto)
    {

        var updated = await categoryService.UpdateCategoryAsync(id, currentUser.UserId, dto);

        if (updated is null)
            return NotFound();

        return Ok(updated);
    }

    // 🔹 DELETE: api/categories/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {

        var deleted = await categoryService.DeleteCategoryAsync(id, currentUser.UserId);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}