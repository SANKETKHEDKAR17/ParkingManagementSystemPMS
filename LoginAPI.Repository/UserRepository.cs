using Dapper;
using LoginAPI.Core;
using LoginAPI.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LoginAPIDbContext _context;

        #region SQL Queries
        private const string VerifyUserQuery = @"
            SELECT * 
            FROM Users 
            WHERE Username = @Username AND Passwords = @Passwords";

        private const string GetAllUsersQuery = "SELECT * FROM Users";
        #endregion

        public UserRepository(LoginAPIDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Users>(GetAllUsersQuery);
            }
        }
        //abc
        public async Task<Users> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Users>(VerifyUserQuery, new { Username = username, Passwords = password });
            }
        }
    }
}
