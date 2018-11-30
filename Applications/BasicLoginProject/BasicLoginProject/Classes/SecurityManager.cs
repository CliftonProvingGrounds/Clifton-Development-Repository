using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BasicLoginProject.Classes
{
    public class SecurityManager : Enigma
    {
        public static bool VerifyCreds(string user, string pwd) {
            bool match = false;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBContextManager"].ConnectionString;

                SqlParameter u_name = new SqlParameter("@Username", user);                           

                SqlCommand cmd = new SqlCommand("GetUser");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.Add(u_name);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read(); // Advance to the one and only row
                               // Return output parameters from returned data stream
                string dbPasswordHash = reader["Password"].ToString();
                //this MUST BE CHANGED
                int saltSize = 9;
                string salt =
                  dbPasswordHash.Substring(dbPasswordHash.Length - saltSize);
                reader.Close();
                // Now take the password supplied by the user
                // and generate the hash.
                string hashedPasswordAndSalt =
                  PuffPuffHashPassword(pwd, salt);
                // Now verify them.
                match = hashedPasswordAndSalt.Equals(dbPasswordHash);
                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (conn != null){
                    conn.Close();
                }
            }
            return match;
        }

        public static bool VerifyCreds(User user)
        {
            return VerifyCreds(user.username, user.password);
        }

        public static void RegisterCreds(string username, string password) {
            try
            {
                //string salt = CreateSalt(7);
                string p_word_hash = PuffPuffHashPassword(password, CreateSalt(7));

                User ret = new User(username, p_word_hash,"Default");

                UserManagerController.AddUser(ret);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}