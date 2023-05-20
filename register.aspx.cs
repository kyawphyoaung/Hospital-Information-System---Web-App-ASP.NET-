using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] statedb = { "Yangon", "Mandalay", "Naypyidaw" };
            state.DataSource = statedb;
            state.DataBind();
        }

        if (state.SelectedValue.ToString() == "Yangon")
        {
            string[] townshipdb = { "Botahtaung", "Latha", "SanChaung" };
            township.DataSource = townshipdb;
            township.DataBind();
        }
        else if (state.SelectedValue.ToString() == "Mandalay")
        {
            string[] townshipdb = { "ChanMyaThaZi", "AungMyayThaZan", "Amarapura" };
            township.DataSource = townshipdb;
            township.DataBind();
        }
        else
        {
            string[] townshipdb = { "ZaBuThiRi", "PokeBaThiRi", "Pyinmana" };
            township.DataSource = townshipdb;
            township.DataBind();
        }

        //auto generate and show PRN no.
        prntxt.Text = PatientIDAutogenerate();
    }

    public void registerbtn(object sender, EventArgs e)
    {
        string dateofbirth = Request.Form["n_datepicker"];
        string age = Request.Form["n_Age"];
        string s_state = state.SelectedValue.ToString();
        string t_township = township.SelectedValue.ToString();

        patient p = new patient();
        p.PRN = prntxt.Text;
        p.Firstname = fntxt.Text;
        p.Middlename = mntxt.Text;
        p.Lastname = lntxt.Text;

        if (male.Checked)
            p.Gender = "Male";
        if (female.Checked)
            p.Gender = "Female";
        if (other.Checked)
            p.Gender = "Other";

        p.Dob = dateofbirth;
        p.Age = age;
        p.Nrc = nrctxt.Text;
        p.Phno = phtxt.Text;
        p.Homeno = homenotxt.Text;
        p.Street = streettxt.Text;
        p.States = s_state;
        p.Township = t_township;
        p.Country = countrytxt.Text;

        patientaccess ps = new patientaccess();
        ps.regpatient(p);
        MessageBox.Show("Register Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        Response.Redirect(Request.RawUrl);
       
    }
    public void resetall(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
    public void backbtn(object sender, EventArgs e)
    {
        Response.Redirect("registration.aspx");
    }
   
    public void patientlist(object sender, EventArgs e)
    {
        Response.Redirect("patientlist.aspx");
    }

    public string PatientIDAutogenerate()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand("SELECT COUNT(PatientID) FROM Patients", con);
        int i = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        i++;

        string num = null;
        string code = null;

        if (i < 9)
        {
            num = "000" + i;
        }

        else if (i >= 9 && i < 99)
        {
            num = "00" + i;
        }

        else if (i >= 99 && i < 999)
        {
            num = "0" + i;
        }
        else if (i >= 999)
        {
            num = "" + i;
        }

        code = "PRN" + num;
        return code;
    }
}