<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InventoryReports.aspx.cs" Inherits="InventoryReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Button ID="btnReorderLevel" runat="server" Text="Reorder Level" OnClick="LinkReorderLevel" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
        <br />
        <br />
        <asp:Button ID="btnNearExpiry" runat="server" Text="Near Expiry" OnClick="LinkNearExpiry" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
        <br />
        <br />
        <asp:Button ID="btnStockLedger" runat="server" Text="Stock Ledger" OnClick="LinkStockLedger" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
        <br />
        <br />
        <asp:Button ID="btnTransactionStock" runat="server" Text="Transaction Stock" OnClick="LinkTransactionStock" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
    </div>
</asp:Content>

