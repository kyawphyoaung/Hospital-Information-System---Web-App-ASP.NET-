using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class SaleReports : System.Web.UI.Page
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
            cmd.CommandText = "SELECT * FROM SaleReport";
            cmd.ExecuteNonQuery();
            con.Close();

            ddlStores.AppendDataBoundItems = true;
            ddlStores.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlStores.SelectedIndex = 0;

            ddlRange.AppendDataBoundItems = true;
            ddlRange.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlRange.SelectedIndex = 0;
        }
    }

    /* Display sale report based on the selected store */
    protected void DisplaySaleReport(object sender, EventArgs e)
    {
        string store = ddlStores.SelectedValue.ToString();

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM SaleReport WHERE Store = '" + store + "'";
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        gvSaleReport.DataSource = dt;
        gvSaleReport.DataBind();
        con.Close();
    }


    /* Display sale report based on the selected store within selected range */
    protected void RangeSelected(object sender, EventArgs e)
    {
        gvSaleReport.DataSource = null;
        gvSaleReport.DataBind();

        string store = ddlStores.SelectedValue.ToString();
        string range = ddlRange.SelectedValue.ToString();
        string todaydate = DateTime.Now.ToString();

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        if (range == "Today")
        {
            cmd.CommandText = "SELECT * FROM SaleReport WHERE Store = '" + store + "' AND IssuedDate = '" + todaydate + "'";
        }
        else if(range == "A Week")
        {
            cmd.CommandText = "SELECT * FROM SaleReport WHERE Store = '" + store + "' AND IssuedDate >= DATEADD(DD, -7, GETDATE()) AND IssuedDate < GETDATE()";
        }
        else if(range == "A Month")
        {
            cmd.CommandText = "SELECT * FROM SaleReport WHERE Store = '" + store + "' AND IssuedDate >= DATEADD(MM, -1, GETDATE()) AND IssuedDate < GETDATE()";
        }
        else if(range == "A Year")
        {
            cmd.CommandText = "SELECT * FROM SaleReport WHERE Store = '" + store + "' AND IssuedDate >= DATEADD(YY, -1, GETDATE()) AND IssuedDate < GETDATE()";
        }
        
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        gvSaleReport.DataSource = dt;
        gvSaleReport.DataBind();
        con.Close();
    }
}