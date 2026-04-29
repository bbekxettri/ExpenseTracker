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
    // 🔹 GET: api/accounts
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await accountService.GetAllAccountsAsync(currentUser.UserId);
        return Ok(accounts);
    }

    // 🔹 GET: api/accounts/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var account = await accountService.GetAccountByIdAsync(id, currentUser.UserId);

        if (account is null)
            return NotFound();

        return Ok(account);
    }

    // 🔹 POST: api/accounts
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccountDto dto)
    {
        var created = await accountService.CreateAccountAsync(currentUser.UserId, dto);
 
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // 🔹 PUT: api/accounts/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAccountDto dto)    {
        var updated = await accountService.UpdateAccountAsync(id, currentUser.UserId, dto);
        if (updated is null)
            return NotFound();

        return Ok(updated);
    }

    // 🔹 DELETE: api/accounts/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await accountService.DeleteAccountAsync(id, currentUser.UserId);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}