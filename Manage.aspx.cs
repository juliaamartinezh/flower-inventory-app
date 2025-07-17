
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
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////  load the supplier ID dropdown list from the database
            if (!IsPostBack)
            {
                LoadSupplierIDs();  // used to ensure that dropdown data is only fetched once to avoid refreshing on every button click
            }
        }

        ///// loads all Supplier IDs from the suppliers table and binds them to the  dropDownList
        private void LoadSupplierIDs()
        {
            ///// retrieve the database connection string from Web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            //// connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // sql query to retrieve all SupplierIDs
                string query = "SELECT SupplierID FROM suppliers";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open(); /////// open the database connection

                ////// joins  the supplier id  to the dropdown
                ddlSupplierID.DataSource = cmd.ExecuteReader(); // pulls the data into the dropdown from DB
                ddlSupplierID.DataTextField = "SupplierID"; // what is shown to the user
                ddlSupplierID.DataValueField = "SupplierID"; // what is stored internally
                ddlSupplierID.DataBind(); // binds the data to the dropdown list
            }
        }

        // adds a new flower record into the flw table based on the form input
        protected void btnAddFlower_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // sql insert query from flw table
                    string query = @"INSERT INTO flw (FlwID, FlwName, FlwColour, FlwPrice, FlwStock, FlwExpiry, ImageFileName, SupplierID)
                                     VALUES (@FlwID, @FlwName, @FlwColour, @FlwPrice, @FlwStock, @FlwExpiry, @ImageFileName, @SupplierID)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // collect values from form controls and add them as sql functions (column names were used to prompt copilot into creating the rest of the lines based on the flw table headings)
                    cmd.Parameters.AddWithValue("@FlwID", int.Parse(txtFlwID.Text)); // parse to int because FlwID is int in database
                    cmd.Parameters.AddWithValue("@FlwName", txtFlwName.Text);
                    cmd.Parameters.AddWithValue("@FlwColour", txtFlwColour.Text);
                    cmd.Parameters.AddWithValue("@FlwPrice", txtFlwPrice.Text);
                    cmd.Parameters.AddWithValue("@FlwStock", txtFlwStock.Text);
                    cmd.Parameters.AddWithValue("@FlwExpiry", txtFlwExpiry.Text);
                    cmd.Parameters.AddWithValue("@ImageFileName", txtImageFileName.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", ddlSupplierID.SelectedValue);

                    conn.Open(); //// open the database connection
                    cmd.ExecuteNonQuery(); ///// execute the insert command

                    lblMessage.Text = "Flower added successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    ClearFormFields(); //// clear fields to prepare for new entry
                    imgFlower.Visible = false; // command allows to hide the image after action
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // deletes a flower from the database using the  flw id 
        protected void btnDeleteFlower_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // delete query to delete records
                    string query = "DELETE FROM flw WHERE FlwID = @FlwID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FlwID", int.Parse(txtFlwID.Text)); // again using parse because FlwID is int

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery(); // get message of the number of affected rows

                    if (rows > 0)
                    {
                        lblMessage.Text = "Flower deleted successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        ClearFormFields(); //clears the form after the deletion of records
                        imgFlower.Visible = false;
                    }
                    else
                    {
                        lblMessage.Text = "No flower found with that ID."; //tells the user no flowers found with that id with a message
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        imgFlower.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // retrieves a flower record by id and displays the info in the form
        protected void btnRetrieveFlower_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM flw WHERE FlwID = @FlwID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FlwID", int.Parse(txtFlwID.Text));

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) ///// if the flower is found
                {
                    //// populate form fields with db values
                    txtFlwName.Text = reader["FlwName"].ToString();
                    txtFlwColour.Text = reader["FlwColour"].ToString();
                    txtFlwPrice.Text = reader["FlwPrice"].ToString();
                    txtFlwStock.Text = reader["FlwStock"].ToString();
                    txtFlwExpiry.Text = reader["FlwExpiry"].ToString();
                    txtImageFileName.Text = reader["ImageFileName"].ToString();
                    ddlSupplierID.SelectedValue = reader["SupplierID"].ToString();

                    // load image using file name
                    string imageFile = reader["ImageFileName"].ToString();
                    imgFlower.ImageUrl = ResolveUrl("~/Imagesflw/" + imageFile);
                    imgFlower.Visible = true;

                    lblMessage.Text = "Flower retrieved successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Flower not found.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    imgFlower.Visible = false;
                }

                reader.Close();
            }
        }

        // updates a flower record based on form input and flw id
        protected void btnUpdateFlower_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // sql update query
                    string query = @"UPDATE flw SET 
                                        FlwName = @FlwName,
                                        FlwColour = @FlwColour,
                                        FlwPrice = @FlwPrice,
                                        FlwStock = @FlwStock,
                                        FlwExpiry = @FlwExpiry,
                                        ImageFileName = @ImageFileName,
                                        SupplierID = @SupplierID
                                     WHERE FlwID = @FlwID";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // pass form values to a query
                    cmd.Parameters.AddWithValue("@FlwID", int.Parse(txtFlwID.Text));
                    cmd.Parameters.AddWithValue("@FlwName", txtFlwName.Text);
                    cmd.Parameters.AddWithValue("@FlwColour", txtFlwColour.Text);
                    cmd.Parameters.AddWithValue("@FlwPrice", txtFlwPrice.Text);
                    cmd.Parameters.AddWithValue("@FlwStock", txtFlwStock.Text);
                    cmd.Parameters.AddWithValue("@FlwExpiry", txtFlwExpiry.Text);
                    cmd.Parameters.AddWithValue("@ImageFileName", txtImageFileName.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", ddlSupplierID.SelectedValue);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        lblMessage.Text = "Flower updated successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "No flower found with that ID.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // clears all input fields to make it easier to enter new records or reset by button
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearFormFields(); // reuse same logic to clear fields as the other actions
            lblMessage.Text = "form reset.";
            lblMessage.ForeColor = System.Drawing.Color.Gray;
            imgFlower.Visible = false; // hides image in case one was showing from retrieve
        }

        // Resets the input fields to blank for a new entry
        private void ClearFormFields()
        {
            txtFlwID.Text = "";
            txtFlwName.Text = "";
            txtFlwColour.Text = "";
            txtFlwPrice.Text = "";
            txtFlwStock.Text = "";
            txtFlwExpiry.Text = "";
            txtImageFileName.Text = "";
            ddlSupplierID.ClearSelection();
        }
    }
}


