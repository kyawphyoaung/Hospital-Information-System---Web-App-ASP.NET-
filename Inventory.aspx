<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Inventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Button ID="btnStockIssue" runat="server" Text="Stock Issue" OnClick="LinkStockIssue" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
        <br />
        <br />
        <asp:Button ID="btnStores" runat="server" Text="Stores" OnClick="LinkStore" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
        <br />
        <br />
        <asp:Button ID="btnVendors" runat="server" Text="Vendors" OnClick="LinkVendor" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
        <br />
        <br />
        <asp:Button ID="btnInventoryReports" runat="server" Text="Reports" OnClick="LinkInventoryReports" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
    </div>
</asp:Content>

