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
    public partial class DateWisePerformers : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime fromDate, toDate;

            if (DateTime.TryParse(txtFromDate.Text, out fromDate) && DateTime.TryParse(txtToDate.Text, out toDate))
            {
                lblMessage.Text = "";
                BindTopPerformersByDateGrid(fromDate, toDate);
            }
            else
            {
                lblMessage.Text = "Please enter valid dates.";
            }
        }


        private void BindTopPerformersByDateGrid(DateTime fromDate, DateTime toDate)
        {
            using (SqlCommand cmd = new SqlCommand("GetTopScorersByDate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvTopPerformersByDate.DataSource = dt;
                gvTopPerformersByDate.DataBind();
            }
        }
    }
}