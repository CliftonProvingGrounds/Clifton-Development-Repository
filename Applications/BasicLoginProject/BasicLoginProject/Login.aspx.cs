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
            if (UserManagerController.ValidateUser(new User(
                username.Text, password.Text)
                ))
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