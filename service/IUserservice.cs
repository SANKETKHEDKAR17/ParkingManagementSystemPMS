﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public interface IUserService
    {
        Task<IUser> AuthenticateAsync(string username, string password);
    }
}


