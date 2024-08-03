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
    public partial class AssignScore : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                BindAssignScoreGrid();
            }
        }

        private void BindAssignScoreGrid()
        {
            using (SqlCommand cmd = new SqlCommand("GetTasksForScoring", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvAssignScore.DataSource = dt;
                gvAssignScore.DataBind();
            }
        }

        protected void gvAssignScore_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SaveScore")
            {
                int assignmentId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                TextBox txtScore = (TextBox)row.FindControl("txtScore");
                int score = Convert.ToInt32(txtScore.Text);

                UpdateTaskScore(assignmentId, score);
                BindAssignScoreGrid();
            }
        }

        private void UpdateTaskScore(int assignmentId, int score)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateTaskScore", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssignmentID", assignmentId);
                cmd.Parameters.AddWithValue("@Score", score);

                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Score updated successfully.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }

    }
}