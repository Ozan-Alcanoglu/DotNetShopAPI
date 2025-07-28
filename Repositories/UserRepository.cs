using FirstCSBackend.Data;
using FirstCSBackend.Models;
using FirstCSBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstCSBackend.Repositories;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _context;

	public UserRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<User?> GetByIdAsync(int id) =>
		await _context.Users.FindAsync(id);

	public async Task<User?> GetByUsernameAsync(string username) =>
		await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

	public async Task<IEnumerable<User>> GetAllAsync() =>
		await _context.Users.ToListAsync();

	public async Task AddAsync(User user)
	{
		await _context.Users.AddAsync(user);
	}

	public void Update(User user)
	{
		_context.Users.Update(user);
	}

	public void Delete(User user)
	{
		_context.Users.Remove(user);
	}

	public async Task<bool> SaveChangesAsync() =>
		(await _context.SaveChangesAsync()) > 0;
}
