using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Principal;
using BasicLoginProject.Classes;

namespace BasicLoginProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {


        }

        protected void Login_Click(object sender, EventArgs e)
        {
            //UserManagerController will validate the information inputed into the forms, cross compare that to the DB, which I do not have access to at the moment. However, we must assume there are no rules in place, aside from no nulls for the columns in users
            if (UserManagerController.ValidateUser(new User(username.Text, password.Text)))
            {

                //FormsAuthentication.RedirectFromLoginPage(username.Text, Persist.Checked);
                FormsAuthentication.SetAuthCookie(username.Text, Persist.Checked);
                Response.Redirect("Default.aspx");
            }
            else
            {
                msg.Text = "Invalid Credentials";
            }
        }
    }
}