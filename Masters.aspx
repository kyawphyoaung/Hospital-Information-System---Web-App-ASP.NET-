<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Masters.aspx.cs" Inherits="Masters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Button ID="btnGeneric" runat="server" Text="Generic" OnClick="LinkGeneric" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
        <br />
        <br />
        <asp:Button ID="btnItems" runat="server" Text="Items" OnClick="LinkItems" Style="background-image:url('Image/plus.png');" CssClass="button button1" />
    </div>
</asp:Content>

