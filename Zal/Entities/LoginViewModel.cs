using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zal.Entities
{
    public class LoginViewModel
    {
        public string username { get; set; }
        public string password { get; set; }

        public LoginViewModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
