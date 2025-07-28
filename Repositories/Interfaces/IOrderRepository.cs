using FirstCSBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstCSBackend.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id);
    Task<IEnumerable<Order>> GetAllAsync();
    Task AddAsync(Order order);
    void Update(Order order);
    void Delete(Order order);
    Task<bool> SaveChangesAsync();
}
