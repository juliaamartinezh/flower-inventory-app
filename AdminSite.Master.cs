using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLAWAD
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //////// Prevent infinite redirect loop on the Login page  (The assistance of AI (CHATGPT) was used to check the code when the redirect to log in was not working)
            if (Request.Url.AbsolutePath.ToLower().Contains("login.aspx"))
                return;

            //////////////Check if user is logged (prevent access to pages without login not done)
            if (Session["user"] != null)
            {
                lblAdminName.Text = Session["user"].ToString();
            }
            else
            {
                //// Redirect to Login if user not found in session
                Response.Redirect("Login.aspx");
            }
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            // Clear session and redirect to the login page with the logout button
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}