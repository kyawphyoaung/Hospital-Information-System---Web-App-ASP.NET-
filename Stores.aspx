<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Stores.aspx.cs" Inherits="Stores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table colspan="3">
            <tr style="height:30px">
                <td colspan="2">
                    <h3 style="line-height:15px">List of Stores</h3>
                </td>
                <td colspan="3" style="text-align:right">
                    <asp:Button CssClass="button1 createbutton" ID="btnCreateStore" runat="server" Text="Create" OnClick="LinkCreateStore" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvStores" runat="server" DataSourceID="SqlDS1" DataKeyNames="Code" AllowPaging="true" PageSize="10" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Code" HeaderText="Code" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="200px" />
                            <asp:BoundField DataField="Category" HeaderText="Category" HeaderStyle-Width="200px" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:right">
                    <asp:Button CssClass="button1 backbutton" ID="btnBackToInventory" runat="server" Text="Back" OnClick="BackToInventory" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDS1" runat="server" ConnectionString="Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true" SelectCommand ="SELECT * FROM Stores"></asp:SqlDataSource>
    </div>
</asp:Content>

