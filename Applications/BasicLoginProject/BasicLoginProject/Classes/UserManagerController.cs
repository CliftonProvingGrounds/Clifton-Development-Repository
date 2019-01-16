using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BasicLoginProject.Classes
{
    public class UserManagerController
    {

        public static bool AddUser(String username, String password)
        {
            //encrypt your shit
            return AddUser(new User(username, password, "Default"));
        }

        public static bool AddUser(User user)
        {
            try
            {
                return UserManager.AddUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }



        //needs to be updated
        public static bool ValidateUser(User user) {
            List<User> ret = null;
            try
            {
                ret = UserManager.GetUsers();
                //this is one of three approachs to logging in a user, the other two are a direct sql command, or checking the results of GetUser manually form this function.
                return SecurityManager.VerifyCreds(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false ;
            }
        }

        public static bool ValidateUserV2(User user) {
            return false;
        }

    }
}