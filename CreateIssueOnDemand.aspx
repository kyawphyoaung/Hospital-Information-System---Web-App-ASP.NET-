<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateIssueOnDemand.aspx.cs" Inherits="CreateIssueOnDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8" />
    <link href="Content/StyleSheet.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <fieldset>
            <legend><b>Create Issue On Demand :</b></legend>
        <table colspan="9">
            <tr>
                <td>Issue Number</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox ID="txtIssueNumber" runat="server" ReadOnly="true" CssClass="myInput"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Patient ID *</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox ID="txtPatientID" runat="server" CssClass="myInput"> </asp:TextBox> </td>
                <td><asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/Image/search.png" OnClick="SearchPatientID" Height="22px" Width="22px"/></td>
                <td></td>
                <td><asp:CheckBox ID="chkPatient" runat="server" Checked="false" Text="External Patient" AutoPostBack="true" OnCheckedChanged="ExternalPatient" /></td>
            </tr>
            <tr>
                <td>Patient Name *</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox ID="txtPatientName" runat="server" ReadOnly="true" CssClass="myInput"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Store *</td>
                <td class="auto-style1">:</td>
                <td><asp:DropDownList ID="ddlStore" runat="server" DataTextField="Name" DataValueField="Name" DataSourceID="SqlDS1" CssClass="myInput" AutoPostBack="true" OnSelectedIndexChanged="StoreSelected"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="chkMaterial" runat="server" Text="Materials" Checked="false" AutoPostBack="true" OnCheckedChanged="SearchMaterials" /></td>
            </tr>
            <tr>
                <td>Generic </td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox ID="txtGeneric" runat="server" CssClass="myInput"></asp:TextBox></td>
                <td><asp:ImageButton ID="ibtnSearchGeneric" runat="server" ImageUrl="~/Image/search.png" OnClick="SearchGeneric" Height="22px" Width="22px"/></td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:GridView ID="gvGeneric" runat="server" DataKeyNames="Generic" AutoGenerateSelectButton="true" OnSelectedIndexChanged="SelectedGeneric" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvGeneric_SelectedIndexChanging" SelectedRowStyle-BackColor="#99ccff" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Generic" HeaderText="Generic Name" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>Item Name or Code</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox ID="txtItem" runat="server" CssClass="myInput" ></asp:TextBox> </td>
                <td><asp:ImageButton ID="ibtnSearchItem" runat="server" ImageUrl="~/Image/search.png" OnClick="Search" Height="22px" Width="22px"/></td>
                <td></td>
                <td>Quantity *</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="myInput" TextMode="Number"></asp:TextBox></td>
                <td><asp:Button CssClass="button1" ID="btnQuantityAdd" runat="server" Text="Add" OnClick="QuantityAdd" /></td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:GridView ID="gvItems" runat="server" DataKeyNames="Code" AutoGenerateSelectButton="true" AutoGenerateColumns="false" OnSelectedIndexChanged="AddItems" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvItems_SelectedIndexChanging" SelectedRowStyle-BackColor="#99ccff">
                        <Columns>
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch Number" />
                            <asp:BoundField DataField="Expiry" HeaderText="Expiry Date" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock On Hand" />
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gvMaterials" runat="server" DataKeyNames="Code" AutoGenerateSelectButton="true" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" OnPageIndexChanging="gvMaterials_SelectedIndexChanging" OnSelectedIndexChanged="AddMaterials" SelectedRowStyle-BackColor="#99ccff">
                        <Columns>
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch" />
                            <asp:BoundField DataField="Expiry" HeaderText="Expiry" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock On Hand" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:GridView ID="gvSelectedItems" runat="server" DataSourceID="SqlDS2" DataKeyNames="Code" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" AutoGenerateColumns="false" Visible="false" HeaderStyle-BackColor="ControlLight">
                        <Columns>
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch Number" />
                            <asp:BoundField DataField="Expiry" HeaderText="Expiry Date" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock On Hand" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:right"><asp:Button CssClass="button1" ID="confirmDispense" runat="server" Text="Confirm Dispense" OnClick="ConfirmDispense" Height="30px"/></td>
        
                <td colspan="9" style="text-align:right"><asp:Button CssClass="button1" ID="cancel" runat="server" Text="Cancel" OnClick="Cancel" Height="30px" /></td>
            </tr>
        </table>
        </fieldset>
        <asp:SqlDataSource ID="SqlDS1" runat="server" ConnectionString="Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true;" SelectCommand="SELECT * FROM Stores"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDS2" runat="server" ConnectionString="Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true;" DeleteCommand="DELETE FROM AddItems WHERE Code = @Code" SelectCommand="SELECT * FROM AddItems" UpdateCommand="UPDATE AddItems SET Quantity = @Quantity WHERE Code = @Code"></asp:SqlDataSource>
    </div>
</asp:Content>

