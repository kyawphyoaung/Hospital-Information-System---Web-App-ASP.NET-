using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

public partial class StockLedger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            ddlStores.AppendDataBoundItems = true;
            ddlStores.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlStores.SelectedIndex = 0;
        }
    }

    protected void DisplayStockLedger(object sender, EventArgs e)
    {
        string store = ddlStores.SelectedValue.ToString();

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM StockLedger WHERE Store = '" + store + "'";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        gvStockLedger.DataSource = dt;
        gvStockLedger.DataBind();
        con.Close();
    }

    protected void gvStockLedger_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStockLedger.PageIndex = e.NewPageIndex;

        string store = ddlStores.SelectedValue.ToString();

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM StockLedger WHERE Store = '" + store + "'";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        gvStockLedger.DataSource = dt;
        gvStockLedger.DataBind();
        con.Close();
    }

    protected void BackToInventoryReports(object sender, EventArgs e)
    {
        Response.Redirect("InventoryReports.aspx");
    }

    protected void BackToMain(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}