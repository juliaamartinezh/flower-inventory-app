//The assistance of AI (CoPilot and ChatGPT) was used in this page//

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace FLAWAD
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This check ensures that the data is only loaded when the page is first opened,
            // and not every time a user interacts with it (like clicking sort or filter buttons)
            if (!IsPostBack)
            {
                LoadFlowers();      // loads all flowers with joined supplier data into GridView
                LoadSupplierNames(); // load supplier names for the filter dropdown
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // placeholder for future selection functionality (like: view details or edit record)
        }

        // loads all flowers and joins supplier info for display
        private void LoadFlowers()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query joins flower and supplier tables for comprehensive display
                string query = @"SELECT flw.FlwID, flw.FlwName, flw.FlwColour, flw.FlwPrice, flw.FlwStock, flw.FlwExpiry, flw.ImageFileName, suppliers.SupplierName
                                 FROM flw
                                 INNER JOIN suppliers ON flw.SupplierID = suppliers.SupplierID";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                GridViewFlowers.DataSource = reader;  // Bind sql results to the GridView
                GridViewFlowers.DataBind();
            }
        }

        // loads all supplier names to populate the filter dropdown
        private void LoadSupplierNames()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SupplierName FROM suppliers";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlSupplierFilter.DataSource = reader;           // use supplier names for filtering as instead of ID as it for a user the ID is less intuitive than a name 
                ddlSupplierFilter.DataTextField = "SupplierName";
                ddlSupplierFilter.DataValueField = "SupplierName";
                ddlSupplierFilter.DataBind();

                ddlSupplierFilter.Items.Insert(0, new ListItem("All", "All")); // add "All" options
            }
        }

        // Handles sorting the flower list by price (ascending/descending)
        protected void btnSort_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sortOrder = ddlSortPrice.SelectedValue; // allow user to select the order of filtering  ASC or DESC order

                string query = @"SELECT flw.FlwID, flw.FlwName, flw.FlwColour, flw.FlwPrice, flw.FlwStock, flw.FlwExpiry, flw.ImageFileName, suppliers.SupplierName
                                 FROM flw
                                 INNER JOIN suppliers ON flw.SupplierID = suppliers.SupplierID
                                 ORDER BY flw.FlwPrice " + sortOrder; // sorts  based on  user selection

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                GridViewFlowers.DataSource = reader; // showing the updated GridView with sorted data
                GridViewFlowers.DataBind();
            }
        }

        // filters flowers by selected supplier from the dropdown ( Manchester, Seoul, Riyadh, Granada and Vancouver suppliers based on the countries provided in the brief )
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string selectedSupplier = ddlSupplierFilter.SelectedValue; // Get selected supplier

                // starting with the query showing all flowers
                string query = @"SELECT flw.FlwID, flw.FlwName, flw.FlwColour, flw.FlwPrice, flw.FlwStock, flw.FlwExpiry, flw.ImageFileName, suppliers.SupplierName
                                 FROM flw
                                 INNER JOIN suppliers ON flw.SupplierID = suppliers.SupplierID";

                SqlCommand cmd;

                if (selectedSupplier != "All")
                {
                    // If user selected a specific supplier, add WHERE clause
                    query += " WHERE suppliers.SupplierName = @SupplierName";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SupplierName", selectedSupplier);
                }
                else
                {
                    // No filter needed
                    cmd = new SqlCommand(query, conn);
                }

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                GridViewFlowers.DataSource = reader; // Shows the filtered result
                GridViewFlowers.DataBind();
            }
        }
    }
}

