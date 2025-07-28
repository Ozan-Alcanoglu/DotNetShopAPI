using FirstCSBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstCSBackend.Repositories.Interfaces;

public interface IUserRepository
{
	Task<User?> GetByIdAsync(int id);
	Task<User?> GetByUsernameAsync(string username);
	Task<IEnumerable<User>> GetAllAsync();
	Task AddAsync(User user);
	void Update(User user);
	void Delete(User user);
	Task<bool> SaveChangesAsync();
}
