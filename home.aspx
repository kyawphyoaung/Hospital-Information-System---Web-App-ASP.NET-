<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <br />
        <br />
        <asp:Label ID="lbl" runat="server" Text="This is Home Page" />
        <br />

        <asp:Button ID="registration" runat="server" Text="Register" OnClick="gotoregister"/> <!-- RegisterPage -->
        <asp:Button ID="pharmacy" runat="server" Text="Pharmacy" /> <!-- Pharmacy Page -->

    </div>
</asp:Content>

