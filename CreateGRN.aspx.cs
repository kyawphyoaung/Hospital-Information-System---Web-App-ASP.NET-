using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

public partial class CreateGRN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // To display the auto generated Document Number in the text box

        if (!IsPostBack)
        {
            string code = null;
            int number = 0;
            string num = null;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM GoodReceiptNotes";

            number = (int)(cmd.ExecuteScalar());

            if (number < 9)
            {
                num = "000" + (number + 1);
            }

            else if (number >= 9 && number < 99)
            {
                num = "00" + (number + 1);
            }

            else if (number >= 99 && number < 999)
            {
                num = "0" + (number + 1);
            }
            else if (number >= 999)
            {
                num = "" + (number + 1);
            }

            code = "GRN---" + num;
            txtDocumentNumber.Text = code;

            ddlStore.AppendDataBoundItems = true;
            ddlStore.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlStore.SelectedIndex = 0;

            ddlVendor.AppendDataBoundItems = true;
            ddlVendor.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlVendor.SelectedIndex = 0;
        }
    }

    // Search Generic
    protected void SearchGeneric(object sender, EventArgs e)
    {
        string generic = txtGeneric.Text;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=localhost; Initial Catalog=HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        if (generic == "%")
        {
            cmd.CommandText = "SELECT * FROM Generic";
        }
        else
        {
            cmd.CommandText = "SELECT * FROM Generic WHERE Code LIKE '" + generic + "%' OR Name LIKE '" + generic + "%'";
        }

        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count <= 0)
        {
            MessageBox.Show("The generic is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            gvGeneric.DataSource = dt;
            gvGeneric.DataBind();
        }

        con.Close();
    }

    protected void gvGeneric_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string generic = txtGeneric.Text;
        gvGeneric.PageIndex = e.NewPageIndex;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=localhost; Initial Catalog=HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        if (generic == "%")
        {
            cmd.CommandText = "SELECT * FROM Generic";
        }
        else
        {
            cmd.CommandText = "SELECT * FROM Generic WHERE Code LIKE '" + generic + "%' OR Name LIKE '" + generic + "%'";
        }

        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count <= 0)
        {
            MessageBox.Show("The generic is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            gvGeneric.DataSource = dt;
            gvGeneric.DataBind();
        }

        con.Close();
    }

    //Select respective drugs from items according to the selected generic
    protected void SelectedGeneric(object sender, EventArgs e)
    {
        gvMaterials.DataSource = null;
        gvMaterials.DataBind();

        string generic = gvGeneric.SelectedRow.Cells[2].Text;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Items WHERE Generic = '" + generic + "'";
        
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count <= 0)
        {
            MessageBox.Show("The item is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            gvItems.DataSource = dt;
            gvItems.DataBind();
        }
        con.Close();
    }

    // Search Items from Items table
    protected void Search(object sender, EventArgs e)
    {
        string item = txtItem.Text;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        if (item == null || item == "" || item == "%")
        {
            cmd.CommandText = "SELECT * FROM Items WHERE Material = '' ";
        }
        else
        {
            cmd.CommandText = "SELECT * FROM Items Where Name LIKE '" + item + "%'  OR Code LIKE '" + item + "%'";
        }

        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count <= 0)
        {
            MessageBox.Show("The item is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            gvItems.DataSource = dt;
            gvItems.DataBind();
        }
        con.Close();
    }

    protected void gvItems_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItems.PageIndex = e.NewPageIndex;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Items WHERE Material = '' ";
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        gvItems.DataSource = dt;
        gvItems.DataBind();

        con.Close();
    }

    // Search Materials
    protected void SearchMaterials(object sender, EventArgs e)
    {
        string item = txtItem.Text;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        DataTable dt = new DataTable();

        if (chkMaterial.Checked)
        {
            cmd.CommandText = "SELECT * FROM Items WHERE Material = 'Materials'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            gvItems.DataSource = null;
            gvItems.DataBind();
            gvMaterials.DataSource = dt;
            gvMaterials.DataBind();
        }
        else
        {
            cmd.CommandText = "SELECT * FROM Items WHERE Material = '' ";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            gvMaterials.DataSource = null;
            gvMaterials.DataBind();
            gvItems.DataSource = dt;
            gvItems.DataBind();
        }
        con.Close();
    }

    protected void gvMaterials_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMaterials.PageIndex = e.NewPageIndex;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        DataTable dt = new DataTable();

        if (chkMaterial.Checked)
        {
            cmd.CommandText = "SELECT * FROM Items WHERE Material = 'Materials'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            gvItems.DataSource = null;
            gvItems.DataBind();
            gvMaterials.DataSource = dt;
            gvMaterials.DataBind();
        }
        else
        {
            cmd.CommandText = "SELECT * FROM Items WHERE Material = '' ";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            gvMaterials.DataSource = null;
            gvMaterials.DataBind();
            gvItems.DataSource = dt;
            gvItems.DataBind();
        }
        con.Close();
    }


    /* Display selected item in the text box */
    protected void AddItems(object sender, EventArgs e)
    {
        txtItem.Text = gvItems.SelectedValue.ToString();
    }


    /* Display selected material in the text box */
    protected void AddMaterials(object sender, EventArgs e)
    {
        txtItem.Text = gvMaterials.SelectedValue.ToString();
    }


    /* Add quantity to the selected item */
    protected void QuantityAdd(object sender, EventArgs e)
    {
        try
        {
            string code = txtItem.Text;
            int quantity = int.Parse(txtQuantity.Text);
            string issueNumber = txtDocumentNumber.Text;
            string issueStatus = "Issued";
            string store = ddlStore.SelectedValue.ToString();
            string vendor = ddlVendor.SelectedValue.ToString();
            string issuedDate = DateTime.Now.ToString();
            string transactionType = "STOCKIN";

            if (store == "--Select--")
            {
                throw new UnselectedException("Please select one from store.");
            }

            if (vendor == "--Select--")
            {
                throw new UnselectedException("Please select one from vendor.");
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT AddItems (IssueNumber, IssueStatus, Store, IssuedDate, Code) VALUES ('" + issueNumber + "', '" + issueStatus + "', '" + store + "', '" + issuedDate + "', '" + code + "')";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "UPDATE AddItems Set AddItems.Name = Items.Name, AddItems.Batch = Items.Batch, AddItems.Expiry = Items.Expiry, AddItems.Stock = Items.Stock, AddItems.Generic = Items.Generic, AddItems.Quantity = '" + quantity + "' FROM AddItems, Items WHERE AddItems.Code = Items.Code AND Items.Code = '" + code + "'";
            cmd1.ExecuteNonQuery();            

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            cmd3.CommandText = "INSERT StockLedgerDraft (Store, Code, TransactionType, RefDocNo, RefDocDate, StockInQty, StockOutQty) VALUES ('" + store + "', '" + code + "','" + transactionType + "', '" + issueNumber + "', '" + issuedDate + "', '" + quantity + "', '')";
            cmd3.ExecuteNonQuery();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con;
            cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = Items.Name, StockLedgerDraft.Batch = Items.Batch, StockLedgerDraft.Expiry = Items.Expiry FROM StockLedgerDraft, Items WHERE StockLedgerDraft.Code = Items.Code AND Items.Code = '" + code + "'";
            cmd4.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = con;
            cmd5.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.ClosingStock = AddItems.Differ FROM StockLedgerDraft, AddItems WHERE StockLedgerDraft.Code = AddItems.Code";
            cmd5.ExecuteNonQuery();

            SqlCommand cmd6 = new SqlCommand();
            cmd6.Connection = con;

            SqlCommand cmd7 = new SqlCommand();
            cmd7.Connection = con;

            if (store == "Medical Store")
            {
                cmd6.CommandText = "INSERT MedicalStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE MedicalStoreDraft SET MedicalStoreDraft.Name = AddItems.Name, MedicalStoreDraft.Generic = AddItems.Generic, MedicalStoreDraft.Batch = AddItems.Batch, MedicalStoreDraft.Expiry = AddItems.Expiry, MedicalStoreDraft.Stock = AddItems.Quantity from AddItems, MedicalStoreDraft WHERE MedicalStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }

            else if (store == "Pharmacy")
            {
                cmd6.CommandText = "INSERT PharmacyDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE PharmacyDraft SET PharmacyDraft.Name = AddItems.Name, PharmacyDraft.Generic = AddItems.Generic, PharmacyDraft.Batch = AddItems.Batch, PharmacyDraft.Expiry = AddItems.Expiry, PharmacyDraft.Stock = AddItems.Quantity from AddItems, PharmacyDraft WHERE PharmacyDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }

            else if (store == "Emergency Crashkart")
            {
                cmd6.CommandText = "INSERT EmergencyCrashkartDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE EmergencyCrashkartDraft SET EmergencyCrashkartDraft.Name = AddItems.Name, EmergencyCrashkartDraft.Generic = AddItems.Generic, EmergencyCrashkartDraft.Batch = AddItems.Batch, EmergencyCrashkartDraft.Expiry = AddItems.Expiry, EmergencyCrashkartDraft.Stock = AddItems.Quantity from AddItems, EmergencyCrashkartDraft WHERE EmergencyCrashkartDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }

            else if (store == "Laboratory Store")
            {
                cmd6.CommandText = "INSERT LaboratoryStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE LaboratoryStoreDraft SET LaboratoryStoreDraft.Name = AddItems.Name, LaboratoryStoreDraft.Generic = AddItems.Generic, LaboratoryStoreDraft.Batch = AddItems.Batch, LaboratoryStoreDraft.Expiry = AddItems.Expiry, LaboratoryStoreDraft.Stock = AddItems.Quantity from AddItems, LaboratoryStoreDraft WHERE LaboratoryStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }

            else if (store == "Transit Store")
            {
                cmd6.CommandText = "INSERT TransitStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE TransitStoreDraft SET TransitStoreDraft.Name = AddItems.Name, TransitStoreDraft.Generic = AddItems.Generic, TransitStoreDraft.Batch = AddItems.Batch, TransitStoreDraft.Expiry = AddItems.Expiry, TransitStoreDraft.Stock = AddItems.Quantity from AddItems, TransitStoreDraft WHERE TransitStoreDraft.Code = AddItems.Code AND TransitStoreDraft.Code = '" + code + "'";
            }

            else if (store == "Consignment Store")
            {
                cmd6.CommandText = "INSERT ConsignmentStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE ConsignmentStoreDraft SET ConsignmentStoreDraft.Name = AddItems.Name, ConsignmentStoreDraft.Generic = AddItems.Generic, ConsignmentStoreDraft.Batch = AddItems.Batch, ConsignmentStoreDraft.Expiry = AddItems.Expiry, ConsignmentStoreDraft.Stock = AddItems.Quantity from AddItems, ConsignmentStoreDraft WHERE ConsignmentStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }

            else if (store == "CSSD Store")
            {
                cmd6.CommandText = "INSERT CSSDStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE CSSDStoreDraft SET CSSDStoreDraft.Name = AddItems.Name, CSSDStoreDraft.Generic = AddItems.Generic, CSSDStoreDraft.Batch = AddItems.Batch, CSSDStoreDraft.Expiry = AddItems.Expiry, CSSDStoreDraft.Stock = AddItems.Quantity from AddItems, CSSDStoreDraft WHERE CSSDStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }

            else if (store == "General Store")
            {
                cmd6.CommandText = "INSERT GeneralStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE GeneralStoreDraft SET GeneralStoreDraft.Name = AddItems.Name, GeneralStoreDraft.Generic = AddItems.Generic, GeneralStoreDraft.Batch = AddItems.Batch, GeneralStoreDraft.Expiry = AddItems.Expiry, GeneralStoreDraft.Stock = AddItems.Quantity from AddItems, GeneralStoreDraft WHERE GeneralStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }

            else if (store == "InterTransit Store")
            {
                cmd6.CommandText = "INSERT InterTransitStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE InterTransitStoreDraft SET InterTransitStoreDraft.Name = AddItems.Name, InterTransitStoreDraft.Generic = AddItems.Generic, InterTransitStoreDraft.Batch = AddItems.Batch, InterTransitStoreDraft.Expiry = AddItems.Expiry, InterTransitStoreDraft.Stock = AddItems.Quantity from AddItems, InterTransitStoreDraft WHERE InterTransitStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }

            else if (store == "IP Pharmacy")
            {
                cmd6.CommandText = "INSERT IPPharmacyDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + issueNumber + "', '" + issuedDate + "', '" + vendor + "', '" + code + "')";

                cmd7.CommandText = "UPDATE IPPharmacyDraft SET IPPharmacyDraft.Name = AddItems.Name, IPPharmacyDraft.Generic = AddItems.Generic, IPPharmacyDraft.Batch = AddItems.Batch, IPPharmacyDraft.Expiry = AddItems.Expiry, IPPharmacyDraft.Stock = AddItems.Quantity from AddItems, IPPharmacyDraft WHERE IPPharmacyDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }
            cmd6.ExecuteNonQuery();
            cmd7.ExecuteNonQuery();
            con.Close();

            gvSelectedItems.DataBind();
            gvSelectedItems.Visible = true;
            con.Close();

            txtQuantity.Text = "";
            txtItem.Text = "";
            gvItems.SelectedRow.BackColor = System.Drawing.Color.White;
        }
        catch (FillInException fe)
        {
            MessageBox.Show(fe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (UnselectedException use)
        {
            MessageBox.Show(use.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (NullReferenceException)
        {
            MessageBox.Show("Please select one from items.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected void Confirm(object sender, EventArgs e)
    {
        string documentNumber = txtDocumentNumber.Text;
        string vendor = ddlVendor.Text;
        string store = ddlStore.SelectedValue.ToString();
        string documentDate = DateTime.Now.ToString();
        string status = "Approved";

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = con;
        cmd1.CommandText = "INSERT GoodReceiptNotes VALUES ('" + documentNumber + "', '" + documentDate + "', '" + vendor + "', '" + store + "', '" + status + "')";
        cmd1.ExecuteNonQuery();

        SqlCommand cmd2 = new SqlCommand();
        cmd2.Connection = con;

        if (store == "Medical Store")
        {
            cmd2.CommandText = "INSERT MedicalStore SELECT * FROM MedicalStoreDraft";
        }
        else if (store == "Pharmacy")
        {
            cmd2.CommandText = "INSERT Pharmacy SELECT * FROM PharmacyDraft";
        }
        else if (store == "Emergency Crashkart")
        {
            cmd2.CommandText = "INSERT EmergencyCrashkart SELECT * FROM EmergencyCrashkartDraft";
        }
        else if (store == "Laboratory Store")
        {
            cmd2.CommandText = "INSERT LaboratoryStore SELECT * FROM LaboratoryStoreDraft";
        }
        else if (store == "Transit Store")
        {
            cmd2.CommandText = "INSERT TransitStore SELECT * FROM TransitStoreDraft";
        }
        else if (store == "Consignment Store")
        {
            cmd2.CommandText = "INSERT ConsignmentStore SELECT * FROM ConsignmentStoreDraft";
        }
        else if (store == "CSSD Store")
        {
            cmd2.CommandText = "INSERT CSSDStore SELECT * FROM CSSDStoreDraft";
        }
        else if (store == "General Store")
        {
            cmd2.CommandText = "INSERT GeneralStore SELECT * FROM GeneralStoreDraft";
        }
        else if (store == "InterTransit Store")
        {
            cmd2.CommandText = "INSERT InterTransitStore SELECT * FROM InterTransitStore";
        }
        else if (store == "IP Pharmacy")
        {
            cmd2.CommandText = "INSERT IPPharmacy SELECT * FROM IPPharmacyDraft";
        }

        cmd2.ExecuteNonQuery();
        

        SqlCommand cmd4 = new SqlCommand();
        cmd4.Connection = con;
        cmd4.CommandText = "UPDATE Items SET Stock = (Items.Stock + AddItems.Quantity) from Items, Additems WHERE Items.Code = AddItems.Code";
        cmd4.ExecuteNonQuery();

        SqlCommand cmd5 = new SqlCommand();
        cmd5.Connection = con;
        cmd5.CommandText = "INSERT StockLedger SELECT * FROM StockLedgerDraft";
        cmd5.ExecuteNonQuery();

        con.Close();

        MessageBox.Show("Successful!");

        con.Open();

        SqlCommand cmd7 = new SqlCommand();
        cmd7.Connection = con;
        cmd7.CommandText = "DELETE FROM AddItems";
        cmd7.ExecuteNonQuery();

        SqlCommand cmd8 = new SqlCommand();
        cmd8.Connection = con;
        cmd8.CommandText = "DELETE FROM StockLedgerDraft";
        cmd8.ExecuteNonQuery();

        SqlCommand cmd9 = new SqlCommand();
        cmd9.Connection = con;

        if (store == "Medical Store")
        {
            cmd9.CommandText = "DELETE FROM MedicalStoreDraft";
        }
        else if (store == "Pharmacy")
        {
            cmd9.CommandText = "DELETE FROM PharmacyDraft";
        }
        else if (store == "Emergency Crashkart")
        {
            cmd9.CommandText = "DELETE FROM EmergencyCrashkartDraft";
        }
        else if (store == "Laboratory Store")
        {
            cmd9.CommandText = "DELETE FROM LaboratoryStoreDraft";
        }
        else if (store == "Transit Store")
        {
            cmd9.CommandText = "DELETE FROM TransitStoreDraft";
        }
        else if (store == "Consignment Store")
        {
            cmd9.CommandText = "DELETE FROM ConsignmentStoreDraft";
        }
        else if (store == "CSSD Store")
        {
            cmd9.CommandText = "DELETE FROM CSSDStoreDraft";
        }
        else if (store == "General Store")
        {
            cmd9.CommandText = "DELETE FROM GeneralStoreDraft";
        }
        else if (store == "InterTransit Store")
        {
            cmd9.CommandText = "DELETE FROM InterTransitStore";
        }
        else if (store == "IP Pharmacy")
        {
            cmd9.CommandText = "DELETE FROM IPPharmacyDraft";
        }

        cmd9.ExecuteNonQuery();
        con.Close();

        Response.Redirect(Request.RawUrl);
    }

    protected void Cancel(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM AddItems";
        cmd.ExecuteNonQuery();

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = con;
        cmd1.CommandText = "DELETE FROM StockLedgerDraft";
        cmd1.ExecuteNonQuery();
        con.Close();

        Response.Redirect("Procurement.aspx");
    }
}