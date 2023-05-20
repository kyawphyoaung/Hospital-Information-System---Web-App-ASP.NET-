using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void newregister(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
    public void patientlistpage(object sender, EventArgs e)
    {
        Response.Redirect("patientlist.aspx");
    }
}