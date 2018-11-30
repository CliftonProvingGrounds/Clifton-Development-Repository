using BasicLoginProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace BasicLoginProject
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            int n = 9;
            UserManagerController.AddUser(new User("admin@mail.com",Enigma.PuffPuffHashPassword("Institute",Enigma.CreateSalt(n)),"Admin"));
            UserManagerController.AddUser(new User("tester@mail.com", Enigma.PuffPuffHashPassword("Tester", Enigma.CreateSalt(n)), "Default"));
            UserManagerController.AddUser(new User("robot@wut.com", Enigma.PuffPuffHashPassword("Robot", Enigma.CreateSalt(n)), "Debug"));

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string cookie = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[cookie];
            if (null == authCookie)
            {
                // There is no authentication cookie.
                return;
            }
            //instantiates a null authTicket, easier for null checks 
            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception ex)
            {
                // Log exception details (omitted for simplicity)
                return;
            }

            if (null == authTicket)
            {
                // Cookie failed to decrypt.
                return;
            }

            // When the ticket was created, the UserData property was assigned a
            // pipe delimited string of role names.
            string[] roles = authTicket.UserData.Split('|');

            // Create an Identity object
            FormsIdentity id = new FormsIdentity(authTicket);

            // This principal will flow throughout the request.
            CustomPrincipal principal = new CustomPrincipal(id, roles);
            // Attach the new principal object to the current HttpContext object
            Context.User = principal;
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}