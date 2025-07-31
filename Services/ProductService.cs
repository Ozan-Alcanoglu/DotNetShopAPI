using FirstCSBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Dto;
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

    public async Task AddAsync(ProductCreateDto product)
    {
        

        var newProduct = new Product
        {
            Name = product.Name,
            Price = product.Price,
        };

        await _productRepository.AddAsync(newProduct);
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
