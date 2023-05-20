<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GRN.aspx.cs" Inherits="GRN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table colspan="3">
            <tr style="height:30px;">
                <td colspan="2">
                    <h3 style="line-height:15px">Good Receipt Notes</h3>
                </td>
                <td colspan="3" style="text-align:right">
                    <asp:Button CssClass="button1 createbutton" ID="btnCreate" runat="server" Text="Create" OnClick="LinkCreateGRN" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvGRN" runat="server" DataSourceID="SqlDS1" AllowPaging="true" PageSize="10" DataKeyNames="DocumentNumber" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                        <Columns>
                            <asp:BoundField DataField="DocumentNumber" HeaderText="Document Number" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DocumentDate" HeaderText="Document Date" DataFormatString="{0:d}" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Vendor" HeaderText="Vendor" HeaderStyle-Width="200px" />
                            <asp:BoundField DataField="Store" HeaderText="Store" HeaderStyle-Width="200px" />
                            <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:right">
                    <asp:Button CssClass="button1 backbutton" ID="btnBackToProcurement" runat="server" Text="Back" OnClick="BackToProcurement" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDS1" runat="server" ConnectionString="Data Source=localhost; Initial Catalog=HospitalIS; Integrated Security = true;" SelectCommand="SELECT * FROM GoodReceiptNotes"></asp:SqlDataSource>
    </div>
</asp:Content>

