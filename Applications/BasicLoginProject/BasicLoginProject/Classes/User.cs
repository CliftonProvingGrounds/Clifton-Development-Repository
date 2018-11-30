using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicLoginProject.Classes
{
    /*This Method is the best method. It is the most secure method I have ever seen*/
    public class User
    {

        public User() { }

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
            this.role = "";
        }

        public User(String username, String password, String role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public String username { get; set; }
        public String password { get; set; }

        public String role { get; set; }
        public override bool Equals(object obj)
        {
            var user = obj as User;

            if (user == null)
            {
                return false;
            }

            return (this.username.Equals(user.username) && this.password.Equals(user.password));
        }
    }
}