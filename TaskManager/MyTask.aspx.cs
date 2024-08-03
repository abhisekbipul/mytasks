using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager
{
    public partial class MyTask : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                BindTasks();
            }
        }

        private void BindTasks()
        {
            int userId = Convert.ToInt32(Session["UserID"]);

            using (SqlCommand cmd = new SqlCommand("GetUserTask", conn))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvTasks.DataSource = dt;
                gvTasks.DataBind();
            }
        }
        protected void gvTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Submit")
            {
                int assignmentId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                FileUpload fuSolution = (FileUpload)row.FindControl("fuSolution");

                if (fuSolution.HasFile)
                {
                    string fileName = System.IO.Path.GetFileName(fuSolution.PostedFile.FileName);
                    string filePath = Server.MapPath("~/Uploads/Solutions/") + fileName;
                    fuSolution.SaveAs(filePath);

                    UpdateTaskSubmission(assignmentId, "~/Uploads/Solutions/" + fileName);
                }
            }
        }

        private void UpdateTaskSubmission(int assignmentId, string solutionPath)
        {

            using (SqlCommand cmd = new SqlCommand("UpdateTaskSubmission", conn))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssignmentID", assignmentId);
                cmd.Parameters.AddWithValue("@SolutionAttachment", solutionPath);
                cmd.Parameters.AddWithValue("@SubmissionDate", DateTime.Now);
                

                cmd.Parameters.Add("@IsLate", SqlDbType.Bit).Direction = ParameterDirection.Output;

                
                cmd.ExecuteNonQuery();
               

                bool isLate = Convert.ToBoolean(cmd.Parameters["@IsLate"].Value);
                string message = isLate ? "Task submitted late." : "Task submitted on time.";
                lblMessage.Text = message;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                BindTasks();
            }
        }
    }
}