using BasicLoginProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicLoginProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomPrincipal cp = HttpContext.Current.User as CustomPrincipal;
            Response.Write("Authenticated Identity is: " +
                            cp.Identity.Name);
            Response.Write("<p>");

            if (cp.IsInRole("Admin"))
            {
                Response.Write(cp.Identity.Name + " is in the " + "Senior Manager Role" );
              
                Response.Write("<p>");
            }

            if (cp.IsInAnyRoles("Admin, Standard, Basic, Debug"))
            {
                Response.Write(cp.Identity.Name + " is in one of the specified roles");
            
                Response.Write("<p>");
            }
            
            else
            {
                Response.Write(cp.Identity.Name +
                                " is not in ALL of the specified roles");
                Response.Write("<p>");
            }

            if (cp.IsInRole("Standard"))
                Response.Write("User is in Sales role<p>");
            else
                Response.Write("User is not in Sales role<p>");

            Welcome.Text = "Welcome Home, "+Context.User.Identity.Name;
        }

        protected void Sign_Out(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
        }
    }
}