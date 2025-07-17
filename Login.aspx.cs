using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLAWAD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Prevent loggedin users from accessing login page again
            if (Session["user"] != null)
            {
                Response.Redirect("Admin.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ///////// EF1 Basic hardcoded credential 
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin123")
            {
                Session["user"] = "admin"; ////// Track login state
                Response.Redirect("Admin.aspx"); ////////Redirect to admin
            }
            else
            {
                lblMessage.Text = "INVALID LOGIN CREDENTIALS"; 
            }
        }
    }
}