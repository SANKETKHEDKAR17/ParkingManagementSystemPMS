using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUser
    {
        int Id { get; }
        string Username { get; }
        string PasswordHash { get; }
        string Email { get; }
        string PhoneNumber { get; }
    }
}
