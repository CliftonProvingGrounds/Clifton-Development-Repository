using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicLoginProject.Classes
{
    /*
     * This Method is the best method. It is the most secure method I have ever seen... Aside from an unknow alternative
     */
    public class User
    {
        public String username { get; set; }
        public String password { get; set; }
        //I don't like having a SET method for role, but sol long as the database does not get it persisted right now, it's fine
        public String role { get; set; }

        //empty constructor, used for Object Casting
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

        public override bool Equals(object obj)
        {
            //Casting Variable as Type User
            var user = obj as User;

            //much easier to call this rather than an alternative single line call
            if (user == null)
            {
                return false;
            }

            return (this.username.Equals(user.username) && this.password.Equals(user.password));
        }

        //Simple one line solution, but it will probably break.
        public bool Equals_V2(Object obj)
        {
            var user = obj as User;

            return (user == null) ? false : (this.username.Equals(user.username) && this.password.Equals(user.password)) ;
        }
    }
}