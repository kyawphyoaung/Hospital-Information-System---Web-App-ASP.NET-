<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PharmacyReports.aspx.cs" Inherits="Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Button ID="btnSaleReports" runat="server" Text="Sale Reports" OnClick="LinkSaleReports" />
        <br />
        <br />
        <asp:Button ID="btnBackToPharmacy" runat="server" Text="Back" OnClick="BackToPharmacy" />
        <br />
        <br />
        <asp:Button ID="btnBackToMain" runat="server" Text="Main" OnClick="BackToMain" />
    </div>
</asp:Content>

