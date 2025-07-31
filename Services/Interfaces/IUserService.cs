using FirstCSBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Dto;
namespace FirstCSBackend.Services.Interfaces;

public interface IUserService
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByUsernameAsync(string username);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(UserCreateDto userDto);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}
