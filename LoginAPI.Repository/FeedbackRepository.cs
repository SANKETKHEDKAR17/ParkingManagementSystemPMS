using Dapper;
using LoginAPI.Core;
using LoginAPI.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly LoginAPIDbContext _context;

        public FeedbackRepository(LoginAPIDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            var query = "SELECT * FROM Feedback";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Feedback>(query);
            }
        }

        public async Task<Feedback> GetFeedbackById(int feedbackId)
        {
            var query = "SELECT * FROM Feedback WHERE FeedbackId = @FeedbackId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Feedback>(query, new { FeedbackId = feedbackId });
            }
        }

        public async Task AddFeedback(Feedback feedback)
        {
            var query = "INSERT INTO Feedback (UserId, FeedbackText, Rating, CreatedAt) VALUES (@UserId, @FeedbackText, @Rating, @CreatedAt)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, feedback);
            }
        }

        public async Task UpdateFeedback(Feedback feedback)
        {
            var query = "UPDATE Feedback SET UserId = @UserId, FeedbackText = @FeedbackText, Rating = @Rating, CreatedAt = @CreatedAt WHERE FeedbackId = @FeedbackId";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, feedback);
            }
        }

        public async Task DeleteFeedback(int feedbackId)
        {
            var query = "DELETE FROM Feedback WHERE FeedbackId = @FeedbackId";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { FeedbackId = feedbackId });
            }
        }
    }
}
