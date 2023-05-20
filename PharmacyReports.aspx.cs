using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkSaleReports(object sender, EventArgs e)
    {
        Response.Redirect("SaleReports.aspx");
    }

    protected void BackToPharmacy(object sender, EventArgs e)
    {
        Response.Redirect("Pharmacy.aspx");
    }
}