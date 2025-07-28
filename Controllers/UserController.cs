using FirstCSBackend.Models;
using FirstCSBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstCSBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null) return NotFound();
        return user;
    }

    [HttpPost]
    public async Task<ActionResult> Create(User user)
    {
        await _userService.AddAsync(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, User user)
    {
        if (id != user.Id) return BadRequest();

        await _userService.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}
