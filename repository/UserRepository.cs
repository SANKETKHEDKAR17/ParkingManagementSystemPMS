using Dapper;
using Domain;

namespace infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "SELECT * FROM Users WHERE Username = @Username";
                // return await connection.QueryFirstOrDefaultAsync<User>(sql, new { username });
                return await connection.QueryFirstOrDefaultAsync<User>(sql, new { username });
            }
        }



    }
}


