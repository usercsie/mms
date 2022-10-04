using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Controller
{
    public class LoginController
    {
        private readonly string _ManagerPassword = "Tiger@2021";

        public string[] AvailableUsers
        {
            get
            {
                return Enum.GetNames(typeof(LoginUser));
            }
        }

        public bool Login(LoginUser user, string password)
        {
            if (user == LoginUser.Viewer)
            {
                return true;
            }
            else
            {
                return password == _ManagerPassword;
            }
        }
    }
}
