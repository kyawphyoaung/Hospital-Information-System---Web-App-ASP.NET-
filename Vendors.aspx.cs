using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vendor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkCreateVendor(object sender, EventArgs e)
    {
        Response.Redirect("CreateVendor.aspx");
    }

    protected void BackToInventory(object sender, EventArgs e)
    {
        Response.Redirect("Inventory.aspx");
    }
}