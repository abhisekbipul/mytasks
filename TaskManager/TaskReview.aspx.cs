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
    public partial class TaskReview : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                BindTaskReviewGrid();
            }
        }

        private void BindTaskReviewGrid()
        {
            using (SqlCommand cmd = new SqlCommand("GetTaskAssignmentsForReview", conn))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvTaskReview.DataSource = dt;
                gvTaskReview.DataBind();
            }
        }

        protected void gvTaskReview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ApproveTask")
            {
                int assignmentId = Convert.ToInt32(e.CommandArgument);
                UpdateTaskStatus(assignmentId, "Approved", null);
                BindTaskReviewGrid();
            }
            else if (e.CommandName == "RejectTask")
            {
                int assignmentId = Convert.ToInt32(e.CommandArgument);
                ShowRejectionPopup(assignmentId);
            }

        }

        private void ShowRejectionPopup(int assignmentId)
        {
            hfAssignmentID.Value = assignmentId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showPopup", "showRejectionPopup();", true);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int assignmentId = Convert.ToInt32(hfAssignmentID.Value);
            string rejectionReason = txtRejectionReason.Text;
            UpdateTaskStatus(assignmentId, "Rejected", rejectionReason);
            BindTaskReviewGrid();
        }

        private void UpdateTaskStatus(int assignmentId, string taskStatus, string rejectionReason)
        {

            using (SqlCommand cmd = new SqlCommand("UpdateTaskStatus", conn))
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssignmentID", assignmentId);
                cmd.Parameters.AddWithValue("@Status", taskStatus);
                if (rejectionReason != null)
                {
                    cmd.Parameters.AddWithValue("@RejectionReason", rejectionReason);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }
}