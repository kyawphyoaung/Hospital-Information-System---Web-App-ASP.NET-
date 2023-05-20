<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateGeneric.aspx.cs" Inherits="CreateGeneric" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <fieldset>
            <legend><b>Create Generic :</b></legend>
            <table colspan="4">
                <tr>
                    <td>Code *</td>
                    <td class="auto-style1">:</td>
                    <td><asp:TextBox CssClass="myInput" ID="txtCode" runat="server" ReadOnly="true" Width="135px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Name *</td>
                    <td class="auto-style1">:</td>
                    <td><asp:TextBox CssClass="myInput" ID="txtName" runat="server" Width="135px"></asp:TextBox><asp:Label ID="lblName" runat="server" Visible="false" ForeColor="Red">  Please provide generic name.</asp:Label></td>
                </tr>
                <tr>
                    <td><asp:CheckBox ID="chkActive" runat="server" Checked="true" Text="Active"/></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:right">
                        <asp:Button CssClass="button1 createbutton" ID="btnCreateGeneric" runat="server" Text="Create" OnClick="LinkCreateGeneric" />
                        <asp:Button CssClass="button1 backbutton" ID="btnBackToGeneric" runat="server" Text="Back" OnClick="LinkToGeneric" />
                   </td>
                </tr>
            </table>
        </fieldset>
    </div>    
</asp:Content>

