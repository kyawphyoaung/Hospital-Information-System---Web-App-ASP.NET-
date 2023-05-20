using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkGeneric(object sender, EventArgs e)
    {
        Response.Redirect("Generic.aspx");
    }

    protected void LinkItems(object sender, EventArgs e)
    {
        Response.Redirect("Items.aspx");
    }
}