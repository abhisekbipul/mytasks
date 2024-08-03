using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager
{

    public partial class ReTask : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                BindReTasks();
            }
        }

        private void BindReTasks()
        {
            using (SqlCommand cmd = new SqlCommand("GetReTasks", conn))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvReTasks.DataSource = dt;
                gvReTasks.DataBind();
            }
        }
        protected void gvReTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ReSubmit")
            {
                int assignmentId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                FileUpload fuSolution = (FileUpload)row.FindControl("fuSolution");
                if (fuSolution.HasFile)
                {
                    string solutionPath = SaveSolutionFile(fuSolution);
                    UpdateTaskSubmission(assignmentId, solutionPath);
                    BindReTasks();
                }
            }
        }

        private string SaveSolutionFile(FileUpload fileUpload)
        {
            string fileName = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);
            string filePath = "Uploads/Solutions/" + fileName;
            fileUpload.PostedFile.SaveAs(Server.MapPath(filePath));
            return filePath;
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
                string message = isLate ? "Task resubmitted late." : "Task resubmitted on time.";
                lblMessage.Text = message;
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}