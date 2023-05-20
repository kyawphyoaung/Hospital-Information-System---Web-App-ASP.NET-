using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransactionStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkStockIssue(object sender, EventArgs e)
    {
        Response.Redirect("StockIssue.aspx");
    }

    protected void BackToInventoryReports(object sender, EventArgs e)
    {
        Response.Redirect("InventoryReports.aspx");
    }
}