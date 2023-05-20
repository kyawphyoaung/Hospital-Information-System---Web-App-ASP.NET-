using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void clearclick(object sender, EventArgs e)
    {
        usernametxt.Text = "";
        passwordtxt.Text = "";
    }

    // Get Username and password from Database
    public DataTable useraccountfromdb(string usernameinput, string pwdinput)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog=HospitalIS;Integrated Security= true";

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = new SqlCommand();
        sda.SelectCommand.Connection = con;
        sda.SelectCommand.CommandText = "select * from useraccount where username= '" + usernameinput + "' and pwd='" + pwdinput + "' ";

        DataSet ds = new DataSet();
        sda.Fill(ds, "useraccount");
        DataTable dt = ds.Tables["useraccount"];
        return dt;
    }
    
    public void loginclick(object sender, EventArgs e)
    {
        try
        {
            String usernameinput = usernametxt.Text;
            String pwdinput = passwordtxt.Text;

            DataTable dt = useraccountfromdb(usernameinput, pwdinput);
            String username = dt.Rows[0][0].ToString();
            String password = dt.Rows[0][1].ToString();


            if (username == usernameinput && password == pwdinput)
            {
                Response.Redirect("main.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Something is wrong!Login again')", true);
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Something is wrong!Login again')", true);
        }      
    }
}