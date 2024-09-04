using Dapper;
using LoginAPI.Core;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly string _connectionString;

        public ReservationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Reservation>("SELECT * FROM Reservation");
            }
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<Reservation>("SELECT * FROM Reservation WHERE ReservationID = @Id", new { Id = id });
            }
        }

        public async Task AddReservation(Reservation reservation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Reservation (UserID, ParkingSpaceID, StartTime, EndTime) VALUES (@UserID, @ParkingSpaceID, @StartTime, @EndTime)";
                await connection.ExecuteAsync(query, reservation);
            }
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Reservation SET UserID = @UserID, ParkingSpaceID = @ParkingSpaceID, StartTime = @StartTime, EndTime = @EndTime WHERE ReservationID = @ReservationID";
                await connection.ExecuteAsync(query, reservation);
            }
        }

        public async Task DeleteReservation(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Reservation WHERE ReservationID = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
