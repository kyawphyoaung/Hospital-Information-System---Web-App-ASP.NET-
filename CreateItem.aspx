<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateItem.aspx.cs" Inherits="CreateItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>jQuery UI Datepicker - Restrict date range</title>
    <link rel="stylesheet" href="Styles/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker({ 
                
                minDate: -0,
                
            changeMonth: true,

            changeYear: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" xmlns:asp="#unknown">
    <div>
        <fieldset>
            <legend><b>Create Item :</b></legend>
            <table colspan="3">
                <tr>
                    <td>Code *</td>
                    <td class="auto-style1">:</td>
                    <td><asp:TextBox CssClass="myInput" ID="txtCode" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Name *</td>
                    <td class="auto-style1">:</td>
                    <td>
                        <asp:TextBox CssClass="myInput" ID="txtName" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="chkMaterials" runat="server" Text="Materials" AutoPostBack="true" OnCheckedChanged="MaterialsChecked" Checked="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkActive" runat="server" Text="Active" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td>Generic *</td>
                    <td class="auto-style1">:</td>
                    <td><asp:DropDownList CssClass="myInput" ID="ddlGeneric" runat="server" DataKeyNames="Code" DataSourceID="SqlDS1" DataTextField="Name" DataValueField="Name"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Forms *</td>
                    <td class="auto-style1">:</td>
                    <td>
                        <asp:DropDownList CssClass="myInput" ID="ddlForms" runat="server">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Capsule</asp:ListItem>
                            <asp:ListItem>Tablet</asp:ListItem>
                            <asp:ListItem>Injection</asp:ListItem>
                            <asp:ListItem>Aerosol Inhaler</asp:ListItem>
                            <asp:ListItem>Inhalation</asp:ListItem>
                            <asp:ListItem>Powder</asp:ListItem>
                            <asp:ListItem>Drops</asp:ListItem>
                            <asp:ListItem>Suppositories</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Drug Route *</td>
                    <td class="auto-style1">:</td>
                    <td>
                        <asp:DropDownList CssClass="myInput" ID="ddlRoute" runat="server">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Oral</asp:ListItem>
                            <asp:ListItem>Inhalation</asp:ListItem>
                            <asp:ListItem>Intravenous</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Strength *</td>
                    <td class="auto-style1">:</td>
                    <td>
                        <asp:TextBox CssClass="myInput" ID="txtStrength" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Batch Number</td>
                    <td class="auto-style1">:</td>
                    <td>
                        <asp:TextBox CssClass="myInput" ID="txtBatch" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Expiry Date</td>
                    <td class="auto-style1">:</td>
                    <td>
                        <input class="myInput" type="text" id="datepicker" name="datepicker" runat="server" clientidmode="static" />
                    </td>
                </tr>
                <tr>
                    <td>Stock On Hand *</td>
                    <td class="auto-style1">:</td>
                    <td>
                        <asp:TextBox CssClass="myInput" ID="txtStockOnHand" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Reorder Level *</td>
                    <td class="auto-style1">:</td>
                    <td>
                        <asp:TextBox CssClass="myInput" ID="txtReorderLevel" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:right">
                        <asp:Button CssClass="button1 createbutton" ID="btnCreateItem" runat="server" Text="Create" OnClick="CreateNewItem" />
                        <asp:Button CssClass="button1 backbutton" ID="btnBackToItems" runat="server" Text="Back" OnClick="BackToItems" />
                    </td>
                </tr>
            </table>
        </fieldset>  
        <asp:SqlDataSource ID="SqlDS1" runat="server" ConnectionString="Data Source=localhost; Initial Catalog=HospitalIS; Integrated Security=true;" SelectCommand="SELECT Name FROM Generic ORDER BY Name ASC"></asp:SqlDataSource>
        </div>
</asp:Content>

