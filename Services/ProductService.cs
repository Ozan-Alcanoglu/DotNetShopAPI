using FirstCSBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using FirstCSBackend.Repositories.Interfaces;
using FirstCSBackend.Services.Interfaces;
namespace FirstCSBackend.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetByIdAsync(int id) =>
        await _productRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _productRepository.GetAllAsync();

    public async Task AddAsync(Product product)
    {
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _productRepository.Update(product);
        await _productRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product != null)
        {
            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();
        }
    }
}
