using ExpenseTracker.Application.DTOs.Transaction;
using ExpenseTracker.Application.Interfaces.Common;
using ExpenseTracker.Application.Interfaces.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TransactionsController(ITransactionService service, ICurrentUserService currentUser) : ControllerBase
{

    // 🔹 GET: api/transactions
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var transactions = await service.GetAllTransactionsAsync(currentUser.UserId);

        return Ok(transactions);
    }

    // 🔹 GET: api/transactions/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {

        var transaction = await service.GetTransactionByIdAsync(id, currentUser.UserId);

        if (transaction is null)
            return NotFound();

        return Ok(transaction);
    }

    // 🔹 POST: api/transactions
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTransactionDto dto)
    {

        var created = await service.CreateTransactionAsync(currentUser.UserId, dto);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // 🔹 PUT: api/transactions/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTransactionDto dto)
    {

        var updated = await service.UpdateTransactionAsync(id, currentUser.UserId, dto);

        if (updated is null)
            return NotFound();

        return Ok(updated);
    }

    // 🔹 DELETE: api/transactions/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {

        var deleted = await service.DeleteTransactionAsync(id, currentUser.UserId);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
