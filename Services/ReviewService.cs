using FirstCSBackend.Models;
using FirstCSBackend.Repositories.Interfaces;
using FirstCSBackend.Services.Interfaces;
using FirstCSBackend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FirstCSBackend.Services;


public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    public async Task<IEnumerable<Review>> GetAllReviewsAsync()
    {
        return await _reviewRepository.GetAllReviewsAsync();
    }
    public async Task<Review?> GetReviewByIdAsync(int id)
    {
        return await _reviewRepository.GetReviewByIdAsync(id);
    }
    public async Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId)
    {
        return await _reviewRepository.GetReviewsByProductIdAsync(productId);
    }
    public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(int userId)
    {
        return await _reviewRepository.GetReviewsByUserIdAsync(userId);
    }
    public async Task<Review> CreateReviewAsync(Review review)
    {
        return await _reviewRepository.CreateReviewAsync(review);
    }
    public async Task<Review?> UpdateReviewAsync(int id, Review review)
    {
        return await _reviewRepository.UpdateReviewAsync(id, review);
    }
    public async Task<bool> DeleteReviewAsync(int id)
    {
        return await _reviewRepository.DeleteReviewAsync(id);
    }
}
