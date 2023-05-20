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
using System.Collections.Generic;

public partial class CreateIssueOnDemand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();


        // To display the auto generated Issue Number in the text box

        if (!IsPostBack)
        {
            string code = null;
            int number = 0;
            string num = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM IssueOnDemand";

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

            code = "OTC" + num;
            txtIssueNumber.Text = code;

            ddlStore.AppendDataBoundItems = true;
            ddlStore.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlStore.SelectedIndex = 0;
        }

        string patientID = Request.QueryString["data"];

        if (patientID != null)
        {
            txtPatientID.Text = patientID;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Name FROM ExternalPatient WHERE PatientID = '" + patientID + "'";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtPatientName.Text = dr["Name"].ToString();
            }
        }
    }

    // Check and display new application form for external patient
    protected void ExternalPatient(object sender, EventArgs e)
    {
        if (chkPatient.Checked)
        {
            Response.Redirect("ExternalPatient.aspx");
        }
    }

    // Search patient ID from database
    protected void SearchPatientID(object sender, EventArgs e)
    {
        string patientID = txtPatientID.Text;
        string patientName = null;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT Name FROM Patients WHERE PatientID='" + patientID + "'";

        SqlDataReader dr = cmd.ExecuteReader();
        if (!dr.HasRows)
        {
            MessageBox.Show("Invalid patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        while (dr.Read())
        {
            patientName = dr["Name"].ToString();

            txtPatientName.Text = patientName;
        }
    }


    /* Hide gridviews when a new store is selected */
    protected void StoreSelected(object sender, EventArgs e)
    {
        gvGeneric.DataSource = null;
        gvGeneric.DataBind();

        gvItems.DataSource = null;
        gvItems.DataBind();

        txtGeneric.Text = "";
        txtItem.Text = "";
    }



    // Search Generic
    protected void SearchGeneric(object sender, EventArgs e)
    {
        try
        {
            string store = ddlStore.SelectedValue.ToString();
            string generic = txtGeneric.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (store == "--Select--")
            {
                throw new UnselectedException("Please select one from stores.");
            }
            else if (store == "Medical Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM MedicalStore";
            }
            else if (store == "Pharmacy" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM Pharmacy";
            }
            else if (store == "Emergency Crashkart" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM EmergencyCrashkart";
            }
            else if (store == "Laboratory Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM LaboratoryStore";
            }
            else if (store == "Transit Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM TransitStore";
            }
            else if (store == "Consignment Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM ConsignmentStore";
            }
            else if (store == "CSSD Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM CSSDStore";
            }
            else if(store == "General Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM GeneralStore";
            }
            else if (store == "InterTransit Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM InterTransitStore";
            }
            else if (store == "IP Pharmacy" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM IPPharmacy";
            }
            else if (store == "Medical Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM MedicalStore WHERE Generic LIKE '"+generic+"%'";
            }
            else if (store == "Pharmacy" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM Pharmacy WHERE Generic LIKE '"+generic+"%'";
            }
            else if (store == "Emergency Crashkart" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM EmergencyCrashkart WHERE Generic LIKE '"+generic+"%'";
            }
            else if (store == "Laboratory Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM LaboratoryStore WHERE Generic LIKE '"+generic+"%'";
            }
            else if (store == "Transit Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM TransitStore WHERE Generic LIKE '"+generic+"%'";
            }
            else if (store == "Consignment Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM ConsignmentStore WHERE Generic LIKE '"+generic+"%'";
            }
            else if (store == "CSSD Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM CSSDStore WHERE Generic LIKE '"+generic+"%'";
            }
            else if(store == "General Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM GeneralStore WHERE Generic LIKE '"+generic+"%'";
            }
            else if (store == "InterTransit Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM InterTransitStore WHERE Generic LIKE '"+generic+"%'";
            }
            else if (store == "IP Pharmacy" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM IPPharmacy WHERE Generic LIKE '"+generic+"%'";
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
        catch (UnselectedException use)
        {
            MessageBox.Show(use.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected void gvGeneric_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            string store = ddlStore.SelectedValue.ToString();
            string generic = txtGeneric.Text;
            gvGeneric.PageIndex = e.NewPageIndex;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (store == "--Select--")
            {
                throw new UnselectedException("Please select one from stores.");
            }
            else if (store == "Medical Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM MedicalStore";
            }
            else if (store == "Pharmacy" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM Pharmacy";
            }
            else if (store == "Emergency Crashkart" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM EmergencyCrashkart";
            }
            else if (store == "Laboratory Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM LaboratoryStore";
            }
            else if (store == "Transit Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM TransitStore";
            }
            else if (store == "Consignment Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM ConsignmentStore";
            }
            else if (store == "CSSD Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM CSSDStore";
            }
            else if (store == "General Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM GeneralStore";
            }
            else if (store == "InterTransit Store" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM InterTransitStore";
            }
            else if (store == "IP Pharmacy" && generic == "%")
            {
                cmd.CommandText = "SELECT Generic FROM IPPharmacy";
            }
            else if (store == "Medical Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM MedicalStore WHERE Generic LIKE '" + generic + "%'";
            }
            else if (store == "Pharmacy" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM Pharmacy WHERE Generic LIKE '" + generic + "%'";
            }
            else if (store == "Emergency Crashkart" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM EmergencyCrashkart WHERE Generic LIKE '" + generic + "%'";
            }
            else if (store == "Laboratory Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM LaboratoryStore WHERE Generic LIKE '" + generic + "%'";
            }
            else if (store == "Transit Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM TransitStore WHERE Generic LIKE '" + generic + "%'";
            }
            else if (store == "Consignment Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM ConsignmentStore WHERE Generic LIKE '" + generic + "%'";
            }
            else if (store == "CSSD Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM CSSDStore WHERE Generic LIKE '" + generic + "%'";
            }
            else if (store == "General Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM GeneralStore WHERE Generic LIKE '" + generic + "%'";
            }
            else if (store == "InterTransit Store" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM InterTransitStore WHERE Generic LIKE '" + generic + "%'";
            }
            else if (store == "IP Pharmacy" && generic != null)
            {
                cmd.CommandText = "SELECT Generic FROM IPPharmacy WHERE Generic LIKE '" + generic + "%'";
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
        catch (UnselectedException use)
        {
            MessageBox.Show(use.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //Select respective drugs from items according to the selected generic
    protected void SelectedGeneric(object sender, EventArgs e)
    {
        string generic = gvGeneric.SelectedRow.Cells[1].Text;
        string store = ddlStore.SelectedValue.ToString();

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        if (store == "Medical Store")
        {
            cmd.CommandText = "SELECT * FROM MedicalStore WHERE Generic = '"+generic+"'";
        }
        else if (store == "Pharmacy")
        {
            cmd.CommandText = "SELECT * FROM Pharmacy WHERE Generic = '" + generic + "'";
        }
        else if (store == "Emergency Crashkart")
        {
            cmd.CommandText = "SELECT * FROM EmergencyCrashkart WHERE Generic = '" + generic + "'";
        }
        else if (store == "Laboratory Store")
        {
            cmd.CommandText = "SELECT * FROM LaboratoryStore WHERE Generic = '" + generic + "'";
        }
        else if (store == "Transit Store")
        {
            cmd.CommandText = "SELECT * FROM TransitStore WHERE Generic = '" + generic + "'";
        }
        else if (store == "Consignment Store")
        {
            cmd.CommandText = "SELECT * FROM ConsignmentStore WHERE Generic = '" + generic + "'";
        }
        else if (store == "CSSD Store")
        {
            cmd.CommandText = "SELECT * FROM CSSDStore WHERE Generic = '" + generic + "'";
        }
        else if (store == "General Store")
        {
            cmd.CommandText = "SELECT * FROM GeneralStore WHERE Generic = '" + generic + "'";
        }
        else if (store == "InterTransit Store")
        {
            cmd.CommandText = "SELECT * FROM InterTransitStore WHERE Generic = '" + generic + "'";
        }
        else if (store == "IP Pharmacy")
        {
            cmd.CommandText = "SELECT * FROM IPPharmacy WHERE Generic = '" + generic + "'";
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


    // Search Items
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            string store = ddlStore.SelectedValue.ToString();
            string item = txtItem.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (store == "--Select--")
            {
                throw new UnselectedException("Please select one from stores.");
            }
            else if (store == "Medical Store" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM MedicalStore";
            }
            else if (store == "Pharmacy" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM Pharmacy";
            }
            else if (store == "Emergency Crashkart" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM EmergencyCrashkart";
            }
            else if (store == "Laboratory Store" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM LaboratoryStore";
            }
            else if (store == "Transit Store" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM TransitStore";
            }
            else if (store == "Consignment Store" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM ConsignmentStore";
            }
            else if (store == "CSSD Store" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM CSSDStore";
            }
            else if (store == "General Store" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM GeneralStore";
            }
            else if (store == "InterTransit Store" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM InterTransitStore";
            }
            else if (store == "IP Pharmacy" && item == "%")
            {
                cmd.CommandText = "SELECT * FROM IPPharmacy";
            }
            else if (store == "Medical Store" && item != null)
            {
                cmd.CommandText = "SELECT * FROM MedicalStore WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
            }
            else if (store == "Pharmacy" && item != null)
            {
                cmd.CommandText = "SELECT * FROM Pharmacy WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
            }
            else if (store == "Emergency Crashkart" && item != null)
            {
                cmd.CommandText = "SELECT * FROM EmergencyCrashkart WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
            }
            else if (store == "Laboratory Store" && item != null)
            {
                cmd.CommandText = "SELECT * FROM LaboratoryStore WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
            }
            else if (store == "Transit Store" && item != null)
            {
                cmd.CommandText = "SELECT * FROM TransitStore WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
            }
            else if (store == "Consignment Store" && item != null)
            {
                cmd.CommandText = "SELECT * FROM ConsignmentStore WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
            }
            else if (store == "CSSD Store" && item != null)
            {
                cmd.CommandText = "SELECT * FROM CSSDStore WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
            }
            else if (store == "General Store" && item != null)
            {
                cmd.CommandText = "SELECT * FROM GeneralStore WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
            }
            else if (store == "InterTransit Store" && item != null)
            {
                cmd.CommandText = "SELECT * FROM InterTransitStore WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
            }
            else if (store == "IP Pharmacy" && item != null)
            {
                cmd.CommandText = "SELECT * FROM IPPharmacy WHERE Code LIKE '" + item + "%' OR Name LIKE '" + item + "%'";
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
        catch (UnselectedException use)
        {
            MessageBox.Show(use.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
            string patientID = txtPatientID.Text;
            string issueNumber = txtIssueNumber.Text;
            string issueStatus = "Issued";
            string store = ddlStore.SelectedValue.ToString();
            string issuedDate = DateTime.Now.ToString();
            string transactionType = "STOCKOUT";

            if (patientID == null || patientID == "")
            {
                throw new FillInException("Please provide patient ID.");
            }
            if (store == "--Select--")
            {
                throw new UnselectedException("Please select one from store.");
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT AddItems (PatientID, IssueNumber, IssueStatus, Store, IssuedDate, Code) VALUES ('" + patientID + "', '" + issueNumber + "', '" + issueStatus + "', '" + store + "', '" + issuedDate + "', '" + code + "')";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "UPDATE AddItems Set AddItems.Name = Items.Name, AddItems.Generic = Items.Generic, AddItems.Batch = Items.Batch, AddItems.Expiry = Items.Expiry, AddItems.Stock = Items.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, Items WHERE AddItems.Code = Items.Code AND Items.Code = '" + code + "'";
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "INSERT SaleReportDraft (PatientID, IssueNumber, IssueStatus, Store, IssuedDate, Code) VALUES ('" + patientID + "', '" + issueNumber + "', '" + issueStatus + "', '" + store + "', '" + issuedDate + "', '" + code + "')";
            cmd2.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand();
            command2.Connection = con;
            command2.CommandText = "UPDATE SaleReportDraft Set SaleReportDraft.Name = Items.Name, SaleReportDraft.Batch = Items.Batch, SaleReportDraft.Expiry = Items.Expiry, SaleReportDraft.Stock = Items.Stock, SaleReportDraft.Quantity = '" + quantity + "' FROM SaleReportDraft, Items WHERE SaleReportDraft.Code = Items.Code AND Items.Code = '" + code + "'";
            command2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            cmd3.CommandText = "INSERT StockLedgerDraft (Store, Code, TransactionType, RefDocNo, RefDocDate, StockInQty, StockOutQty) VALUES ('" + store + "', '" + code + "','" + transactionType + "', '" + issueNumber + "', '" + issuedDate + "', '', '" + quantity + "')";
            cmd3.ExecuteNonQuery();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con;
            cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = Items.Name, StockLedgerDraft.Batch = Items.Batch, StockLedgerDraft.Expiry = Items.Expiry FROM StockLedgerDraft, Items WHERE StockLedgerDraft.Code = Items.Code AND Items.Code = '" + code + "'";
            cmd4.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = con;
            cmd5.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.ClosingStock = AddItems.Differ FROM StockLedgerDraft, AddItems WHERE StockLedgerDraft.Code = AddItems.Code";
            cmd5.ExecuteNonQuery();

            gvSelectedItems.DataBind();
            gvSelectedItems.Visible = true;

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

    protected void ConfirmDispense(object sender, EventArgs e)
    {
        try
        {
            string issueNumber = txtIssueNumber.Text;
            string patientID = txtPatientID.Text;
            string store = ddlStore.Text;
            string issueStatus = "Issued";
            string issueDate = DateTime.Now.ToString();

            string quantity = txtQuantity.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT SaleReport SELECT * FROM SaleReportDraft";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "INSERT IssueOnDemand VALUES ('" + patientID + "','" + issueNumber + "', '" + issueStatus + "', '" + store + "', '" + issueDate + "')";
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "UPDATE Items SET Stock = AddItems.Differ FROM Items, AddItems WHERE Items.Code = AddItems.Code";
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            cmd3.CommandText = "INSERT StockLedger SELECT * FROM StockLedgerDraft";
            cmd3.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = con;

            if (store == "Medical Store")
            {
                cmd5.CommandText = "UPDATE MedicalStore SET Stock = AddItems.Differ FROM AddItems, MedicalStore WHERE MedicalStore.Code = AddItems.Code";
            }
            else if (store == "Pharmacy")
            {
                cmd5.CommandText = "UPDATE Pharmacy SET Stock = AddItems.Differ FROM AddItems, Pharmacy WHERE Pharmacy.Code = AddItems.Code";
            }

            else if (store == "Emergency Crashkart")
            {
                cmd5.CommandText = "UPDATE EmergencyCrashkart SET Stock = AddItems.Differ FROM AddItems, EmergencyCrashkart WHERE EmergencyCrashkart.Code = AddItems.Code";
            }

            else if (store == "Laboratory Store")
            {
                cmd5.CommandText = "UPDATE LaboratoryStore SET Stock = AddItems.Differ FROM AddItems, LaboratoryStore WHERE LaboratoryStore.Code = AddItems.Code";
            }

            else if (store == "Transit Store")
            {
                cmd5.CommandText = "UPDATE TransitStore SET Stock = AddItems.Differ FROM AddItems, TransitStore WHERE TransitStore.Code = AddItems.Code";
            }

            else if (store == "Consignment Store")
            {
                cmd5.CommandText = "UPDATE ConsignmentStore SET Stock = AddItems.Differ FROM AddItems, ConsignmentStore WHERE ConsignmentStore.Code = AddItems.Code";
            }

            else if (store == "CSSD Store")
            {
                cmd5.CommandText = "UPDATE CSSDStore SET Stock = AddItems.Differ FROM AddItems, CSSDStore WHERE CSSDStore.Code = AddItems.Code";
            }

            else if (store == "General Store")
            {
                cmd5.CommandText = "UPDATE GeneralStore SET Stock = AddItems.Differ FROM AddItems, GeneralStore WHERE GeneralStore.Code = AddItems.Code";
            }

            else if (store == "InterTransit Store")
            {
                cmd5.CommandText = "UPDATE InterTransitStore SET Stock = AddItems.Differ FROM AddItems, InterTransitStore WHERE InterTransitStore.Code = AddItems.Code";
            }

            else if (store == "IP Pharmacy")
            {
                cmd5.CommandText = "UPDATE IPPharmacy SET Stock = AddItems.Differ FROM AddItems, IPPharmacy WHERE IPPharmacy.Code = AddItems.Code";
            }

            cmd5.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successful!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Open();

            SqlCommand cmd6 = new SqlCommand();
            cmd6.Connection = con;
            cmd6.CommandText = "DELETE FROM AddItems";
            cmd6.ExecuteNonQuery();

            SqlCommand cmd7 = new SqlCommand();
            cmd7.Connection = con;
            cmd7.CommandText = "DELETE FROM StockLedgerDraft";
            cmd7.ExecuteNonQuery();

            SqlCommand cmd8 = new SqlCommand();
            cmd8.Connection = con;
            cmd8.CommandText = "DELETE FROM SaleReportDraft";
            cmd8.ExecuteNonQuery();
            con.Close();

            Response.Redirect(Request.RawUrl);
        }

        catch (SqlException)
        {
            MessageBox.Show("Please provide full information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
        con.Close();

        Response.Redirect("Pharmacy.aspx");
    }
}