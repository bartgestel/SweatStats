﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweatStats_Logic
{
    public interface IUserDAL
    {
        bool RegisterUser(string username, string password, string email);
    }
}
