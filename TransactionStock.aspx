<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TransactionStock.aspx.cs" Inherits="TransactionStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table colspan="3">
            <tr style="height:30px">
                <td colspan="2">
                    <h3 style="line-height:15px">Transaction Stock Report</h3>
                </td>
                <td colspan="3" style="text-align:right">
                    <asp:Button CssClass="button1" ID="btnStockIssue" runat="server" Text="Stock Issue" OnClick="LinkStockIssue" Height="25px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvTransactionStock" runat="server" DataSourceID="SqlDS1" DataKeyNames="DocumentNumber" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                        <Columns>
                            <asp:BoundField DataField="DocumentNumber" HeaderText="Document Number" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DocumentDate" HeaderText="Document Date" DataFormatString="{0:d}" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="IssueStore" HeaderText="Issue Store" HeaderStyle-Width="150px" />
                            <asp:BoundField DataField="ReceiptStore" HeaderText="Receipt Store" HeaderStyle-Width="150px" />
                            <asp:BoundField DataField="Code" HeaderText="Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="150px" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Expiry" HeaderText="Expiry Date" DataFormatString="{0:d}" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Stock" HeaderText="Quantity" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:right">
                    <asp:Button CssClass="button1 backbutton" ID="btnBackToReports" runat="server" Text="Back" OnClick="BackToInventoryReports" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDS1" runat="server" ConnectionString="Data Source=localhost; Initial Catalog = HospitalIS; Integrated Security = true;" SelectCommand="SELECT * FROM TransactionStock"></asp:SqlDataSource>
    </div>
</asp:Content>

