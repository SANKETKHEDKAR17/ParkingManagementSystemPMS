using LoginAPI.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Repository
{
    public interface IUserRepository
    {
        // Method to get all users
        IEnumerable<Users> GetAllUsers();

        // Method to authenticate a user by username and password
        Task<Users> GetUserByUsernameAndPasswordAsync(string username, string password);
    }
}
