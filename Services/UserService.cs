using FirstCSBackend.Models;
using FirstCSBackend.Repositories.Interfaces;
using FirstCSBackend.Services.Interfaces;
using FirstCSBackend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Dto;
namespace FirstCSBackend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
       
    }

    public async Task<User?> GetByIdAsync(int id) =>
        await _userRepository.GetByIdAsync(id);

    public async Task<User?> GetByUsernameAsync(string username) =>
        await _userRepository.GetByUsernameAsync(username);

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await _userRepository.GetAllAsync();

    public async Task AddAsync(UserCreateDto userDto)
    {
        if (userDto.Username == null || userDto.Password == null)
            throw new ArgumentException("Username and Password cannot be null");

        var user = new User
        {
            Username = userDto.Username,
            Password = userDto.Password
        };

        _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user != null)
        {
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
