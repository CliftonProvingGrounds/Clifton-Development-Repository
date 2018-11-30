using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BasicLoginProject.Classes
{
    public class UserManager
    {
        public static bool AddUser(User user)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBContextManager"].ConnectionString;

                SqlParameter u_name = new SqlParameter("@Username", user.username);
                SqlParameter p_word = new SqlParameter("@Password", user.password);
                SqlParameter u_role = new SqlParameter("@Roles", user.role);

                SqlCommand cmd = new SqlCommand("AddUser");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.Add(u_name);
                cmd.Parameters.Add(p_word);
                cmd.Parameters.Add(u_role);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        }

        public static string GetRoles(String username)
        {
            SqlDataReader reader;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBContextManager"].ConnectionString;
            SqlParameter u_name = new SqlParameter("@Username", username);

            SqlCommand cmd = new SqlCommand("GetRoles");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.Add(u_name);

            conn.Open();
            reader = cmd.ExecuteReader();
            //this is quite useful
            //conn.Close();

            //return (reader.Read() != false) ? 
            //   new User(reader["Username"].ToString(), reader["password"].ToString()):
            //   null;

            string ret = null;
            while (reader.Read() != false)
            {
                ret = reader["Roles"].ToString();
            }
            conn.Close();
            return ret;
        }


        public static bool AddUser(string username, string password )
        {
            AddUser(new Classes.User(username, password, "Default"));
            return false;
        }

        public static User GetUser(String username)
        {
            SqlDataReader reader;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBContextManager"].ConnectionString;

            SqlParameter u_name = new SqlParameter("@Username",username);

            SqlCommand cmd = new SqlCommand("GetUser");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.Add(u_name);

            conn.Open();
            reader = cmd.ExecuteReader();
            //this is quite useful
            //conn.Close();

            //return (reader.Read() != false) ? 
            //   new User(reader["Username"].ToString(), reader["password"].ToString()):
            //   null;

            User ret = null;
            while (reader.Read() != false)
            {
                ret = new User(reader["Username"].ToString(), reader["Password"].ToString(), GetRoles(username));
            }
            conn.Close();
            return ret;
        }

        public static List<User> GetUsers()
        {
            List<User> ret = new List<User>();
            try
            {
                SqlDataReader reader;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBContextManager"].ConnectionString;

                SqlCommand cmd = new SqlCommand("GetUsers");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conn;

                conn.Open();
                reader = cmd.ExecuteReader();
                //this is quite useful
                //Need to clean up this section to PROPERLY iterate Through a data reader
                User user = null;
                if(reader.HasRows)
                    while (reader.Read() != false)
                    {
                        user = new User(reader["Username"].ToString(), reader["Password"].ToString(), reader["Roles"].ToString());
                        ret.Add(user);
                    }
                conn.Close();
                return ret;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

    }
}