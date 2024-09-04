using LoginAPI.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Repository
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<Feedback> GetFeedbackById(int feedbackId);
        Task AddFeedback(Feedback feedback);
        Task UpdateFeedback(Feedback feedback);
        Task DeleteFeedback(int feedbackId);
    }
}
