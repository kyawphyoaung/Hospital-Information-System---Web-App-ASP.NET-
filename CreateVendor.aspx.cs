using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class CreateVendor : System.Web.UI.Page
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
            cmd.CommandText = "SELECT COUNT(*) FROM Vendors";

            number = (int)(cmd.ExecuteScalar());

            if (number < 9)
            {
                num = "00000" + (number + 1);
            }

            else if (number >= 9 && number < 99)
            {
                num = "0000" + (number + 1);
            }

            else if (number >= 99 && number < 999)
            {
                num = "000" + (number + 1);
            }

            else if (number >= 999 && number < 9999)
            {
                num = "00" + (number + 1);
            }

            else if (number >= 9999 && number < 99999)
            {
                num = "0" + (number + 1);
            }

            else if (number >= 99999)
            {
                num = "" + (number + 1);
            }

            code = "V" + num;
            txtCode.Text = code;
        }
    }

    protected void CreateNewVendor(object sender, EventArgs e)
    {
        try
        {
            string code = txtCode.Text;
            string name = txtName.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT Vendors VALUES ('" + code + "', '" + name + "')";
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

    protected void LinkToVendors(object sender, EventArgs e)
    {
        Response.Redirect("Vendors.aspx");
    }
}