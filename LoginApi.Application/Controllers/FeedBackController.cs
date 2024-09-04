using LoginAPI.Core;
using LoginAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoginApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        [Authorize(Policy = "UserPolicy")] // Both Admin and User can read feedback
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacks();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserPolicy")] // Both Admin and User can read specific feedback
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost]
        [Authorize(Policy = "UserPolicy")] // Only Users can create feedback
        public async Task<IActionResult> AddFeedback([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _feedbackService.AddFeedback(feedback);
            return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.FeedbackId }, feedback);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "UserPolicy")] // Only Users can update feedback
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] Feedback feedback)
        {
            if (id != feedback.FeedbackId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingFeedback = await _feedbackService.GetFeedbackById(id);
            if (existingFeedback == null)
            {
                return NotFound();
            }

            await _feedbackService.UpdateFeedback(feedback);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")] // Only Admins can delete feedback
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var existingFeedback = await _feedbackService.GetFeedbackById(id);
            if (existingFeedback == null)
            {
                return NotFound();
            }

            await _feedbackService.DeleteFeedback(id);
            return NoContent();
        }
    }
}
