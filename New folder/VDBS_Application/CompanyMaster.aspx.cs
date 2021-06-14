using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace VDBS_Application
{
    public partial class _CompanyMaster : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string fileName = "";//Path.GetFileName(FileUpload1.FileName);
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string fileName1 = Path.GetFileName(postedFile.FileName);
                fileName = fileName + ',' + fileName1;
            }
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-66MDSMA; Initial Catalog=VDBS_DB;Integrated Security=false;User ID=sa;Password=Test@123");
            SqlCommand cmd = new SqlCommand("sp_insertCompanyName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", txtCompanyName.Text);
            cmd.Parameters.AddWithValue("@fileName", fileName);
            con.Open();
            int k = cmd.ExecuteNonQuery();
            
            con.Close();
            txtCompanyName.Text = string.Empty;

        }
    }
}