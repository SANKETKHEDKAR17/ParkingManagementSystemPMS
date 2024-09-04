using LoginAPI.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Service
{
    public interface IUserService
    {
        // Method to authenticate a user by username and password
        Task<Users> AuthenticateAsync(string username, string password);

        // Method to get all users
        IEnumerable<Users> GetAllUsers();
    }
}
