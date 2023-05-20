using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class NearExpiry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from Items where Expiry >= GETDATE() AND Expiry <= DATEADD(MM, 6, GETDATE())";

            SqlDataReader dr = cmd.ExecuteReader();
            gvReorderLevel.DataSource = dr;
            gvReorderLevel.DataBind();
            con.Close();
        }
    }

    protected void BackToReports(object sender, EventArgs e)
    {
        Response.Redirect("InventoryReports.aspx");
    }
}