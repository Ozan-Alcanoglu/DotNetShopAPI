using FirstCSBackend.Models;
using FirstCSBackend.Repositories.Interfaces;
using FirstCSBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Dto;

namespace FirstCSBackend.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order?> GetByIdAsync(int id) =>
        await _orderRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Order>> GetAllAsync() =>
        await _orderRepository.GetAllAsync();

    public async Task AddAsync(OrderCreateDto order)
    {

        

        var newOrder= new Order
        {
            UserId = order.UserId,
            ProductId = order.ProductId,
            Quantity = order.Quantity,
        };

        await _orderRepository.AddAsync(newOrder);
        await _orderRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _orderRepository.Update(order);
        await _orderRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order != null)
        {
            _orderRepository.Delete(order);
            await _orderRepository.SaveChangesAsync();
        }
    }
}
