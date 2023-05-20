using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

public partial class ExternalPatient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // To display the auto generated External Patient Number in the text box

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
            cmd.CommandText = "SELECT COUNT(*) FROM ExternalPatient";

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

            code = "EPRN" + num;
            txtPatientID.Text = code;
        }
    }

    // Create new external patient
    protected void Confirm(object sender, EventArgs e)
    {
        try
        {
            string patientID = txtPatientID.Text;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;

            if (name == null || name == "")
            {
                throw new FormatException("Please provide name.");
            }
            if (address == null || address == "")
            {
                throw new FormatException("Please provide the address.");
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT ExternalPatient VALUES ('" + patientID + "', '" + name + "', '" + phone + "','" + email + "', '" + address + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successful.");

            Response.Redirect("CreateIssueOnDemand.aspx?data=" + patientID);
        }
        catch (FormatException fe)
        {
            MessageBox.Show(fe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected void Back(object sender, EventArgs e)
    {
        Response.Redirect("CreateIssueOnDemand.aspx");
    }
}