
using FirstCSBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstCSBackend.Repositories.Interfaces;
namespace FirstCSBackend.Services.Interfaces;


public interface IReviewService
{
    Task<IEnumerable<Review>> GetAllReviewsAsync();
    Task<Review?> GetReviewByIdAsync(int id);
    Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId);
    Task<IEnumerable<Review>> GetReviewsByUserIdAsync(int userId);
    Task<Review> CreateReviewAsync(Review review);
    Task<Review?> UpdateReviewAsync(int id, Review review);
    Task<bool> DeleteReviewAsync(int id);
}