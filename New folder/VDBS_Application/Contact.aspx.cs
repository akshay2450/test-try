using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace VDBS_Application
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                        new DataColumn("Name", typeof(string)),
                        new DataColumn("Country",typeof(string)) });
                dt.Rows.Add(1, "John Hammond", "United States");
                dt.Rows.Add(2, "Mudassar Khan", "India");
                dt.Rows.Add(3, "Suzanne Mathews", "France");
                dt.Rows.Add(4, "Robert Schidner", "Russia");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Reference the GridView Row using RowIndex from CommandArgument.
            GridViewRow selectedRow = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];

            //Fetch values from BoundField columns.
            lblId.Text = selectedRow.Cells[0].Text;
            lblName.Text = selectedRow.Cells[1].Text;

            //Fetch values from TemplateField columns.
            lblCountry.Text = (selectedRow.FindControl("lblCountry") as Label).Text;

            //Display the ModalPopup.
            mpe.Show();
        }
    }
}