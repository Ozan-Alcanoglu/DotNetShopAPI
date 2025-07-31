using FirstCSBackend.Models;
using FirstCSBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Dto;

namespace FirstCSBackend.Controllers;

[ApiController]
[Route("/api")]
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

    [HttpPost("/add/user")]
    public async Task<IActionResult> Create([FromBody] UserCreateDto userDto)
    {
        try
        {
            await _userService.AddAsync(userDto);
            return Ok(new { message = "Kullanıcı başarıyla oluşturuldu" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Kullanıcı oluşturulurken bir hata oluştu: " + ex.Message });
        }
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
