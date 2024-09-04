using LoginAPI.Core;
using LoginAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            return await _feedbackRepository.GetAllFeedbacks();
        }

        public async Task<Feedback> GetFeedbackById(int feedbackId)
        {
            return await _feedbackRepository.GetFeedbackById(feedbackId);
        }

        public async Task AddFeedback(Feedback feedback)
        {
            await _feedbackRepository.AddFeedback(feedback);
        }

        public async Task UpdateFeedback(Feedback feedback)
        {
            await _feedbackRepository.UpdateFeedback(feedback);
        }

        public async Task DeleteFeedback(int feedbackId)
        {
            await _feedbackRepository.DeleteFeedback(feedbackId);
        }
    }
}
