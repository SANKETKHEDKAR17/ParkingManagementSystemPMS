using LoginAPI.Core;
using LoginAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginAPI.Service
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Get all users
        public IEnumerable<Users> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        // Authenticate user by username and password
        public async Task<Users> AuthenticateAsync(string username, string password)
        {
            return await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);
        }

        public async Task<Users> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);

            if (user == null)
                return null;

            // The role should already be part of the user object if retrieved properly
            return user;
        }




    }
}
