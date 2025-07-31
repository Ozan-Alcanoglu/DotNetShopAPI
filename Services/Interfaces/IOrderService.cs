using FirstCSBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Dto;

namespace FirstCSBackend.Services.Interfaces;

public interface IOrderService
{
    Task<Order?> GetByIdAsync(int id);
    Task<IEnumerable<Order>> GetAllAsync();
    Task AddAsync(OrderCreateDto orderCreateDto);
    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);
}
