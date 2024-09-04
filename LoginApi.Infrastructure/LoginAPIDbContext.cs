using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LoginAPI.Infrastructure
{
    public class LoginAPIDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public LoginAPIDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ParkingManagementSystem");
        }

        // Method to create a new database connection
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
