namespace Domain
{


    public class User : IUser
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        private User(int id, string username, string passwordHash, string email, string phoneNumber)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public static User Create(string username, string passwordHash, string email, string phoneNumber)
        {
            return new User(0, username, passwordHash, email, phoneNumber);
        }
    }
}