using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager
{
    public partial class AssignTask : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {

            }
        }

        private void BindUsers()
        {
           using (SqlCommand cmd = new SqlCommand("GetUsersByBatch", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Batch", ddlBatch.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlUsers.DataSource = dt;
                ddlUsers.DataTextField = "FullName";
                ddlUsers.DataValueField = "UserID";
                ddlUsers.DataBind();

                
                ddlUsers.Items.Insert(0, new ListItem("Select All", "0"));
            }
        }

        protected void btnAssignTask_Click(object sender, EventArgs e)
        {
            try
            {
                string taskName = txtTaskName.Text;
                string attachmentUrl = UploadAttachment();
                string batch = ddlBatch.SelectedValue;
                string[] selectedUsers = ddlUsers.SelectedValue.Split(',');

                
                int taskId = InsertTask(taskName, attachmentUrl, batch);

                foreach (string userId in selectedUsers)
                {
                    if (userId != "0")
                    {
                        AssignTaskToUser(Convert.ToInt32(userId), taskId, attachmentUrl);
                    }
                    else
                    {
                        AssignTaskToAllUsers(taskId, attachmentUrl, batch);
                    }
                }

                lblMessage.Text = "Task assigned successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green; // Optional: Set color for success
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red; // Optional: Set color for error
            }
        }

        private string UploadAttachment()
        {
            if (fileAttachment.HasFile)
            {
                string fileName = System.IO.Path.GetFileName(fileAttachment.PostedFile.FileName);
                string filePath = Server.MapPath("~/Uploads/") + fileName;
                fileAttachment.SaveAs(filePath);
                return "~/Uploads/" + fileName;
            }
            return null;
        }

        private int InsertTask(string taskName, string attachmentUrl, string batch)
        {
            int taskId;

            using (SqlCommand cmd = new SqlCommand("InsertTask", conn))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskName", taskName);
                cmd.Parameters.AddWithValue("@Attachment", attachmentUrl);
                cmd.Parameters.AddWithValue("@Batch", batch);
                cmd.Parameters.AddWithValue("@AssignedDate", DateTime.Now);
                SqlParameter outputIdParam = new SqlParameter("@TaskID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);
                cmd.ExecuteNonQuery();
                taskId = (int)outputIdParam.Value;
            }
            return taskId;
        }
        private void AssignTaskToUser(int userId, int taskId, string attachmentUrl)
        {
            using (SqlCommand cmd = new SqlCommand("AssignTaskToUser", conn))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Attachment", attachmentUrl);
                cmd.Parameters.AddWithValue("@AssignedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsLate", 0); // Default to 0 (Not Late)
                cmd.ExecuteNonQuery();
            }
        }

        private void AssignTaskToAllUsers(int taskId, string attachmentUrl, string batch)
        {
            using (SqlCommand cmd = new SqlCommand("AssignTaskToAllUsers", conn))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                cmd.Parameters.AddWithValue("@Attachment", attachmentUrl);
                cmd.Parameters.AddWithValue("@Batch", batch);
                cmd.Parameters.AddWithValue("@AssignedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsLate", 0); // Default to 0 (Not Late)          
                cmd.ExecuteNonQuery();              
            }
        }

        protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUsers();
        }
    }
}