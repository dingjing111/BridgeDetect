using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.entity
{
    class User
    {
        public string phid { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int rightLevel { get; set; }

        public User(string userName, string password, int rightLevel)
        {
            this.userName = userName;
            this.password = password;
            this.rightLevel = rightLevel;
        }

        public User(string userName, string password) : this(userName, password, 0)
        {
        }
    }
}
