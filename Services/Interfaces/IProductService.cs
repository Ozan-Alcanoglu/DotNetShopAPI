using FirstCSBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Dto;

namespace FirstCSBackend.Services.Interfaces;

public interface IProductService
{
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(ProductCreateDto product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}
