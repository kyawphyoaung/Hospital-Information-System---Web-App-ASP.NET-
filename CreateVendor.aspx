<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateVendor.aspx.cs" Inherits="CreateVendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <fieldset>
            <legend><b>Create New Vendor :</b></legend>
            <table colspan="3">
                <tr>
                    <td>Code *</td> 
                    <td class="auto-style1">:</td>
                    <td><asp:TextBox CssClass="myInput" ID="txtCode" runat="server" ReadOnly="true" Width="135px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Name *</td>
                    <td class="auto-style1">:</td>
                    <td><asp:TextBox CssClass="myInput" ID="txtName" runat="server" Width="135px"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:right">
                        <asp:Button CssClass="button1 createbutton" ID="btnCreateVendor" runat="server" Text="Create" OnClick="CreateNewVendor" />
                        <asp:Button CssClass="button1 backbutton" ID="btnBackToVendor" runat="server" Text="Back" OnClick="LinkToVendors" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

