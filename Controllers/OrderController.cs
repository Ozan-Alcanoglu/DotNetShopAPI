using FirstCSBackend.Models;
using FirstCSBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Dto;

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
    public async Task<IActionResult> Create(OrderCreateDto orderDto)
    {
        try
        {
            await _orderService.AddAsync(orderDto);
            return Ok(new { message = "Sipariş başarıyla oluşturuldu" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Sipariş oluşturulurken bir hata oluştu: " + ex.Message });
        }
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
