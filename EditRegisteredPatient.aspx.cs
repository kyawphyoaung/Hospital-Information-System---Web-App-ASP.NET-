using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

public partial class EditRegisteredPatient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string patientID = Request.QueryString["patientID"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Patients WHERE PatientID = '" + patientID + "'";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                prntxt.Text = patientID;
                fntxt.Text = dr[1].ToString();
                mntxt.Text = dr[2].ToString();
                lntxt.Text = dr[3].ToString();
                dateofbirth.Text = dr[5].ToString();
                agetxt.Text = dr[6].ToString();
                nrctxt.Text = dr[7].ToString();
                phtxt.Text = dr[8].ToString();
                homenotxt.Text = dr[9].ToString();
                streettxt.Text = dr[10].ToString();
                txtStates.Text = dr[11].ToString();
                txtTownship.Text = dr[12].ToString();
                countrytxt.Text = dr[13].ToString();
            }
        }
    }
}