using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkStockIssue(object sender, EventArgs e)
    {
        Response.Redirect("StockIssue.aspx");
    }

    protected void LinkInventoryReports(object sender, EventArgs e)
    {
        Response.Redirect("InventoryReports.aspx");
    }

    protected void LinkStore(object sender, EventArgs e)
    {
        Response.Redirect("Stores.aspx");
    }

    protected void LinkVendor(object sender, EventArgs e)
    {
        Response.Redirect("Vendors.aspx");
    }
}