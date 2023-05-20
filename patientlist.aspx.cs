using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class patientlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        showlist();
    }
    public void showlist()
    {
        SqlConnection com = new SqlConnection();
        com.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        com.Open();

        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = new SqlCommand();
        adp.SelectCommand.Connection = com;
        adp.SelectCommand.CommandText = "SELECT * FROM Patients";

        DataSet ds = new DataSet();
        adp.Fill(ds);

        gv.DataSource = ds.Tables[0];
        gv.DataBind();
    }
    public void SelChanged(object sender, EventArgs e)
    {
        string patientID = gv.SelectedRow.Cells[1].Text;

        Response.Redirect("EditRegisteredPatient.aspx?patientID="+patientID);
    }
    public void refershall(object sender, EventArgs e)
    {
        showlist();
    }
    public void backhome(object sender, EventArgs e)
    {
        Response.Redirect("registration.aspx");
    }
}