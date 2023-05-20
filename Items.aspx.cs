using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Items : System.Web.UI.Page
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
            cmd.CommandText = "SELECT * FROM Items WHERE Material = '' ";
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gvItems.DataSource = dt;
            gvItems.DataBind();
        }
    }

    protected void MaterialsChecked(object sender, EventArgs e)
    {
        string materials = "Materials";

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        DataTable dt = new DataTable();

        if (chkMaterial.Checked)
        {
            cmd.CommandText = "SELECT * FROM Items WHERE Material = '" + materials + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            gvItems.DataSource = null;
            gvItems.DataBind();
            gvMaterials.DataSource = dt;
            gvMaterials.DataBind();
        }
        else
        {
            cmd.CommandText = "SELECT * FROM Items WHERE Material = '' ";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            gvMaterials.DataSource = null;
            gvMaterials.DataBind();
            gvItems.DataSource = dt;
            gvItems.DataBind();
        }
        con.Close();
    }

    protected void gvItems_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItems.PageIndex = e.NewPageIndex;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Items WHERE Material = '' ";
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        gvItems.DataSource = dt;
        gvItems.DataBind();
    }

    protected void gvMaterials_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMaterials.PageIndex = e.NewPageIndex;

        string materials = "Materials";

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        DataTable dt = new DataTable();

        if (chkMaterial.Checked)
        {
            cmd.CommandText = "SELECT * FROM Items WHERE Material = '" + materials + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            gvItems.DataSource = null;
            gvItems.DataBind();
            gvMaterials.DataSource = dt;
            gvMaterials.DataBind();
        }
        else
        {
            cmd.CommandText = "SELECT * FROM Items WHERE Material = '' ";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            gvMaterials.DataSource = null;
            gvMaterials.DataBind();
            gvItems.DataSource = dt;
            gvItems.DataBind();
        }
        con.Close();
    }

    protected void LinkCreateItem(object sender, EventArgs e)
    {
        Response.Redirect("CreateItem.aspx");
    }

    protected void BackToMasters(object sender, EventArgs e)
    {
        Response.Redirect("Masters.aspx");
    }
}