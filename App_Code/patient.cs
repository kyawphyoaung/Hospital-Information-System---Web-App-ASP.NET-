using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for patient
/// </summary>
public class patient
{
	public patient()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string prn, firstname, middlename, lastname, gender, dob, age, nrc, phono, homeno, street, states, township, country;

    public patient(string PRN, string Firstname, string Middlename, string Lastname, string Gender, string Dob, string Age, string Nrc, string Phno, string Homeno, string Street, string States, string Township, string Country)
    {
        prn = PRN;
        firstname = Firstname;
        middlename = Middlename;
        lastname = Lastname;
        gender = Gender;
        dob = Dob;
        age = Age;
        nrc = Nrc;
        phono = Phno;
        homeno = Homeno;
        street = Street;
        states = States;
        township = Township;
        country = Country;
    }
    public string PRN { get; set; }
    public string Firstname { get; set; }
    public string Middlename { get; set; }
    public string Lastname { get; set; }
    public string Gender { get; set; }
    public string Dob { get; set; }
    public string Age { get; set; }
    public string Nrc { get; set; }
    public string Phno { get; set; }
    public string Homeno { get; set; }
    public string Street { get; set; }
    public string States { get; set; }
    public string Township { get; set; }
    public string Country { get; set; }
}