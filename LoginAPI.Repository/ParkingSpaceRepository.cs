using Dapper;
using LoginAPI.Core;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Repository
{
    public class ParkingSpaceRepository : IParkingSpaceRepository
    {
        private readonly string _connectionString;

        public ParkingSpaceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ParkingSpace>> GetAllParkingSpaces()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<ParkingSpace>("SELECT * FROM ParkingSpace");
            }
        }

        public async Task<ParkingSpace> GetParkingSpaceById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<ParkingSpace>("SELECT * FROM ParkingSpace WHERE ParkingSpaceID = @Id", new { Id = id });
            }
        }

        public async Task AddParkingSpace(ParkingSpace parkingSpace)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO ParkingSpace (Location, Status) VALUES (@Location, @Status)";
                await connection.ExecuteAsync(query, parkingSpace);
            }
        }

        public async Task UpdateParkingSpace(ParkingSpace parkingSpace)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE ParkingSpace SET Location = @Location, Status = @Status WHERE ParkingSpaceID = @ParkingSpaceID";
                await connection.ExecuteAsync(query, parkingSpace);
            }
        }

        public async Task DeleteParkingSpace(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM ParkingSpace WHERE ParkingSpaceID = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
