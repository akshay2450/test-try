using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VDBS_Application
{
    public partial class CompanyViewPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                companyDetails.Visible = false;
                Bind();
                
            }
        }

        protected void Bind()
        {
            string results = "";
            SqlDataAdapter dbRdr = new SqlDataAdapter();
            SqlCommand dbCmd = null;
            DataSet dsData = new DataSet();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-66MDSMA; Initial Catalog=VDBS_DB;Integrated Security=false;User ID=sa;Password=Test@123");

            try
            {
                con.Open();
                dbCmd = new SqlCommand();
                dbCmd.Connection = con;
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "sp_GETCompanyName";

                dbRdr.SelectCommand = dbCmd;
                dbRdr.Fill(dsData);

                con.Close();

                GridView1.DataSource = dsData.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnDisapprove_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-66MDSMA; Initial Catalog=VDBS_DB;Integrated Security=false;User ID=sa;Password=Test@123");
                SqlCommand cmd = new SqlCommand("sp_UpdateCompanyName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", 0);
                cmd.Parameters.AddWithValue("@CompanyID", Convert.ToInt32(txtCompanyID.Text));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                companyDetails.Visible = false;
                Clear();
                Bind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-66MDSMA; Initial Catalog=VDBS_DB;Integrated Security=false;User ID=sa;Password=Test@123");
                SqlCommand cmd = new SqlCommand("sp_UpdateCompanyName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", 1);
                cmd.Parameters.AddWithValue("@CompanyID", Convert.ToInt32(txtCompanyID.Text));
                con.Open();
                cmd.ExecuteNonQuery();
                companyDetails.Visible = false;
                Clear();
                Bind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Clear()
        {
            txtCompanyID.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtFileUploadName.Text = string.Empty;
        }
        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[rowIndex];
                txtCompanyID.Text = (row.FindControl("lblCompanyID") as Label).Text;
                txtCompanyName.Text = row.Cells[1].Text;
                txtFileUploadName.Text = row.Cells[2].Text;
                string status = row.Cells[3].Text;
                companyDetails.Visible = true;
                if(status=="False")
                {
                    btnDisapprove.Enabled = false;
                }
                else
                {
                    btnDisapprove.Enabled = true;
                }
            }
        }

    }
}