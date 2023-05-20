using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IssueOnDemand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkCreateIssueOnDemand(object sender, EventArgs e)
    {
        Response.Redirect("CreateIssueOnDemand.aspx");
    }

    protected void BackToPharmacy(object sender, EventArgs e)
    {
        Response.Redirect("Pharmacy.aspx");
    }
}