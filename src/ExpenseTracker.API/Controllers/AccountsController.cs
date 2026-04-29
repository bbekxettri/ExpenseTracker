using ExpenseTracker.Application.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Application.Interfaces.Common;
using ExpenseTracker.Application.Interfaces.Accounts;

namespace ExpenseTracker.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AccountsController(IAccountService accountService, ICurrentUserService currentUser) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await accountService.GetAllAccountsAsync(currentUser.UserId);
        return Ok(accounts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var account = await accountService.GetAccountByIdAsync(id, currentUser.UserId);

        if (account is null)
            return NotFound();

        return Ok(account);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccountDto dto)
    {
        var created = await accountService.CreateAccountAsync(currentUser.UserId, dto);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAccountDto dto)
    {
        var updated = await accountService.UpdateAccountAsync(id, currentUser.UserId, dto);
        if (updated is null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await accountService.DeleteAccountAsync(id, currentUser.UserId);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
