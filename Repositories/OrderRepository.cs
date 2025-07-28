using FirstCSBackend.Data;
using FirstCSBackend.Models;
using FirstCSBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstCSBackend.Repositories;

public class OrderRepository : IOrderRepository
{
	private readonly AppDbContext _context;

	public OrderRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Order?> GetByIdAsync(int id) =>
		await _context.Orders.FindAsync(id);

	public async Task<IEnumerable<Order>> GetAllAsync() =>
		await _context.Orders
			.Include(o => o.User)
			.Include(o => o.Product)
			.ToListAsync();

	public async Task AddAsync(Order order)
	{
		await _context.Orders.AddAsync(order);
	}

	public void Update(Order order)
	{
		_context.Orders.Update(order);
	}

	public void Delete(Order order)
	{
		_context.Orders.Remove(order);
	}

	public async Task<bool> SaveChangesAsync() =>
		(await _context.SaveChangesAsync()) > 0;
}
