using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for patientaccess
/// </summary>
public class patientaccess
{
	public patientaccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    private void Update(string c)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = c;

        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void regpatient(patient p)
    {
        string c = "INSERT Patients VALUES('" + p.PRN + "', '" + p.Firstname + "' , '" + p.Middlename + "' , '" + p.Lastname + "' , '" + p.Gender + "' , '" + p.Dob + "' , '" + p.Age + "' , '" + p.Nrc + "' , '" + p.Phno + "' , '" + p.Homeno + "' , '" + p.Street + "' , '" + p.States + "' , '" + p.Township + "' , '" + p.Country + "' )";
        Update(c);
    }
}