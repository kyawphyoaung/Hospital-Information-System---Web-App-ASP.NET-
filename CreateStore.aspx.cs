using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class CreateStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string code = null;
            int number = 0;
            string num = null;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM Stores";

            number = (int)(cmd.ExecuteScalar());

            if (number < 9)
            {
                num = "00" + (number + 1);
            }

            else if (number >= 9 && number < 99)
            {
                num = "0" + (number + 1);
            }

            else if (number >= 99)
            {
                num = "" + (number + 1);
            }

            code = "ST" + num;
            txtCode.Text = code;
        }
    }

    protected void CreateNewStore(object sender, EventArgs e)
    {
        try
        {
            string code = txtCode.Text;
            string name = txtName.Text;
            string category = ddlCategory.Text;

            if (name == "" || name == null)
            {
                throw new FormatException();
            }

            if (category == "--Select--")
            {
                throw new UnselectedException("Please select one from category.");
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT Stores VALUES ('" + code + "', '" + name + "', '" + category + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successful");

            Response.Redirect(Request.RawUrl);
        }
        catch (FormatException)
        {
            MessageBox.Show("Please provide store name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (UnselectedException use)
        {
            MessageBox.Show(use.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected void LinkToStores(object sender, EventArgs e)
    {
        Response.Redirect("Stores.aspx");
    }
}