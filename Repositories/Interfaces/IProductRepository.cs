using FirstCSBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstCSBackend.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
    void Update(Product product);
    void Delete(Product product);
    Task<bool> SaveChangesAsync();
}
