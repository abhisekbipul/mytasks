using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager
{
    public partial class LogIn : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both email and password.";
                return;
            }

            using (SqlCommand cmd = new SqlCommand("UserLogin", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    Session["UserID"] = reader["UserID"];
                    Session["UserRole"] = reader["Role"].ToString();

                    if (Session["UserRole"].ToString() == "Admin")
                    {
                        Response.Redirect("AdminDashboard.aspx");
                    }
                    else
                    {
                        Response.Redirect("UserDashboard.aspx");
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid email or password.";
                }
            }
        }
    }
}