using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Generic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkCreateGeneric(object sender, EventArgs e)
    {
        Response.Redirect("CreateGeneric.aspx");
    }

    protected void BackToMasters(object sender, EventArgs e)
    {
        Response.Redirect("Masters.aspx");
    }

    protected void BackToMain(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}