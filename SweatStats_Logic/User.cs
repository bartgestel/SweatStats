using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SweatStats_Logic
{

    public class User
    {
        public IUserDAL Dal { get; }
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public User(IUserDAL dal)
        {
            Dal = dal;
        }

        public bool RegisterUser(string username, string password, string email)
        {
            Dal.RegisterUser(username, password, email);
            return true;
        }
    }
}
