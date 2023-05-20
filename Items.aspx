<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Items.aspx.cs" Inherits="Items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table colspan="5">
            <tr style="height:30px">
                <td colspan="2">
                    <h3 style="line-height:15px">Items</h3>
                </td>
                <td colspan="3" style="text-align:right">
                    <asp:Button CssClass="button1" ID="btnCreateItem" runat="server" Text="Create Item" OnClick="LinkCreateItem" Width="150px" Height="30px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="chkMaterial" runat="server" Text="Materials" Checked="false" AutoPostBack="true" OnCheckedChanged="MaterialsChecked" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="gvItems" runat="server" DataKeyName="Code" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" OnPageIndexChanging="gvItems_SelectedIndexChanging" HeaderStyle-Height="25px">
                        <Columns>
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Generic" HeaderText="Generic" />
                            <asp:BoundField DataField="Forms" HeaderText="Forms" />
                            <asp:BoundField DataField="Route" HeaderText="Route" />
                            <asp:BoundField DataField="Strength" HeaderText="Strength" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch" />
                            <asp:BoundField DataField="Expiry" HeaderText="Expiry" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock On Hand" />
                            <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" />
                            <asp:ImageField DataImageUrlField="Active" DataImageUrlFormatString="~\Active\{0}" HeaderText="Active" ControlStyle-Height="17px" ControlStyle-Width="17px" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px" />
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gvMaterials" runat="server" DataKeyName="Code" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" OnPageIndexChanging="gvMaterials_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch" />
                            <asp:BoundField DataField="Expiry" HeaderText="Expiry" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock On Hand" />
                            <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align:right">
                    <asp:Button CssClass="button1 backbutton" ID="btnBackToMasters" runat="server" Text="Back" OnClick="BackToMasters" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

