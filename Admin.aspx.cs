using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLAWAD
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack && Session["user"] != null)
            {
                // Set the label to show the username stored in session 
                lblUser.Text = Session["user"].ToString();
            }

        }
    }
}