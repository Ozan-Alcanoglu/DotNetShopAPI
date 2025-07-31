using FirstCSBackend.Models;
using FirstCSBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Dto;

namespace FirstCSBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _productService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return product;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto productDto)
    {
        try
        {
            await _productService.AddAsync(productDto);
            return Ok(new { message = "Ürün başarıyla oluşturuldu" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Ürün oluşturulurken bir hata oluştu: " + ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Product product)
    {
        if (id != product.Id) return BadRequest();

        await _productService.UpdateAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _productService.DeleteAsync(id);
        return NoContent();
    }
}
