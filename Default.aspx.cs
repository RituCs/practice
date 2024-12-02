using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Configuration;

namespace crud_first_version
{
    public partial class _Default : Page
    {
        //string connectionString = "Data Source=DESKTOP-ER2ICMK\\SQLEXPRESS;Initial Catalog=Crud_DB;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                unit.SelectedIndex = 0;
                GetProductList();
                ClearForm();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FieldValidation())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cruddb"].ConnectionString))
                    {
                        con.Open();

                        // Get input values
                        int productID = int.Parse(productid.Text);
                        string iname = itemname.Text;
                        string spec = specification.Text;
                        string unt = unit.SelectedValue;
                        string sta = status.SelectedValue;
                        DateTime cdate = DateTime.Parse(creationdate.Text);

                        // Use parameterized query to prevent SQL injection
                        using (SqlCommand cmd = new SqlCommand("exec ProductSetup_SP @ProductID, @ItemName, @Specification, @Unit, @Status, @CreationDate", con))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", productID);
                            cmd.Parameters.AddWithValue("@ItemName", iname);
                            cmd.Parameters.AddWithValue("@Specification", spec);
                            cmd.Parameters.AddWithValue("@Unit", unt);
                            cmd.Parameters.AddWithValue("@Status", sta);
                            cmd.Parameters.AddWithValue("@CreationDate", cdate);

                            // Execute the command
                            cmd.ExecuteNonQuery();
                        }

                        // Success message
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully inserted');", true);
                    }

                    // Refresh the product list
                    GetProductList();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('Error: {ex.Message}');", true);

                }
            }
        }

        void GetProductList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cruddb"].ConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("exec ProductList_SP", con))
                    {
                        SqlDataAdapter sd = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cruddb"].ConnectionString))
                {
                    con.Open();
                    int result;
                    // Get input values
                    int productID = int.Parse(productid.Text);
                    string iname = itemname.Text;
                    string spec = specification.Text;
                    string unt = unit.SelectedValue;
                    string sta = status.SelectedValue;
                    DateTime cdate = DateTime.Parse(creationdate.Text);

                    // Use parameterized query to prevent SQL injection
                    using (SqlCommand cmd = new SqlCommand("exec ProductUpdate_SP @ProductID, @ItemName, @Specification, @Unit, @Status, @CreationDate", con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productID);
                        cmd.Parameters.AddWithValue("@ItemName", iname);
                        cmd.Parameters.AddWithValue("@Specification", spec);
                        cmd.Parameters.AddWithValue("@Unit", unt);
                        cmd.Parameters.AddWithValue("@Status", sta);
                        cmd.Parameters.AddWithValue("@CreationDate", cdate);

                        // Execute the command
                        result = cmd.ExecuteNonQuery();
                    }

                    // Success message
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Prduct ID Not found');", true);

                    }
                }

                // Refresh the product list
                GetProductList();
                ClearForm();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('Error: {ex.Message}');", true);

            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cruddb"].ConnectionString))
                {
                    con.Open();

                    // Get input values
                    int productID = int.Parse(productid.Text);

                    // Use parameterized query to prevent SQL injection
                    using (SqlCommand cmd = new SqlCommand("exec ProductDelete_SP @ProductID", con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }

                    // Success message
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);

                }

                // Refresh the product list
                GetProductList();
                ClearForm();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('Error: {ex.Message}');", true);
            }
        }
    
        bool FieldValidation()
        {
            if (string.IsNullOrWhiteSpace(productid.Text) ||
                string.IsNullOrWhiteSpace(itemname.Text)|| 
                string.IsNullOrWhiteSpace(specification.Text) ||
               string.IsNullOrWhiteSpace(creationdate.Text) ||
               string.IsNullOrEmpty(status.SelectedValue) ||
               string.IsNullOrEmpty(unit.SelectedValue)
               )
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please fill all required field');", true);
                return false;
            }
            return true;
        }
        void ClearForm()
        {
            productid.Text = itemname.Text = specification.Text = creationdate.Text = "";
            unit.ClearSelection();
            unit.SelectedIndex = 0;
            status.ClearSelection();
        }
    
    
    
    }
}
