using FirstCSBackend.Models;
using FirstCSBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstCSBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _orderService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null) return NotFound();
        return order;
    }

    [HttpPost]
    public async Task<ActionResult> Create(Order order)
    {
        await _orderService.AddAsync(order);
        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Order order)
    {
        if (id != order.Id) return BadRequest();

        await _orderService.UpdateAsync(order);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _orderService.DeleteAsync(id);
        return NoContent();
    }
}
