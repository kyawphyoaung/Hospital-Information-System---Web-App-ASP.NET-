<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Procurement.aspx.cs" Inherits="Procurement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Button ID="btnGRN" runat="server" Text="Goods Receipt Notes" OnClick="LinkGRN" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
    </div>
</asp:Content>

