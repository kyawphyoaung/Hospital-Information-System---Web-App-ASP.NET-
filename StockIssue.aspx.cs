using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;

public partial class TransferStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // To display the auto generated document number in the text box

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
            cmd.CommandText = "SELECT COUNT(*) FROM TransactionStock";

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

            code = "SRC---" + num;
            txtDocumentNumber.Text = code;

            ddlIssueStore.AppendDataBoundItems = true;
            ddlIssueStore.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlIssueStore.SelectedIndex = 0;

            ddlReceiptStore.AppendDataBoundItems = true;
            ddlReceiptStore.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlReceiptStore.SelectedIndex = 0;
        }
    }

    // Display items from selected store
    protected void DisplayItems(object sender, EventArgs e)
    {
        string store = ddlIssueStore.SelectedItem.Text;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=localhost; Initial Catalog=HospitalIS; Integrated Security=true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        
        if(store == "Medical Store")
        {
            cmd.CommandText = "SELECT * FROM MedicalStore";
        }
        else if (store == "Pharmacy")
        {
            cmd.CommandText = "SELECT * FROM Pharmacy";
        }
        else if (store == "Emergency Crashkart")
        {
            cmd.CommandText = "SELECT * FROM EmergencyCrashkart";
        }
        else if (store == "Laboratory Store")
        {
            cmd.CommandText = "SELECT * FROM LaboratoryStore";
        }
        else if (store == "Transit Store")
        {
            cmd.CommandText = "SELECT * FROM TransitStore";
        }
        else if (store == "Consignment Store")
        {
            cmd.CommandText = "SELECT * FROM ConsignmentStore";
        }
        else if (store == "CSSD Store")
        {
            cmd.CommandText = "SELECT * FROM CSSDStore";
        }
        else if (store == "General Store")
        {
            cmd.CommandText = "SELECT * FROM GeneralStore";
        }
        else if (store == "InterTransit Store")
        {
            cmd.CommandText = "SELECT * FROM InterTransitStore";
        }
        else if (store == "IP Pharmacy")
        {
            cmd.CommandText = "SELECT * FROM IPPharmacy";
        }

        SqlDataReader dr = cmd.ExecuteReader(); 
        gvItems.DataSource = dr;
        gvItems.DataBind();
    }

    /* Display selected item in the text box */
    protected void AddItems(object sender, EventArgs e)
    {
        txtItem.Text = gvItems.SelectedValue.ToString();
    }

    /* Add quantity to the selected item */
    protected void QuantityAdd(object sender, EventArgs e)
    {
        try
        {
            string code = gvItems.SelectedValue.ToString();
            int quantity = int.Parse(txtQuantity.Text);
            string issueStore = ddlIssueStore.SelectedValue.ToString();
            string receiptStore = ddlReceiptStore.SelectedValue.ToString();
            string documentNumber = txtDocumentNumber.Text;
            string documentDate = DateTime.Now.ToString();
            string issueStatus = "Issued";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT AddItems (IssueNumber, IssueStatus, Store, ReceiptStore, IssuedDate, Code) VALUES ('" + documentNumber + "', '" + issueStatus + "', '" + issueStore + "', '" + receiptStore + "', '" + documentDate + "', '" + code + "')";
            cmd.ExecuteNonQuery();

            SqlCommand command = new SqlCommand();
            command.Connection = con;

            if (issueStore == "Medical Store")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = MedicalStore.Name, AddItems.Generic = MedicalStore.Generic, AddItems.Batch = MedicalStore.Batch, AddItems.Expiry = MedicalStore.Expiry, AddItems.Stock = MedicalStore.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, MedicalStore WHERE AddItems.Code = MedicalStore.Code AND MedicalStore.Code = '" + code + "'";
            }
            else if (issueStore == "Pharmacy")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = Pharmacy.Name, AddItems.Generic = Pharmacy.Generic, AddItems.Batch = Pharmacy.Batch, AddItems.Expiry = Pharmacy.Expiry, AddItems.Stock = Pharmacy.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, Pharmacy WHERE AddItems.Code = Pharmacy.Code AND Pharmacy.Code = '" + code + "'";
            }
            else if (issueStore == "Emergency Crashkart")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = EmergencyCrashkart.Name, AddItems.Generic = EmergencyCrashkart.Generic, AddItems.Batch = EmergencyCrashkart.Batch, AddItems.Expiry = EmergencyCrashkart.Expiry, AddItems.Stock = EmergencyCrashkart.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, EmergencyCrashkart WHERE AddItems.Code = EmergencyCrashkart.Code AND EmergencyCrashkart.Code = '" + code + "'";
            }
            else if (issueStore == "Laboratory Store")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = LaboratoryStore.Name, AddItems.Generic = LaboratoryStore.Generic, AddItems.Batch = LaboratoryStore.Batch, AddItems.Expiry = LaboratoryStore.Expiry, AddItems.Stock = LaboratoryStore.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, LaboratoryStore WHERE AddItems.Code = LaboratoryStore.Code AND LaboratoryStore.Code = '" + code + "'";
            }
            else if (issueStore == "Transit Store")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = TransitStore.Name, AddItems.Generic = TransitStore.Generic, AddItems.Batch = TransitStore.Batch, AddItems.Expiry = TransitStore.Expiry, AddItems.Stock = TransitStore.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, TransitStore WHERE AddItems.Code = TransitStore.Code AND TransitStore.Code = '" + code + "'";
            }
            else if (issueStore == "Consignment Store")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = ConsignmentStore.Name, AddItems.Generic = ConsignmentStore.Generic, AddItems.Batch = ConsignmentStore.Batch, AddItems.Expiry = ConsignmentStore.Expiry, AddItems.Stock = ConsignmentStore.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, ConsignmentStore WHERE AddItems.Code = ConsignmentStore.Code AND ConsignmentStore.Code = '" + code + "'";
            }
            else if (issueStore == "CSSD Store")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = CSSDStore.Name, AddItems.Generic = CSSDStore.Generic, AddItems.Batch = CSSDStore.Batch, AddItems.Expiry = CSSDStore.Expiry, AddItems.Stock = CSSDStore.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, CSSDStore WHERE AddItems.Code = CSSDStore.Code AND CSSDStore.Code = '" + code + "'";
            }
            else if (issueStore == "General Store")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = GeneralStore.Name, AddItems.Generic = GeneralStore.Generic, AddItems.Batch = GeneralStore.Batch, AddItems.Expiry = GeneralStore.Expiry, AddItems.Stock = GeneralStore.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, GeneralStore WHERE AddItems.Code = GeneralStore.Code AND GeneralStore.Code = '" + code + "'";

            }
            else if (issueStore == "InterTransit Store")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = InterTransitStore.Name, AddItems.Generic = InterTransitStore.Generic, AddItems.Batch = InterTransitStore.Batch, AddItems.Expiry = InterTransitStore.Expiry, AddItems.Stock = InterTransitStore.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, InterTransitStore WHERE AddItems.Code = InterTransitStore.Code AND InterTransitStore.Code = '" + code + "'";
            }
            else if (issueStore == "IP Pharmacy")
            {
                command.CommandText = "UPDATE AddItems Set AddItems.Name = IPPharmacy.Name, AddItems.Generic = IPPharmacy.Generic, AddItems.Batch = IPPharmacy.Batch, AddItems.Expiry = IPPharmacy.Expiry, AddItems.Stock = IPPharmacy.Stock, AddItems.Quantity = '" + quantity + "' FROM AddItems, IPPharmacy WHERE AddItems.Code = IPPharmacy.Code AND IPPharmacy.Code = '" + code + "'";
            }         
            command.ExecuteNonQuery();   

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;

            if (receiptStore == "Medical Store")
            {
                cmd1.CommandText = "INSERT MedicalStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE MedicalStoreDraft SET MedicalStoreDraft.Name = AddItems.Name, MedicalStoreDraft.Generic = AddItems.Generic, MedicalStoreDraft.Batch = AddItems.Batch, MedicalStoreDraft.Expiry = AddItems.Expiry, MedicalStoreDraft.Stock = AddItems.Quantity from AddItems, MedicalStoreDraft WHERE MedicalStoreDraft.DocumentNumber = '" + documentNumber + "' AND MedicalStoreDraft.Code='"+code+"'";
            }
            else if (receiptStore == "Pharmacy")
            {
                cmd1.CommandText = "INSERT PharmacyDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE PharmacyDraft SET PharmacyDraft.Name = AddItems.Name, PharmacyDraft.Generic = AddItems.Generic, PharmacyDraft.Batch = AddItems.Batch, PharmacyDraft.Expiry = AddItems.Expiry, PharmacyDraft.Stock = AddItems.Quantity from AddItems, PharmacyDraft WHERE PharmacyDraft.DocumentNumber = '"+documentNumber+"' AND PharmacyDraft.Code = '"+code+"'";
            }
            else if (receiptStore == "Emergency Crashkart")
            {
                cmd1.CommandText = "INSERT EmergencyCrashkartDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE EmergencyCrashkartDraft SET EmergencyCrashkartDraft.Name = AddItems.Name, EmergencyCrashkartDraft.Generic = AddItems.Generic, EmergencyCrashkartDraft.Batch = AddItems.Batch, EmergencyCrashkartDraft.Expiry = AddItems.Expiry, EmergencyCrashkartDraft.Stock = AddItems.Quantity from AddItems, EmergencyCrashkartDraft WHERE EmergencyCrashkartDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }
            else if (receiptStore == "Laboratory Store")
            {
                cmd1.CommandText = "INSERT LaboratoryStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE LaboratoryStoreDraft SET LaboratoryStoreDraft.Name = AddItems.Name, LaboratoryStoreDraft.Generic = AddItems.Generic, LaboratoryStoreDraft.Batch = AddItems.Batch, LaboratoryStoreDraft.Expiry = AddItems.Expiry, LaboratoryStoreDraft.Stock = AddItems.Quantity from AddItems, LaboratoryStoreDraft WHERE LaboratoryStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }
            else if (receiptStore == "Transit Store")
            {
                cmd1.CommandText = "INSERT TransitStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE TransitStoreDraft SET TransitStoreDraft.Name = AddItems.Name, TransitStoreDraft.Generic = AddItems.Generic, TransitStoreDraft.Batch = AddItems.Batch, TransitStoreDraft.Expiry = AddItems.Expiry, TransitStoreDraft.Stock = AddItems.Quantity from AddItems, TransitStoreDraft WHERE TransitStoreDraft.Code = AdddItems.Code AND AddItems.Code = '" + code + "'";
            }
            else if (receiptStore == "Consignment Store")
            {
                cmd1.CommandText = "INSERT ConsignmentStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE ConsignmentStoreDraft SET ConsignmentStoreDraft.Name = AddItems.Name, ConsignmentStoreDraft.Generic = AddItems.Generic, ConsignmentStoreDraft.Batch = AddItems.Batch, ConsignmentStoreDraft.Expiry = AddItems.Expiry, ConsignmentStoreDraft.Stock = AddItems.Quantity from AddItems, ConsignmentStoreDraft WHERE ConsignmentStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }
            else if (receiptStore == "CSSD Store")
            {
                cmd1.CommandText = "INSERT CSSDStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE CSSDStoreDraft SET CSSDStoreDraft.Name = AddItems.Name, CSSDStoreDraft.Generic = AddItems.Generic, CSSDStoreDraft.Batch = AddItems.Batch, CSSDStoreDraft.Expiry = AddItems.Expiry, CSSDStoreDraft.Stock = AddItems.Quantity from AddItems, CSSDStoreDraft WHERE CSSDStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }
            else if (receiptStore == "General Store")
            {
                cmd1.CommandText = "INSERT GeneralStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE GeneralStoreDraft SET GeneralStoreDraft.Name = AddItems.Name, GeneralStoreDraft.Generic = AddItems.Generic, GeneralStoreDraft.Batch = AddItems.Batch, GeneralStoreDraft.Expiry = AddItems.Expiry, GeneralStoreDraft.Stock = AddItems.Quantity from AddItems, GeneralStoreDraft WHERE GeneralStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }
            else if (receiptStore == "InterTransit Store")
            {
                cmd1.CommandText = "INSERT InterTransitStoreDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE InterTransitStoreDraft SET InterTransitStoreDraft.Name = AddItems.Name, InterTransitStoreDraft.Generic = AddItems.Generic, InterTransitStoreDraft.Batch = AddItems.Batch, InterTransitStoreDraft.Expiry = AddItems.Expiry, InterTransitStoreDraft.Stock = AddItems.Quantity from AddItems, InterTransitStoreDraft WHERE InterTransitStoreDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }
            else if (receiptStore == "IP Pharmacy")
            {
                cmd1.CommandText = "INSERT IPPharmacyDraft (DocumentNumber, DocumentDate, Vendor, Code) VALUES ('" + documentNumber + "','" + documentDate + "', '', '"+code+"')";
                cmd2.CommandText = "UPDATE IPPharmacyDraft SET IPPharmacyDraft.Name = AddItems.Name, IPPharmacyDraft.Generic = AddItems.Generic, IPPharmacyDraft.Batch = AddItems.Batch, IPPharmacyDraft.Expiry = AddItems.Expiry, IPPharmacyDraft.Stock = AddItems.Quantity from AddItems, IPPharmacyDraft WHERE IPPharmacyDraft.Code = AddItems.Code AND AddItems.Code = '" + code + "'";
            }
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            cmd3.CommandText = "INSERT StockLedgerDraft (Store, Code, TransactionType, StockInQty, StockOutQty, RefDocNo, RefDocDate) VALUES ('" + receiptStore + "', '"+code+"', 'STOCKIN', '"+quantity+"', '', '" + documentNumber + "', '" + documentDate + "')";
            cmd3.ExecuteNonQuery();
            con.Close();

            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con2.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con2;

            if (receiptStore == "Medical Store")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = MedicalStoreDraft.Name, StockLedgerDraft.Batch = MedicalStoreDraft.Batch, StockLedgerDraft.Expiry = MedicalStoreDraft.Expiry FROM AddItems, MedicalStoreDraft WHERE StockLedgerDraft.Code = MedicalStoreDraft.Code AND MedicalStoreDraft.Code = '" + code + "'";
            }

            else if (receiptStore == "Pharmacy")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = PharmacyDraft.Name, StockLedgerDraft.Batch = PharmacyDraft.Batch, StockLedgerDraft.Expiry = PharmacyDraft.Expiry FROM AddItems, PharmacyDraft WHERE StockLedgerDraft.Code = PharmacyDraft.Code AND PharmacyDraft.Code = '" + code + "'";
            }

            else if (receiptStore == "Emergency Crashkart")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = EmergencyCrashkartDraft.Name, StockLedgerDraft.Batch = EmergencyCrashkartDraft.Batch, StockLedgerDraft.Expiry = EmergencyCrashkartDraft.Expiry FROM AddItems, EmergencyCrashkartDraft WHERE StockLedgerDraft.Code = EmergencyCrashkartDraft.Code AND EmergencyCrashkartDraft.Code = '" + code + "'";
            }

            else if (receiptStore == "Laboratory Store")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = LaboratoryStoreDraft.Name, StockLedgerDraft.Batch = LaboratoryStoreDraft.Batch, StockLedgerDraft.Expiry = LaboratoryStoreDraft.Expiry FROM AddItems, LaboratoryStoreDraft WHERE StockLedgerDraft.Code = LaboratoryStoreDraft.Code AND LaboratoryStoreDraft.Code = '" + code + "'";
            }
            
            else if (receiptStore == "Transit Store")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = TransitStoreDraft.Name, StockLedgerDraft.Batch = TransitStoreDraft.Batch, StockLedgerDraft.Expiry = TransitStoreDraft.Expiry FROM AddItems, TransitStoreDraft WHERE StockLedgerDraft.Code = TransitStoreDraft.Code AND TransitStoreDraft.Code = '" + code + "'";
            }

            else if (receiptStore == "Consignment Store")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = ConsignmentStoreDraft.Name, StockLedgerDraft.Batch = ConsignmentStoreDraft.Batch, StockLedgerDraft.Expiry = ConsignmentStoreDraft.Expiry FROM AddItems, ConsignmentStoreDraft WHERE StockLedgerDraft.Code = ConsignmentStoreDraft.Code AND ConsignmentStoreDraft.Code = '" + code + "'";
            }

            else if (receiptStore == "CSSD Store")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = CSSDStoreDraft.Name, StockLedgerDraft.Batch = CSSDStoreDraft.Batch, StockLedgerDraft.Expiry = CSSDStoreDraft.Expiry FROM AddItems, CSSDStoreDraft WHERE StockLedgerDraft.Code = CSSDStoreDraft.Code AND CSSDStoreDraft.Code = '" + code + "'";
            }

            else if (receiptStore == "General Store")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = GeneralStoreDraft.Name, StockLedgerDraft.Batch = GeneralStoreDraft.Batch, StockLedgerDraft.Expiry = GeneralStoreDraft.Expiry FROM AddItems, GeneralStoreDraft WHERE StockLedgerDraft.Code = GeneralStoreDraft.Code AND GeneralStoreDraft.Code = '" + code + "'";
            }

            else if (receiptStore == "InterTransit Store")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = InterTransitStoreDraft.Name, StockLedgerDraft.Batch = InterTransitStoreDraft.Batch, StockLedgerDraft.Expiry = InterTransitStoreDraft.Expiry FROM AddItems, InterTransitStoreDraft WHERE StockLedgerDraft.Code = InterTransitStoreDraft.Code AND InterTransitStoreDraft.Code = '" + code + "'";
            }

            else if (receiptStore == "IP Pharmacy")
            {
                cmd4.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = IPPharmacyDraft.Name, StockLedgerDraft.Batch = IPPharmacyDraft.Batch, StockLedgerDraft.Expiry = IPPharmacyDraft.Expiry FROM AddItems, IPPharmacyDraft WHERE StockLedgerDraft.Code = IPPharmacyDraft.Code AND IPPharmacyDraft.Code = '" + code + "'";
            }

            cmd4.ExecuteNonQuery();
         
            con.Open();
            SqlCommand cmd7 = new SqlCommand();
            cmd7.Connection = con;
            cmd7.CommandText = "INSERT StockLedgerDraft (Store, Code, TransactionType, StockInQty, StockOutQty, RefDocNo, RefDocDate) VALUES ('" + issueStore + "', '"+code+"', 'STOCKOUT', '', '"+quantity+"', '" + documentNumber + "', '" + documentDate + "')";
            cmd7.ExecuteNonQuery();

            SqlCommand cmd8 = new SqlCommand();
            cmd8.Connection = con;

            if (issueStore == "Medical Store")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = MedicalStore.Name, StockLedgerDraft.Batch = MedicalStore.Batch, StockLedgerDraft.Expiry = MedicalStore.Expiry FROM AddItems, MedicalStore WHERE StockLedgerDraft.Code = MedicalStore.Code AND MedicalStore.Code = '" + code + "'";
            }

            else if (issueStore == "Pharmacy")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = PharmacyDraft.Name, StockLedgerDraft.Batch = PharmacyDraft.Batch, StockLedgerDraft.Expiry = PharmacyDraft.Expiry FROM AddItems, PharmacyDraft WHERE StockLedgerDraft.Code = PharmacyDraft.Code AND PharmacyDraft.Code = '" + code + "'";
            }

            else if (issueStore == "Emergency Crashkart")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = EmergencyCrashkartDraft.Name, StockLedgerDraft.Batch = EmergencyCrashkartDraft.Batch, StockLedgerDraft.Expiry = EmergencyCrashkartDraft.Expiry FROM AddItems, EmergencyCrashkartDraft WHERE StockLedgerDraft.Code = EmergencyCrashkartDraft.Code AND EmergencyCrashkarDraft.Code = '" + code + "'";
            }

            else if (issueStore == "Laboratory Store")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = LaboratoryStoreDraft.Name, StockLedgerDraft.Batch = LaboratoryStoreDraft.Batch, StockLedgerDraft.Expiry = LaboratoryStoreDraft.Expiry FROM AddItems, LaboratoryStoreDraft WHERE StockLedgerDraft.Code = LaboratoryStoreDraft.Code AND LaboratoryStoreDraft.Code = '" + code + "'";
            }

            else if (issueStore == "Transit Store")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = TransitStoreDraft.Name, StockLedgerDraft.Batch = TransitStoreDraft.Batch, StockLedgerDraft.Expiry = TransitStoreDraft.Expiry FROM AddItems, TransitStoreDraft WHERE StockLedgerDraft.Code = TransitStoreDraft.Code AND TransitStoreDraft.Code = '" + code + "'";
            }

            else if (issueStore == "Consignment Store")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = ConsignmentStoreDraft.Name, StockLedgerDraft.Batch = ConsignmentStoreDraft.Batch, StockLedgerDraft.Expiry = ConsignmentStoreDraft.Expiry FROM AddItems, ConsignmentStoreDraft WHERE StockLedgerDraft.Code = ConsignmentStoreDraft.Code AND ConsignmentStoreDraft.Code = '" + code + "'";
            }

            else if (issueStore == "CSSD Store")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = CSSDStoreDraft.Name, StockLedgerDraft.Batch = CSSDStoreDraft.Batch, StockLedgerDraft.Expiry = CSSDStoreDraft.Expiry FROM AddItems, CSSDStoreDraft WHERE StockLedgerDraft.Code = CSSDStoreDraft.Code AND CSSDStoreDraft.Code = '" + code + "'";
            }

            else if (issueStore == "General Store")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = GeneralStoreDraft.Name, StockLedgerDraft.Batch = GeneralStoreDraft.Batch, StockLedgerDraft.Expiry = GeneralStoreDraft.Expiry FROM AddItems, GeneralStoreDraft WHERE StockLedgerDraft.Code = GeneralStoreDraft.Code AND GeneralStoreDraft.Code = '" + code + "'";
            }

            else if (issueStore == "InterTransit Store")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = InterTransitStoreDraft.Name, StockLedgerDraft.Batch = InterTransitStoreDraft.Batch, StockLedgerDraft.Expiry = InterTransitStoreDraft.Expiry FROM AddItems, InterTransitStoreDraft WHERE StockLedgerStoreDraft.Code = InterTransitStoreDraft.Code AND InterTransitStoreDraft.Code = '" + code + "'";
            }

            else if (issueStore == "IP Pharmacy")
            {
                cmd8.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.Name = IPPharmacyDraft.Name, StockLedgerDraft.Batch = IPPharmacyDraft.Batch, StockLedgerDraft.Expiry = IPPharmacyDraft.Expiry FROM AddItems, IPPharmacyDraft WHERE StockLedgerStoreDraft.Code = IPPharmacyDraft.Code AND IPPharmacyDraft.Code = '" + code + "'";
            }
            cmd8.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = con;
            cmd5.CommandText = "UPDATE StockLedgerDraft SET StockLedgerDraft.ClosingStock = (SELECT Stock FROM Items WHERE Items.Code = '" + code + "') WHERE StockLedgerDraft.RefDocNo = '" + documentNumber + "' AND StockLedgerDraft.Code = '" + code + "'";
            cmd5.ExecuteNonQuery();

            gvSelectedItems.DataBind();
            gvSelectedItems.Visible = true;
            con.Close();

            txtQuantity.Text = "";
            txtItem.Text = "";
            gvItems.SelectedRow.BackColor = System.Drawing.Color.White;
        }
        catch (NullReferenceException)
        {
            MessageBox.Show("Please select one from items.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected void Confirm(object sender, EventArgs e)
    {
        string documentNumber = txtDocumentNumber.Text;
        string issueStore = ddlIssueStore.SelectedValue.ToString();
        string receiptStore = ddlReceiptStore.SelectedValue.ToString();
        string documentDate = DateTime.Now.ToString();
        
        string status = "Completed.";

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        if (receiptStore == "Medical Store")
        {
            cmd.CommandText = "INSERT MedicalStore SELECT * FROM MedicalStoreDraft";
        }
        else if (receiptStore == "Pharmacy")
        {
            cmd.CommandText = "INSERT Pharmacy SELECT * FROM PharmacyDraft";
        }
        else if (receiptStore == "Emergency Crashkart")
        {
            cmd.CommandText = "INSERT EmergencyCrashkart SELECT * FROM EmergencyCrashkartDraft";
        }
        else if (receiptStore == "Laboratory Store")
        {
            cmd.CommandText = "INSERT LaboratoryStore SELECT * FROM LaboratoryStoreDraft";
        }
        else if (receiptStore == "Transit Store")
        {
            cmd.CommandText = "INSERT TransitStore SELECT * FROM TransitStoreDraft";
        }
        else if (receiptStore == "Consignment Store")
        {
            cmd.CommandText = "INSERT ConsignmentStore SELECT * FROM ConsignmentStoreDraft";
        }
        else if (receiptStore == "CSSD Store")
        {
            cmd.CommandText = "INSERT CSSDStore SELECT * FROM CSSDStoreDraft";
        }
        else if (receiptStore == "General Store")
        {
            cmd.CommandText = "INSERT GeneralStore SELECT * FROM GeneralStoreDraft";
        }
        else if (receiptStore == "InterTransit Store")
        {
            cmd.CommandText = "INSERT InterTransitStore SELECT * FROM InterTransitStoreDraft";
        }
        else if (receiptStore == "IP Pharmacy")
        {
            cmd.CommandText = "INSERT IPPharmacy SELECT * FROM IPPharmacyDraft";
        }

        cmd.ExecuteNonQuery();

        SqlCommand cmd2 = new SqlCommand();
        cmd2.Connection = con;

        if (issueStore == "Medical Store")
        {
            cmd2.CommandText = "UPDATE MedicalStore SET Stock= AddItems.Differ from MedicalStore, Additems WHERE MedicalStore.Code = AddItems.code";
        }
        else if (issueStore == "Pharmacy")
        {
            cmd2.CommandText = "UPDATE Pharmacy SET Stock= AddItems.Differ from Pharmacy, Additems WHERE Pharmacy.Code = AddItems.code";
        }
        else if (issueStore == "Emergency Crashkart")
        {
            cmd2.CommandText = "UPDATE EmergencyCrashkart SET Stock= AddItems.Differ from EmergencyCrashkart, Additems WHERE EmergencyCrashkart.Code = AddItems.code";
        }
        else if (issueStore == "Laboratory Store")
        {
            cmd2.CommandText = "UPDATE LaboratoryStore SET Stock= AddItems.Differ from LaboratoryStore, Additems WHERE LaboratoryStore.Code = AddItems.code";
        }
        else if (issueStore == "Transit Store")
        {
            cmd2.CommandText = "UPDATE TransitStore SET Stock= AddItems.Differ from TransitStore, Additems WHERE TransitStore.Code = AddItems.code";
        }
        else if (issueStore == "Consignment Store")
        {
            cmd2.CommandText = "UPDATE ConsignmentStore SET Stock= AddItems.Differ from ConsignmentStore, Additems WHERE ConsignmentStore.Code = AddItems.code";
        }
        else if (issueStore == "CSSD Store")
        {
            cmd2.CommandText = "UPDATE CSSDStore SET Stock= AddItems.Differ from CSSDStore, Additems WHERE CSSDStore.Code = AddItems.code";
        }
        else if (issueStore == "General Store")
        {
            cmd2.CommandText = "UPDATE GeneralStore SET Stock= AddItems.Differ from GeneralStore, Additems WHERE GeneralStore.Code = AddItems.code";
        }
        else if (issueStore == "InterTransit Store")
        {
            cmd2.CommandText = "UPDATE InterTransitStore SET Stock= AddItems.Differ from InterTransitStore, Additems WHERE InterTransitStore.Code = AddItems.code";
        }
        else if (issueStore == "IP Pharmacy")
        {
            cmd2.CommandText = "UPDATE IPPharmacy SET Stock= AddItems.Differ from IPPharmacy, Additems WHERE IPPharmacy.Code = AddItems.code";
        }
        
        cmd2.ExecuteNonQuery();

        SqlCommand cmd3 = new SqlCommand();
        cmd3.Connection = con;
        cmd3.CommandText = "INSERT TransactionStock (DocumentNumber, DocumentDate, IssueStore, ReceiptStore, Status) VALUES ('" + documentNumber + "', '" + documentDate + "','" + issueStore + "','" + receiptStore + "', '" + status + "')";
        cmd3.ExecuteNonQuery();

        SqlCommand cmd4 = new SqlCommand();
        cmd4.Connection = con;
        cmd4.CommandText = "UPDATE TransactionStock SET TransactionStock.Code = AddItems.Code, TransactionStock.Name = AddItems.Name, TransactionStock.Batch = AddItems.Batch, TransactionStock.Expiry = AddItems.Expiry, TransactionStock.Stock = AddItems.Quantity from AddItems, TransactionStock WHERE TransactionStock.DocumentNumber = '" + documentNumber + "'";
        cmd4.ExecuteNonQuery();

        SqlCommand cmd5 = new SqlCommand();
        cmd5.Connection = con;
        cmd5.CommandText = "INSERT StockLedger SELECT * FROM StockLedgerDraft";
        cmd5.ExecuteNonQuery();

        con.Close();

        con.Open();

        SqlCommand cmd9 = new SqlCommand();
        cmd9.Connection = con;
        cmd9.CommandText = "DELETE FROM AddItems";
        cmd9.ExecuteNonQuery();

        SqlCommand cmd10 = new SqlCommand();
        cmd10.Connection = con;
        cmd10.CommandText = "DELETE FROM StockLedgerDraft";
        cmd10.ExecuteNonQuery();

        SqlCommand cmd11 = new SqlCommand();
        cmd11.Connection = con;

        if (receiptStore == "Medical Store")
        {
            cmd11.CommandText = "DELETE FROM MedicalStoreDraft";
        }
        else if (receiptStore == "Pharmacy")
        {
            cmd11.CommandText = "DELETE FROM PharmacyDraft";
        }
        else if (receiptStore == "Emergency Crashkart")
        {
            cmd11.CommandText = "DELETE FROM EmergencyCrashkartDraft";
        }
        else if (receiptStore == "Laboratory Store")
        {
            cmd11.CommandText = "DELETE FROM LaboratoryStoreDraft";
        }
        else if (receiptStore == "Transit Store")
        {
            cmd11.CommandText = "DELETE FROM TransitStoreDraft";
        }
        else if (receiptStore == "Consignment Store")
        {
            cmd11.CommandText = "DELETE FROM ConsignmentStoreDraft";
        }
        else if (receiptStore == "CSSD Store")
        {
            cmd11.CommandText = "DELETE FROM CSSDStoreDraft";
        }
        else if (receiptStore == "General Store")
        {
            cmd11.CommandText = "DELETE FROM GeneralStoreDraft";
        }
        else if (receiptStore == "InterTransit Store")
        {
            cmd11.CommandText = "DELETE FROM InterTransitStore";
        }
        else if (receiptStore == "IP Pharmacy")
        {
            cmd11.CommandText = "DELETE FROM IPPharmacyDraft";
        }

        cmd11.ExecuteNonQuery();
        con.Close();

        MessageBox.Show("Successful!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

        Response.Redirect(Request.RawUrl);
    }

    protected void Cancel(object sender, EventArgs e)
    {
        Response.Redirect("Inventory.aspx");
    }
}