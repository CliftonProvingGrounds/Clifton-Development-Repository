using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;

namespace BasicLoginProject.Classes
{
    public class Enigma
    {

        public static string CreateSalt(int size) {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] nerf = new byte[size];
            rng.GetBytes(nerf);
            return Convert.ToBase64String(nerf);
        }

        public static string PuffPuffHashPassword(string pwd, string extraFluffNoCrunch) {
            string AVAST = String.Concat(pwd, extraFluffNoCrunch);
            string hashedPwd =
                FormsAuthentication.HashPasswordForStoringInConfigFile(AVAST, FormsAuthPasswordFormat.MD5.ToString());
            return hashedPwd;
        }

        public static String CreateAtabashPassword(string pwd) {
            string ret = "";



            return null;
        }
    }
}