<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pharmacy.aspx.cs" Inherits="Pharmacy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Button ID="btnIOD" runat="server" Text="Issue On Demand" OnClick="LinkIOD" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
        <br />
        <br />
        <asp:Button ID="btnMasters" runat="server" Text="Masters" OnClick="LinkMasters" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
        <br />
        <br />
        <asp:Button ID="btnReports" runat="server" Text="Reports" OnClick="LinkReports" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
    </div>
</asp:Content>

