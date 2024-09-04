using LoginAPI.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Service
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<Feedback> GetFeedbackById(int feedbackId);
        Task AddFeedback(Feedback feedback);
        Task UpdateFeedback(Feedback feedback);
        Task DeleteFeedback(int feedbackId);
    }
}
