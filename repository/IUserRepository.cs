using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);

    }

}
