using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pharmacy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkIOD(object sender, EventArgs e)
    {
        Response.Redirect("IssueOnDemand.aspx");
    }

    protected void LinkMasters(object sender, EventArgs e)
    {
        Response.Redirect("Masters.aspx");
    }

    protected void LinkReports(object sender, EventArgs e)
    {
        Response.Redirect("PharmacyReports.aspx");
    }
}