using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class CreateGeneric : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create and display auto generated code

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
            cmd.CommandText = "SELECT COUNT(*) FROM Generic";

            number = (int)(cmd.ExecuteScalar());

            if (number < 9)
            {
                num = "000" + (number + 1);
            }

            else if (number >= 9 && number < 99)
            {
                num = "00" + (number + 1);
            }

            else if (number >= 99 && number < 999)
            {
                num = "0" + (number + 1);
            }
            else if (number >= 999)
            {
                num = "" + (number + 1);
            }

            code = "GRN" + num;
            txtCode.Text = code;
        }
    }

    protected void LinkCreateGeneric(object sender, EventArgs e)
    {
        try
        {
            string code = txtCode.Text;
            string name = txtName.Text;
            bool checkActive = chkActive.Checked;
            string active = null;

            if (checkActive.Equals(true))
            {
                active = "flag_active2.png";
            }
            else
            {
                active = "redflag.png";
            }

            if (name == null || name == "")
            {
                throw new FillInException("Please provide generic name!");
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT Generic VALUES ('" + code + "', '" + name + "', '" + active + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successful");

            Response.Redirect(Request.RawUrl);
        }
        catch (SqlException)
        {
            MessageBox.Show("Out of Service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (FillInException fe)
        {
            lblName.Visible = true;
        }
    }

    protected void LinkToGeneric(object sender, EventArgs e)
    {
        Response.Redirect("Generic.aspx");
    }
}