<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Button ID="regpage" runat="server" Text="New Patient" OnClick="newregister" Style="background-image:url('Image/plus.png');" CssClass="button button1"/> <!-- RegisterPage -->
        <br />
        <br />
        <asp:Button ID="patientlist" runat="server" Text="Patient List" OnClick="patientlistpage" Style="background-image:url('Image/plus.png');" CssClass="button button1"/> <!-- Patient List -->
        <br />
        <br />
        <asp:Button ID="report" runat="server" Text="Report Patient List" Style="background-image:url('Image/plus.png');" CssClass="button button1"/> <!-- Patient List Page -->
    </div>
</asp:Content>

