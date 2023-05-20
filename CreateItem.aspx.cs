using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;

public partial class CreateItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // To display the auto generated code in the text box

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
            cmd.CommandText = "SELECT COUNT(*) FROM Items";

            number = (int)(cmd.ExecuteScalar());

            if (number < 9)
            {
                num = "0000" + (number + 1);
            }

            else if (number >= 9 && number < 99)
            {
                num = "000" + (number + 1);
            }

            else if (number >= 99 && number < 999)
            {
                num = "00" + (number + 1);
            }
            else if (number >= 999 && number < 9999)
            {
                num = "0" + (number + 1);
            }
            else if (number >= 9999)
            {
                num = "" + (number + 1);
            }

            code = "DRG" + num;
            txtCode.Text = code;

            ddlGeneric.AppendDataBoundItems = true;
            ddlGeneric.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlGeneric.SelectedIndex = 0;
        }
    }

    protected void MaterialsChecked(object sender, EventArgs e)
    {
        // To enable or disable the respective field when Materials is checked

        if (chkMaterials.Checked)
        {
            ddlGeneric.Enabled = false;
            chkActive.Enabled = false;
            ddlForms.Enabled = false;
            ddlRoute.Enabled = false;
            txtStrength.Enabled = false;
        }

        else
        {
            ddlGeneric.Enabled = true;
            chkActive.Enabled = true;
            ddlForms.Enabled = true;
            ddlRoute.Enabled = true;
            txtStrength.Enabled = true;
        }
    }


    protected void CreateNewItem(object sender, EventArgs e)
    {
        try
        {
            string code = txtCode.Text;
            string material = null;
            string name = txtName.Text;
            string active = null;
            if (chkActive.Checked)
            {
                active = "flag_active2.png";
            }
            else
            {
                active = "redflag.png";
            }
            string generic = ddlGeneric.SelectedValue.ToString();
            string forms = ddlForms.SelectedValue.ToString();
            string route = ddlRoute.SelectedValue.ToString();
            string strength = txtStrength.Text;
            string batch = txtBatch.Text;
            string expiry = datepicker.Value;
            int stock = int.Parse(txtStockOnHand.Text);
            string reorderLevel = txtReorderLevel.Text;

            // To save the materials
            if (chkMaterials.Checked)
            {
                material = chkMaterials.Text;
                active = null;
                generic = null;
                forms = null;
                route = null;
                strength = null;
            }

            if (name == null || name == "")
            {
                throw new FillInException("Plase enter item name.");
            }
            if (generic == "--Select--")
            {
                throw new UnselectedException("Please select one from generic.");
            }
            if (forms == "--Select--")
            {
                throw new UnselectedException("Please select one from forms.");
            }
            if (route == "--Select--")
            {
                throw new UnselectedException("Please select one from drug route.");
            }
            if (strength == null || strength == "")
            {
                throw new FillInException("Please provide strength.");
            }


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT Items VALUES ('" + code + "', '" + material + "', '" + name + "', '" + active + "','" + generic + "', '" + forms + "', '" + route + "', '" + strength + "', '" + batch + "', '" + expiry + "', '" + stock + "', '" + reorderLevel + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successful");

            Response.Redirect(Request.RawUrl);
        }
        catch (FillInException fe)
        {
            MessageBox.Show(fe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (UnselectedException use)
        {
            MessageBox.Show(use.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (FormatException)
        {
            MessageBox.Show("Please provide stock and reorder level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected void BackToItems(object sender, EventArgs e)
    {
        Response.Redirect("Items.aspx");
    }

    protected void BackToMain(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}