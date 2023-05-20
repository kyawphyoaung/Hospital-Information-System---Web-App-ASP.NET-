using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InventoryReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkReorderLevel(object sender, EventArgs e)
    {
        Response.Redirect("ReorderLevel.aspx");
    }

    protected void LinkNearExpiry(object sender, EventArgs e)
    {
        Response.Redirect("NearExpiry.aspx");
    }

    protected void LinkStockLedger(object sender, EventArgs e)
    {
        Response.Redirect("StockLedger.aspx");
    }

    protected void LinkTransactionStock(object sender, EventArgs e)
    {
        Response.Redirect("TransactionStock.aspx");
    }
}