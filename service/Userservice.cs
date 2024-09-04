using System.Collections.Generic;

namespace service
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IUser> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || !VerifyPassword(user.PasswordHash, password)) // Implement password verification
            {
                return null;
            }

            return user;
        }
    }


}
