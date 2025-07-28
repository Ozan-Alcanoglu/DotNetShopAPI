using FirstCSBackend.Data;
using FirstCSBackend.Models;
using FirstCSBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstCSBackend.Repositories;

public class ReviewRepository : IReviewRepository
{
	private readonly AppDbContext _context;
	public ReviewRepository(AppDbContext context)
	{
		_context = context;
	}
	public async Task<IEnumerable<Review>> GetAllReviewsAsync()
	{
		return await _context.Reviews.ToListAsync();
	}
	public async Task<Review?> GetReviewByIdAsync(int id)
	{
		return await _context.Reviews.FindAsync(id);
	}
	public async Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId)
	{
		return await _context.Reviews
			.Where(r => r.ProductId == productId)
			.ToListAsync();
	}
	public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(int userId)
	{
		return await _context.Reviews
			.Where(r => r.UserId == userId)
			.ToListAsync();
	}
	public async Task<Review> CreateReviewAsync(Review review)
	{
		_context.Reviews.Add(review);
		await _context.SaveChangesAsync();
		return review;
	}
	public async Task<Review?> UpdateReviewAsync(int id, Review review)
	{
		var existingReview = await GetReviewByIdAsync(id);
		if (existingReview == null) return null;
		existingReview.Rating = review.Rating;
		existingReview.Comment = review.Comment;
		existingReview.UserId = review.UserId;
		existingReview.ProductId = review.ProductId;
		_context.Reviews.Update(existingReview);
		await _context.SaveChangesAsync();
		return existingReview;
	}
	public async Task<bool> DeleteReviewAsync(int id)
	{
		var review = await GetReviewByIdAsync(id);
		if (review == null) return false;
		_context.Reviews.Remove(review);
		await _context.SaveChangesAsync();
		return true;
	}
}