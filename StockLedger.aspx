<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StockLedger.aspx.cs" Inherits="StockLedger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table colspan="3">
            <tr style="height:30px">
                <td>
                    <h3 style="line-height:15px">Stock Ledger</h3>
                </td>
            </tr>
            <tr>
                <td>Stores : <asp:DropDownList ID="ddlStores" runat="server" DataSourceID="SqlDS1" DataTextField="Name" DataValueField="Name" OnSelectedIndexChanged="DisplayStockLedger" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvStockLedger" runat="server" DataKeyNames="RefDocNo" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" HeaderStyle-Height="25px" OnPageIndexChanging="gvStockLedger_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Store" HeaderText="Store" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Code" HeaderText="Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="200px" />
                            <asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="RefDocNo" HeaderText="Ref Doc No" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="RefDocDate" HeaderText="Ref Doc Date" DataFormatString="{0:d}" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="StockInQty" HeaderText="StockIn Quantity" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="StockOutQty" HeaderText="StockOut Quantity" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ClosingStock" HeaderText="Closing Stock" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Expiry" HeaderText="Expiry Date" DataFormatString="{0:d}" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
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
        <asp:SqlDataSource ID="SqlDS1" runat="server" ConnectionString="Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true;" SelectCommand ="SELECT Name FROM Stores"></asp:SqlDataSource>
    </div>
</asp:Content>

