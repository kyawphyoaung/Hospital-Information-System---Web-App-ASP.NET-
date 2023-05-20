using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkRegistration(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }

    protected void LinkPharmacy(object sender, EventArgs e)
    {
        Response.Redirect("Pharmacy.aspx");
    }

    protected void LinkProcurement(object sender, EventArgs e)
    {
        Response.Redirect("Procurement.aspx");
    }

    protected void LinkInventory(object sender, EventArgs e)
    {
        Response.Redirect("Inventory.aspx");
    }
}