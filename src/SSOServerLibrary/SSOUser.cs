using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSOServerLibrary
{
    public class SSOUser : ISSOUser
    {
        private string uid;
        public string Uid
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
