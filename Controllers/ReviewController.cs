using FirstCSBackend.Models;
using FirstCSBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstCSBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _reviewService.GetAllReviewsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null) return NotFound();
            return review;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewCreateDto reviewDto)
        {
            var createdReview = await _reviewService.CreateReviewAsync(reviewDto);
            return CreatedAtAction(nameof(GetById), new { id = createdReview.Id }, createdReview);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Review review)
        {
            if (id != review.Id) return BadRequest();
            var updatedReview = await _reviewService.UpdateReviewAsync(id, review);
            if (updatedReview == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _reviewService.DeleteReviewAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}