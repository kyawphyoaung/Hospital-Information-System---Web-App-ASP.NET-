<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateStore.aspx.cs" Inherits="CreateStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <fieldset>
            <legend><b>Create New Store :</b></legend>
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
                    <td>Category Type *</td>
                    <td class="auto-style1">:</td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>General</asp:ListItem>
                            <asp:ListItem>Unit</asp:ListItem>
                            <asp:ListItem>Central</asp:ListItem>
                            <asp:ListItem>In Transit Store</asp:ListItem>
                            <asp:ListItem>Consignment Store</asp:ListItem>
                            <asp:ListItem>Preserve Store</asp:ListItem>
                            <asp:ListItem>OT</asp:ListItem>
                            <asp:ListItem>Miscellaneous</asp:ListItem>
                            <asp:ListItem>OP Pharmacy</asp:ListItem>
                            <asp:ListItem>Inter Transit Store</asp:ListItem>
                            <asp:ListItem>Kit Store</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:right">
                        <asp:Button CssClass="button1 createbutton" ID="btnCreateStore" runat="server" Text="Create" OnClick="CreateNewStore" />
                        <asp:Button CssClass="button1 backbutton" ID="btnBackToStore" runat="server" Text="Back" OnClick="LinkToStores" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

