using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager
{
    public partial class SignUp : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

        }

        protected void txtsignup_Click(object sender, EventArgs e)
        {
            string username = txtUname.Text;
            string fullname = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPass.Text;
            string confirmPassword = txtCPass.Text;
            int batch = int.Parse(ddlBatch.SelectedValue);

            if (password == confirmPassword)
            {
                    using (SqlCommand cmd = new SqlCommand("InsertUser", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@FullName", fullname);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Batch", batch);

                        
                        cmd.ExecuteNonQuery();
                        

                        lblMsg.Text = "User registered successfully.";
                    }
             }
            else
            {
                lblMsg.Text = "Passwords do not match.";
            }
        }
    }
}