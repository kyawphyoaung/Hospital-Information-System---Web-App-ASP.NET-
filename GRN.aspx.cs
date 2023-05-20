using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GRN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkCreateGRN(object sender, EventArgs e)
    {
        Response.Redirect("CreateGRN.aspx");
    }

    protected void BackToProcurement(object sender, EventArgs e)
    {
        Response.Redirect("Procurement.aspx");
    }

    protected void BackToMain(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}